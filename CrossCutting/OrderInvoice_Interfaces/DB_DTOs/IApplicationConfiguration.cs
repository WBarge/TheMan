namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a ApplicationConfiguration.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IApplicationConfiguration 
    {
        int Objid { get; set; }
 
        string Type { get; set; }
 
        string Configuration { get; set; }
    }
}
