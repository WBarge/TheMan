namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PredefinedOptionDetail.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPredefinedOptionDetail 
    {
        int Objid { get; set; }
 
        int PredefinedOptionObjid { get; set; }
 
        int AttribuiteObjid { get; set; }
 
        string Value { get; set; }
 
        bool Deleted { get; set; }
    }
}
