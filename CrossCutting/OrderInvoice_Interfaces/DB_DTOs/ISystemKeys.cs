namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a SystemKeys.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ISystemKeys 
    {
        string TableName { get; set; }
 
        int LatestKey { get; set; }
    }
}
