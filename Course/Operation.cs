using System;
using System.Collections.Generic;

namespace Course_APP
{
   static public class Operation
    {
        const string dataFmt = "{0,-30}{1:yyyy-MM-dd HH:mm}";

        static public void Operations(string TYPE_OF_OPERATION, ref float Ballance, float Sum, ref List<object> Transaction)
        {
            switch (TYPE_OF_OPERATION)
            {
                case "withdraw":
                    withdraw(ref Ballance, Sum);
                    Transaction.Add(DateTime.Now + " : " + "- " + Sum + "Ballance: " + Ballance);
                    break;

                case "transfer":
                    transfer(ref Ballance, Sum);
                    Transaction.Add(DateTime.Now + " : " + "+ " + Sum + "Ballance: " + Ballance);
                    break;

                case "ballance":
                    Transaction.Add(DateTime.Now + " : " + "Costumer checket out ballance" + Ballance);
                    break;
            }
        }

        static float withdraw(ref float Ballance, float Sum)
        {
            return Ballance -= Sum;
        }

        static float transfer(ref float Ballance, float Sum)
        {
            return Ballance += Sum;
        }

        static float show_ballance(ref float Ballance, float Sum)
        {
            return Ballance;
        }

    }
}
