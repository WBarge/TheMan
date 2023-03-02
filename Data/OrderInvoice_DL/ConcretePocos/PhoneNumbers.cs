using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PhoneNumbers.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PhoneNumbers")]
    public class PhoneNumbers : IPhoneNumbers 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int NumberTypeObjid { get; set; }
 
		
		
        public string Number { get; set; }
 
		
		
        public string CountryCode { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
