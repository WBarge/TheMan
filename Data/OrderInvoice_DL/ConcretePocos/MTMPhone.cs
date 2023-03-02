using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMPhone.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMPhone")]
    public class MtmPhone : IMtmPhone 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int ContactObjid { get; set; }
 
		
		
        public int PhoneNumberObjid { get; set; }
 
		
		
        public bool DefaultNumber { get; set; }
    }
}
