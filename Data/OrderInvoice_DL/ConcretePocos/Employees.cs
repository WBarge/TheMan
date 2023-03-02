using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Employees.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Employees")]
    public class Employees : IEmployees 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string BadgeId { get; set; }
    }
}
