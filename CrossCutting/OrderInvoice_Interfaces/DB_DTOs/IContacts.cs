namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a Contacts.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IContacts 
    {
        int Objid { get; set; }
 
        string FirstName { get; set; }
 
        string LastName { get; set; }
 
        bool Deleted { get; set; }
    }
}
