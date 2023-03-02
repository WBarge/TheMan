namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PhoneNumbers.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPhoneNumbers 
    {
        int Objid { get; set; }
 
        int NumberTypeObjid { get; set; }
 
        string Number { get; set; }
 
        string CountryCode { get; set; }
 
        bool Deleted { get; set; }
    }
}
