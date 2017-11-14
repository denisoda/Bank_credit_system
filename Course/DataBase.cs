﻿using System;
using System.Data.SQLite;

namespace Course_APP
{
    public static class DataBase
    {
        static SQLiteConnection DB = new SQLiteConnection(@"Data Source = F:\ilyab\Documents\Projects\Course\Course\DataBase\costumers.db");
#pragma warning disable CS0169 // The field 'DataBase.read' is never used
        static SQLiteDataReader read;
#pragma warning restore CS0169 // The field 'DataBase.read' is never used

        public static long Last_ID { get; set; }

        static void Connect()
        {
            DB.Open();
        }

        public static void Disconnect()
        {
            DB.Close();
        }

        ///<summary>
        ///<para>Adds custumer's data to database</para>
        ///</summary>
        public static bool Add_Client(string Name_First, string Name_Second, string Card, int Number, int Ballance = 100)
        {
            try
            {
                using (DB)
                {
                    SQLiteCommand command = new SQLiteCommand();

                    command.CommandText = "INSERT INTO Costumers(Name_First, Name_Second, Card, Number, Ballance) VALUES (@Name_First, @Name_Second, @Card, @Number, @Ballance);";
                    command.Connection = DB;
                    command.Parameters.Add(new SQLiteParameter("@Name_First", Name_First));
                    command.Parameters.Add(new SQLiteParameter("@Name_Second", Name_First));
                    command.Parameters.Add(new SQLiteParameter("@Card", Card));
                    command.Parameters.Add(new SQLiteParameter("@Number", Number));
                    command.Parameters.Add(new SQLiteParameter("@Ballance", Ballance));
                    Connect();
                    command.ExecuteScalar();
                    Last_ID = DB.LastInsertRowId;
                    Disconnect();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public static Int64 Get_Ballance(long ID)
        {
            try
            {
                using (DB)
                {
                    Connect();

                    string CommandText = string.Format("SELECT Ballance FROM Costumers WHERE id = {0}", ID);

                    using (SQLiteCommand cmd = new SQLiteCommand(CommandText, DB))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                return rdr.GetInt64(0);
                            }
                            else
                            {
                                return 0;
                            }
                          
                            
                        }

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }
    }
}

