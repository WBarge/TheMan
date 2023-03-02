using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Contacts.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Contacts")]
    public class Contacts : IContacts 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string FirstName { get; set; }
 
		
		
        public string LastName { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
