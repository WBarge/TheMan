namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a EMailAddresses.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IEMailAddresses 
    {
        int Objid { get; set; }
 
        int ContactObjid { get; set; }
 
        string Address { get; set; }
 
        bool DefaultAddress { get; set; }
 
        bool Deleted { get; set; }
    }
}
