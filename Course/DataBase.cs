using System;
using System.Data.SQLite;

namespace Course
{
	public static class DataBase
	{	
		SQLiteConnection DB = new SQLiteConnection (@"DataBase/costumers");
        SQLiteDataReader reader;


        public static void Connnect()
        {
            DB.Open();
        }
        
        public static void Disconnect()
        {
            DB.Close();
        }

        public static void Add_Client(string Name_First, string Name_Second,string N_Card, int Ballance = 100)
        {
            SQLiteCommand command = new SQLiteCommand();
              
            command.CommandText = "INSERT INTO Costumers(Name_First, Name_Second, Card, Number, Ballance);";
            command.Parameters.Add("@Name_First", System.Data.DbType.Int32).Value;
            command.Parameters.Add("@Name_Second", System.Data.DbType.Int32).Value;
            command.Parameters.Add("@Name_First", System.Data.DbType.Int32).Value;
            command.Parameters.Add("@Name_First", System.Data.DbType.Int32).Value;
        
        }
	}
}

