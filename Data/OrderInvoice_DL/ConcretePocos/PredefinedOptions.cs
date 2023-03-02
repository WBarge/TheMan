using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PredefinedOptions.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PredefinedOptions")]
    public class PredefinedOptions : IPredefinedOptions 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int PredefinedProductObjid { get; set; }
 
		
		
        public int OptionObjid { get; set; }
 
		
		
        public string MarketDescription { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
