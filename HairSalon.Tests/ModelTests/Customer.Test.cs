using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Tests
{
    public class CustomerTest : IDisposable
    {
        public CustomerTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root;port=8889;database=first_last_test;";
        }

        public void Dispose()
        {
            Customer.ClearAll();
        }
    }
}