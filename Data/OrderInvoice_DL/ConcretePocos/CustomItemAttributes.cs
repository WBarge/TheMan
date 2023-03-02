using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a CustomItemAttributes.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("CustomItemAttributes")]
    public class CustomItemAttributes : ICustomItemAttributes 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int OrderItemObjid { get; set; }
 
		
		
        public int AttributeObjid { get; set; }
 
		
		
        public string Value { get; set; }
    }
}
