using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Data.SQLite;

namespace Course
{
    public static class DataBase
    {
        private static readonly string Path =$"Data Source = {System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DataBase\costumers.db")}";
            
        private static  SQLiteConnection Db = new SQLiteConnection(Path); 

        public static long LastId { get; set; }

        private static void Connect()=>Db.Open();

        public static void Disconnect()=>Db.Close();
        
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
                
                using (Db = new SQLiteConnection(Path))
                {
                    if ((Db.State & ConnectionState.Open) != 0)
                    {
                      Disconnect();
                    }
                        
                    Connect();

                    var commandText = $"SELECT Ballance FROM Costumers WHERE id = {id}";

                    using (var cmd = new SQLiteCommand(commandText, Db))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            return rdr.Read() ? rdr.GetInt64(0) : 0;
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

        private static bool Command(string command)
        {
            try
            {
                using (Db = new SQLiteConnection(Path))
                {
                    Connect();

                    var commandText = string.Format(command);

                    using (var cmd = new SQLiteCommand(commandText, Db))
                    {
                        cmd.ExecuteScalar();
                        Disconnect();
                        return true;

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        
        public static long Show(string command = "SELECT* FROM Costumers")
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
                            while (rdr.Read())
                            {
                                Console.WriteLine($"ID: {rdr[0]} Name: {rdr[1]} {rdr[2]} Card: '{rdr[3]}' Number: {rdr[4]} Ballance: {rdr[5]}{(char)Bank.Currency.Dollar}");

                            }

                            return 0;
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
        ///  1- "withdraw"
        ///  2- "trasfer"
        ///  }
        ///  </para>
        ///</summary>
        public static bool Operations(string operation, long id, float amount)
        {
            switch (operation)
            {
                case "withdraw":

                    if (Command($"UPDATE Costumers SET Ballance = Ballance - {amount} WHERE id = {id}"))
                    {
                        return true;
                    }
                    break;

                case "transfer":

                    if (Command($"UPDATE Costumers SET Ballance = Ballance + {amount} WHERE id = {id}"))
                    {
                        return true;
                    }
                    
                    break;

            }

            return false;
        }
        
    }
}

