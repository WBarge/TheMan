using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PhoneNumberType.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PhoneNumberType")]
    public class PhoneNumberType : IPhoneNumberType 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string PhoneNumbertype { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
