namespace Course_APP
{
    public static class Bank
    {
        private static string NAME { get { return "DZBank"; } set { NAME = value; } }
        public static string Name = NAME;
        public static long number_of_clients = DataBase.Last_ID;
    }
}
