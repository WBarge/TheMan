using System.Data;

namespace OrderInvoice_Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
