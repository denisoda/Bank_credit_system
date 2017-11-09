using System;
using System.Collections.Generic;

namespace Course_APP
{
    class Client : CreditCard
    {
        string First_name;
        string Second_name;
        int ID = 0;
        List<string> Credit_Card_List;
        List <object> Transactions;
        public Client(string First_name = "Ilya", string Second_name = "Dzeraziak")
        {
            List<string> Credit_Card_List = new List<string>();
            List<string> Transactions = new List<string>();
            this.First_name = First_name;
            this.Second_name = Second_name;
            Create_Credit_Card(Credit_Card_List);
            Transactions.Add(Convert.ToString("Customer has added to the sevice with ID " + ++ ID  + ", Ballance : " + Ballance));
            Bank.Amound_of_clients+=1;
        }

        void Create_Credit_Card(List<string> Card)
        {
            Card.Add(Convert.ToString("Name of card : " + Name_Of_Card + " Number : " + Number_of_card  + " Ballance : " + Ballance));
        }
    }
}
