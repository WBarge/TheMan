using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Users.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Users")]
    public class Users : IUsers 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Username { get; set; }
 
		
		
        public string Password { get; set; }
 
		
		
        public bool Active { get; set; }
    }
}
