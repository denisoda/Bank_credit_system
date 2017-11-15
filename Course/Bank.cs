namespace Course_APP
{
    public static class Bank
    {
        public static string NAME { get { return "DZBank"; } }
        public static long number_of_clients = DataBase.Last_ID;

        public enum Currency
        {
            Dollar = '$',
            Euro = '€'
        }
    }
}
