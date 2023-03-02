using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMProductAttributes.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMProductAttributes")]
    public class MtmProductAttributes : IMtmProductAttributes 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int ProductObjid { get; set; }
 
		
		
        public int AttributeObjid { get; set; }
    }
}
