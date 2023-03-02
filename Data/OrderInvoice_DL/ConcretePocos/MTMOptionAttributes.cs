using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMOptionAttributes.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMOptionAttributes")]
    public class MtmOptionAttributes : IMtmOptionAttributes 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int MtmOptionObjid { get; set; }
 
		
		
        public int AttributeObjid { get; set; }
    }
}
