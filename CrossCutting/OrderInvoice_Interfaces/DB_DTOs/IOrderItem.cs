namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OrderItem.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOrderItem 
    {
        int Objid { get; set; }
 
        int OrderInvoiceObjid { get; set; }
 
        int? PredefinedProductObjid { get; set; }
 
        int? ProductObjid { get; set; }
 
        decimal Price { get; set; }
 
        string Note { get; set; }
    }
}
