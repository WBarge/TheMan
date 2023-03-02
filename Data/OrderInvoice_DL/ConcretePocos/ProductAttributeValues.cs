using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a ProductAttributeValues.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("ProductAttributeValues")]
    public class ProductAttributeValues : IProductAttributeValues 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Value { get; set; }
 
		
		
        public string Description { get; set; }
 
		
		
        public bool DefaultValue { get; set; }
 
		
		
        public bool Deleted { get; set; }
 
		
		
        public int ProductAttributesObjid { get; set; }
    }
}
