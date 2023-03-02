namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a CustomItemOptions.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomItemOptions 
    {
        int Objid { get; set; }
 
        int OrderItemObjid { get; set; }
 
        int ProductOptionObjid { get; set; }
 
        string Note { get; set; }
    }
}
