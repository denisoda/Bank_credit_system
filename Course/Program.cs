using System;
using My_Info;

namespace Course_APP
{
    class Program
    {
        static void Main(string[] args)
        {

            //DataBase.Add_Client("Test_Name", "Second_name", 1488, 228);
            Brand.show_logo();
            Menu.start();
            Console.ReadKey();
        }
    }
}
