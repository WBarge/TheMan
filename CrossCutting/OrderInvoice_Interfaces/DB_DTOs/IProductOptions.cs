namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a ProductOptions.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IProductOptions 
    {
        int Objid { get; set; }
 
        string Name { get; set; }
 
        string Description { get; set; }
 
        bool Deleted { get; set; }
    }
}
