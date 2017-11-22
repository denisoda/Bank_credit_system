using System;
using System.Threading;


namespace Course
{
    public static class Menu
    {   
        private static long id;
        private static long ballance;
        private static float sum;

        public static void Start()
        {
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
                                int m = 1;

                                Console.WriteLine($"{m++} - Add a client");
                                Console.WriteLine($"{m++} - Ballance by ID");
                                Console.WriteLine($"{m++} - Show list of custumers");
                                Console.WriteLine($"{m++} - Withdraw money");
                                Console.WriteLine($"{m++} - Add money");
                            


                            switch (Convert.ToInt32(Console.ReadKey(true).KeyChar))
                            {
                                case 49:
                                    var card = new CreditCard();
                                    Console.Clear();
                                    Console.WriteLine("User name: ");
                                    var firstName = Console.ReadLine();
                                    Console.WriteLine("Second name: ");
                                    var secondeName = Console.ReadLine();
                                        if (DataBase.Add_Client(firstName, secondeName, card.NameOfCard,
                                            card.NumberOfCard))
                                        {
                                            Console.Clear();
                                            Console.WriteLine(
                                                "Client has added with NAME: {0} {1}, Card Name: '{2}', Number of card: '{3}', ID: {4} ",
                                                firstName, secondeName, card.NameOfCard, card.NumberOfCard,
                                                DataBase.LastId);
                                        }
                                    break;

                                case 50:
                                    Console.Clear();
                                    Console.WriteLine("Input costumer's ID : ");
                                    try
                                    {
                                        id = Convert.ToInt64(Console.ReadLine());
                                        ballance = DataBase.GetBallance(id);
                                        Console.Clear();
                                        Console.WriteLine("Ballance of ID {0} is {1}{2}", id, Convert.ToString(ballance), (char)Bank.Currency.Dollar);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;

                                case 51:
                                    Console.Clear();
                                    DataBase.Show();

                                    break;

                                case 52:
                                    Console.Clear();
                                    Console.WriteLine("Input costumer's ID : ");
                                    id = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Sum for withdraw:");
                                    float sum = float.Parse(Console.ReadLine());

                                    if (DataBase.Operations("withdraw", id, sum))
                                    {
                                        Console.WriteLine($"Success! Ballance is {DataBase.GetBallance(id)}{(char)Bank.Currency.Dollar} ");
                                    }
                                    break;

                                case 53:
                                    Console.Clear();
                                    Console.WriteLine("Input costumer's ID : ");
                                    id = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Sum for transfer:");
                                    sum = float.Parse(Console.ReadLine());

                                    if (DataBase.Operations("transfer", id, sum))
                                    {
                                        Console.WriteLine($"Success! Ballance is {DataBase.GetBallance(id)}{(char)Bank.Currency.Dollar} ");    
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
