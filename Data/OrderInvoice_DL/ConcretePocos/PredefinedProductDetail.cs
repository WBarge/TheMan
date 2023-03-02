using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PredefinedProductDetail.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PredefinedProductDetail")]
    public class PredefinedProductDetail : IPredefinedProductDetail 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int PredefinedProductObjid { get; set; }
 
		
		
        public int AttributeObjid { get; set; }
 
		
		
        public string Value { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
