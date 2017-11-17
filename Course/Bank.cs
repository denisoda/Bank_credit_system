namespace Course
{
    public static class Bank
    {
        public static string Name => "DZBank";
        public static long NumberOfClients = DataBase.LastId;

        public enum Currency
        {
            Dollar = '$',
            Euro = '€'
        }
    }
}
