namespace GambleMaticApi
{
    public class DatabaseManager
    {


        public string _connectionString { get; set; }
        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }



    }
}
