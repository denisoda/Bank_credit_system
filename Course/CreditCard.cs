using System;

namespace Course
{
    public  class CreditCard
    {
        private readonly Random _randInt = new Random();
        public string NameOfCard = "VISA";
        public int NumberOfCard { get { return _randInt.Next(100000000, 999999999); } }

        public CreditCard()
        {
            var numberOfCard = this.NumberOfCard;
            var nameOfCard = this.NameOfCard;
        }
	}
}
