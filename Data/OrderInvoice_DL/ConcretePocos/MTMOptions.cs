using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMOptions.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMOptions")]
    public class MtmOptions : IMtmOptions 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int OptionObjid { get; set; }
 
		
		
        public int ProductObjid { get; set; }
    }
}
