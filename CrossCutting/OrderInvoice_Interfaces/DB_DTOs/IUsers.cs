namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a Users.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IUsers 
    {
        int Objid { get; set; }
 
        string Username { get; set; }
 
        string Password { get; set; }
 
        bool Active { get; set; }
    }
}
