using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a EMailAddresses.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("EMailAddresses")]
    public class EMailAddresses : IEMailAddresses 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int ContactObjid { get; set; }
 
		
		
        public string Address { get; set; }
 
		
		
        public bool DefaultAddress { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
