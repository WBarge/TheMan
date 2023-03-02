using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMSnailMail.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMSnailMail")]
    public class MtmSnailMail : IMtmSnailMail 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int ContactObjid { get; set; }
 
		
		
        public int SnailMailAddessObjid { get; set; }
 
		
		
        public bool DefaultAddress { get; set; }
    }
}
