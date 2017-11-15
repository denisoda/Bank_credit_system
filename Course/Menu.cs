using System;

namespace Course_APP
{
    public static class Menu
    {
        public static void start()
        {
            My_Info.Brand.show_logo();
#region Title
            string Menu_Title = @"             
                                               BANK SYSTEM
                                              

                                                   MENU:
                                            1 - Client managment
                                            2 - Show ballance";
#endregion
            Console.WriteLine(Menu_Title);
                try
                {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) {
                Console.Clear();
                Console.WriteLine(Menu_Title);

                    switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                    {
                        case 49:
                            Console.Clear();
                            Console.WriteLine("1 - Add a client");
                            Console.WriteLine("2 - Ballance by ID");
                            switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                            {
                                case 49:
                                    CreditCard CARD = new CreditCard();
                                    Console.Clear();
                                    Console.WriteLine("User name: ");
                                    string First_Name = Console.ReadLine();
                                    Console.WriteLine("Second name: ");
                                    string Seconde_Name = Console.ReadLine();
                                    if (DataBase.Add_Client(First_Name, Seconde_Name, CARD.Name_Of_Card, CARD.Number_of_card))
                                    {
                                        Console.Clear();
                                        Console.WriteLine(string.Format("Client has added with NAME: {0} {1}, Card Name: '{2}', Number of card: '{3}', ID: {4} ", First_Name, Seconde_Name, CARD.Name_Of_Card, CARD.Number_of_card, DataBase.Last_ID));
                                    }
                                    break;

                                case 50:
                                    Console.Clear();
                                    Console.WriteLine("Input costumer's ID : ");
                                    try
                                    {
                                        long ID = Convert.ToInt64(Console.ReadLine());
                                        long Ballance = DataBase.Get_Ballance(ID);
                                        Console.WriteLine( string.Format("Ballance of ID {0} is {1} {2}", ID, Convert.ToString(Ballance), (char)Bank.Currency.Dollar));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;
                            }
                            break;
                                case 51:
   
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
