using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a SnailMailType.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("SnailMailType")]
    public class SnailMailType : ISnailMailType 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string AddressType { get; set; }
    }
}
