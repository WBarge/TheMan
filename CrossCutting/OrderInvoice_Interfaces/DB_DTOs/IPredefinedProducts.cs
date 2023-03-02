namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PredefinedProducts.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPredefinedProducts 
    {
        int Objid { get; set; }
 
        int ProductObjid { get; set; }
 
        decimal Price { get; set; }
 
        string MarketDescription { get; set; }
 
        bool Deleted { get; set; }

        int Quantity { get; set; }

    }
}
