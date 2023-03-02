namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a CustomItemOptionAttributes.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomItemOptionAttributes 
    {
        int Objid { get; set; }
 
        int CustomItemOptionObjid { get; set; }
 
        int AttributeObjid { get; set; }
 
        string Value { get; set; }
    }
}
