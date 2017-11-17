using System;

namespace Course
{
    public static class Menu
    {
        public static void Start()
        {
            int m = 1;

            Brand.show_logo();
#region Title
            var menuTitle = @"             
                                               BANK SYSTEM
                                              

                                                   MENU:
                                            1 - Client managment
                                            2 - Show ballance";
#endregion
            Console.WriteLine(menuTitle);
                try
                {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) {

                    Console.Clear();
                    Console.WriteLine(menuTitle);

                    switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                    {
                        case 49:
                            Console.Clear();


                            Console.WriteLine($"{m++} - Add a client");
                            Console.WriteLine($"{m++} - Ballance by ID");
                            Console.WriteLine($"{m++} - Show list of custumers");


                            switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                            {
                                case 49:
                                    var card = new CreditCard();
                                    Console.Clear();
                                    Console.WriteLine("User name: ");
                                    var firstName = Console.ReadLine();
                                    Console.WriteLine("Second name: ");
                                    var secondeName = Console.ReadLine();
                                    if (DataBase.Add_Client(firstName, secondeName, card.NameOfCard, card.NumberOfCard))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Client has added with NAME: {0} {1}, Card Name: '{2}', Number of card: '{3}', ID: {4} ", firstName, secondeName, card.NameOfCard, card.NumberOfCard, DataBase.LastId);
                                    }
                                    break;

                                case 50:
                                    Console.Clear();
                                    Console.WriteLine("Input costumer's ID : ");
                                    try
                                    {
                                        var id = Convert.ToInt64(Console.ReadLine());
                                        var ballance = DataBase.GetBallance(id);
                                        Console.WriteLine("Ballance of ID {0} is {1} {2}", id, Convert.ToString(ballance), (char)Bank.Currency.Dollar);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;

                                case 51:
                                    DataBase.Show();

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
