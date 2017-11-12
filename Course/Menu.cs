using System;

namespace Course_APP
{
    public static class Menu
    {
        public static void start()
        {
            string Menu_Title = @"             
                                               BANK SYSTEM
                                              

                                                   MENU:
                                            1 - Client managment
                                            2 - Show ballance";

            Console.WriteLine(Menu_Title);
                try
                {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) {
                Console.Clear();
                Console.WriteLine(Menu_Title);

                    switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                    {
                        case 49:
                            CreditCard CARD = new CreditCard();
                            Console.Clear();
                            Console.WriteLine("User name: ");
                            string First_Name = Console.ReadLine();
                            Console.WriteLine("Second name: ");
                            string Seconde_Name = Console.ReadLine();
                            if(DataBase.Add_Client(First_Name, Seconde_Name, CARD.Name_Of_Card, CARD.Number_of_card))
                            {
                                Console.Clear();
                                Console.WriteLine(string.Format("Client has added with NAME: {0} {1}, Card Name: '{2}', Number of card: '{3}', ID: {4} ", First_Name, Seconde_Name, CARD.Name_Of_Card, CARD.Number_of_card, DataBase.Last_ID));
                            }
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
