using System;

namespace Course_APP
{
    public class CreditCard
    {
        Random randINT = new Random();
        
        protected string Name_Of_Card = "VISA";
        protected int Number_of_card{get{return randINT.Next(5,999);}}
        protected float Ballance;

        public CreditCard()
        {
            Ballance = 100;
        }
    }
}
