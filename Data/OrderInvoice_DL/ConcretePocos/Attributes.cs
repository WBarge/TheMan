using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Attributes.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Attributes")]
    public class Attributes : IAttributes 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Name { get; set; }
 
		
		
        public string Description { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
