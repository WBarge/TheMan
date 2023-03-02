using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Country.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Country")]
    public class Country : ICountry 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Name { get; set; }
 
		
		
        public string Abrv { get; set; }
    }
}
