namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PredefinedProductDetail.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPredefinedProductDetail 
    {
        int Objid { get; set; }
 
        int PredefinedProductObjid { get; set; }
 
        int AttributeObjid { get; set; }
 
        string Value { get; set; }
 
        bool Deleted { get; set; }
    }
}
