using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a SnailMailAddresses.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("SnailMailAddresses")]
    public class SnailMailAddresses : ISnailMailAddresses 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Line1 { get; set; }
 
		
		
        public string Line2 { get; set; }
 
		
		
        public string City { get; set; }
 
		
		
        public int StateObjId { get; set; }
 
		
		
        public int CountryObjid { get; set; }
 
		
		
        public string Zip { get; set; }
 
		
		
        public int SnailMailTypeObjid { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
