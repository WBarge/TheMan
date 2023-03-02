using System.Data;
using System.Data.SqlClient;
using OrderInvoice_Interfaces;

namespace OrderInvoice_DL
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _conString;

        public ConnectionFactory (string connectionString)
        {
            this._conString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(this._conString);
        }
    }
}
