using System;

namespace Course_APP
{
    public  class CreditCard
    {
        Random randINT = new Random();
        public string Name_Of_Card = "VISA";
        public int Number_of_card { get { return randINT.Next(100000000, 999999999); } }
        protected float Ballance;

        public CreditCard()
        {
            int Number_of_card = this.Number_of_card;
            string Name_of_Card = this.Name_Of_Card;
        }
	}
}
