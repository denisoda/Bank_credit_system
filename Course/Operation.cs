using System;
using System.Collections.Generic;

namespace Course
{
   public static class Operation
    {
        private const string DataFmt = "{0,-30}{1:yyyy-MM-dd HH:mm}";

        public static void Operations(string typeOfOperation, ref float ballance, float sum, ref List<object> transaction)
        {
            switch (typeOfOperation)
            {
                case "withdraw":
                    Withdraw(ballance, sum);
                    transaction.Add(DateTime.Now + " : " + "- " + sum + "Ballance: " + ballance);
                    break;

                case "transfer":
                    Transfer(ballance, sum);
                    transaction.Add(DateTime.Now + " : " + "+ " + sum + "Ballance: " + ballance);
                    break;

                case "ballance":
                    transaction.Add(DateTime.Now + " : " + "Costumer checket out ballance" + ballance);
                    break;
            }
        }

        public static float Withdraw(float ballance, float sum)
        {
            return ballance -= sum;
        }

        private static float Transfer(float ballance, float sum)
        {
            return ballance += sum;
        }

        private static float show_ballance(ref float ballance, float sum)
        {
            return ballance;
        }

    }
}
