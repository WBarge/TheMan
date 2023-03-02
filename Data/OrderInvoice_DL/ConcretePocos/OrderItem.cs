using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a OrderItem.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("OrderItem")]
    public class OrderItem : IOrderItem 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int OrderInvoiceObjid { get; set; }
 
		
		
        public int? PredefinedProductObjid { get; set; }
 
		
		
        public int? ProductObjid { get; set; }
 
		
		
        public decimal Price { get; set; }
 
		
		
        public string Note { get; set; }
    }
}
