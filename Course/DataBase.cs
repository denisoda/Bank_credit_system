using System;
using System.Data.SQLite;

namespace Course_APP
{
    public static class DataBase
	{	
		static SQLiteConnection DB = new SQLiteConnection (@"Data Source = F:\ilyab\Documents\Projects\Course\Course\DataBase\costumers.db");
        static SQLiteDataReader reader;


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
        public static bool Add_Client(string Name_First, string Name_Second,int Card,int Number, int Ballance = 100)
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


	}
}

