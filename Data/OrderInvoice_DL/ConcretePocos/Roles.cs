using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Roles.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Roles")]
    public class Roles : IRoles 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string RoleName { get; set; }
    }
}
