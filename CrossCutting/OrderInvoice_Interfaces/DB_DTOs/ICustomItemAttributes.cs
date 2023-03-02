namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a CustomItemAttributes.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomItemAttributes 
    {
        int Objid { get; set; }
 
        int OrderItemObjid { get; set; }
 
        int AttributeObjid { get; set; }
 
        string Value { get; set; }
    }
}
