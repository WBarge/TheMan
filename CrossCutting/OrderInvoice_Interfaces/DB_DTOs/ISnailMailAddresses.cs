namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a SnailMailAddresses.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ISnailMailAddresses 
    {
        int Objid { get; set; }
 
        string Line1 { get; set; }
 
        string Line2 { get; set; }
 
        string City { get; set; }
 
        int StateObjId { get; set; }
 
        int CountryObjid { get; set; }
 
        string Zip { get; set; }
 
        int SnailMailTypeObjid { get; set; }
 
        bool Deleted { get; set; }
    }
}
