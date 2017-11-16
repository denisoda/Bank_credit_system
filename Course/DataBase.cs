﻿using System;
using System.Data.SQLite;

namespace Course
{
    public static class DataBase
    {
        private static readonly SQLiteConnection Db = new SQLiteConnection(@"Data Source = F:\ilyab\Documents\Projects\Course\Course\DataBase\costumers.db");

        public static long LastId { get; set; }

        private static void Connect()
        {
            Db.Open();
        }

        public static void Disconnect()
        {
            Db.Close();
        }

        ///<summary>
        ///<para>Adds custumer's data to database</para>
        ///</summary>
        public static bool Add_Client(string nameFirst, string nameSecond, string card, int number, int ballance = 100)
        {
            try
            {
                using (Db)
                {
                    var command = new SQLiteCommand
                    {
                        CommandText = "INSERT INTO Costumers(Name_First, Name_Second, Card, Number, Ballance) VALUES (@Name_First, @Name_Second, @Card, @Number, @Ballance);",
                        Connection = Db
                    };
                    command.Parameters.Add(new SQLiteParameter("@Name_First", nameFirst));
                    command.Parameters.Add(new SQLiteParameter("@Name_Second", nameFirst));
                    command.Parameters.Add(new SQLiteParameter("@Card", card));
                    command.Parameters.Add(new SQLiteParameter("@Number", number));
                    command.Parameters.Add(new SQLiteParameter("@Ballance", ballance));
                    Connect();
                    command.ExecuteScalar();
                    LastId = Db.LastInsertRowId;
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

        public static long GetBallance(long id)
        {
            try
            {
                using (Db)
                {
                    Connect();

                    var commandText = string.Format("SELECT Ballance FROM Costumers WHERE id = {0}", id);

                    using (var cmd = new SQLiteCommand(commandText, Db))
                    {
                        using (var rdr = cmd.ExecuteReader())
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

        private static string Show()
        {
                return Convert.ToString(CommandReturn("SELECT * FROM Costumers"));
        }
        
        private static long CommandReturn(string command)
        {
            try
            {
                using (Db)
                {
                    Connect();

                    var commandText = string.Format(command);

                    using (var cmd = new SQLiteCommand(commandText, Db))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                
                            }
                            while (rdr.Read())
                            {
                                return rdr.GetInt64(0);
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

        ///<summary>
        ///  <para>string operation arguments { 
        ///  1- withdraw
        ///  }
        ///  </para>
        ///</summary>
        public static float Operations(string operation, long id, float amount)
        {
            switch (operation)
            {
                case "withdraw":
   //    FIX             command("asd");
                    return  Operation.Withdraw(GetBallance(id), amount);
                case "transfer":

                    return Operation.Withdraw(GetBallance(id), amount);

            }

            return 0;
        }
    }
}

