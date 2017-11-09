using System;

namespace Course_APP
{
    public static class Menu
    {
        public static void start()
        {
            string Menu_Title = @"  
                                                  MENU:
                                            1 - Add customer
                                            2 - Show ballance";

            Console.WriteLine(Menu_Title);
                try
                {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) {
                    switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                    {
                        case 49:
                            Console.Clear();
                            Console.WriteLine("Add user()");
							
                            break;
                        case 50:
                            Console.WriteLine("Show ballance()");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Goodbye");
            
        }
    }
}
