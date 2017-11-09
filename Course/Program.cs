using System;
using My_Info;

namespace Course_APP
{
    class Program
    {
        static void Main(string[] args)
        {
			Brand.show_logo();
            Menu.start();
            


            Brand.show_info();
            Console.ReadKey();
        }
    }
}
