namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a MTMPhone.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IMtmPhone 
    {
        int Objid { get; set; }
 
        int ContactObjid { get; set; }
 
        int PhoneNumberObjid { get; set; }
 
        bool DefaultNumber { get; set; }
    }
}
