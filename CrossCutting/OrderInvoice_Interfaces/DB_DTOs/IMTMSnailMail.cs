namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a MTMSnailMail.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IMtmSnailMail 
    {
        int Objid { get; set; }
 
        int ContactObjid { get; set; }
 
        int SnailMailAddessObjid { get; set; }
 
        bool DefaultAddress { get; set; }
    }
}
