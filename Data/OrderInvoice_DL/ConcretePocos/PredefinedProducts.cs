using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PredefinedProducts.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PredefinedProducts")]
    public class PredefinedProducts : IPredefinedProducts 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
		
        public int ProductObjid { get; set; }
		
        public decimal Price { get; set; }
		
        public string MarketDescription { get; set; }
		
        public bool Deleted { get; set; }

        public int Quantity { get; set; }

    }
}
