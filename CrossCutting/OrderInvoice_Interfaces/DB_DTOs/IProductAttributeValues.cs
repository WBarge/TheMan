namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a ProductAttributeValues.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IProductAttributeValues 
    {
        int Objid { get; set; }
 
        string Value { get; set; }
 
        string Description { get; set; }
 
        bool DefaultValue { get; set; }
 
        bool Deleted { get; set; }
 
        int ProductAttributesObjid { get; set; }
    }
}
