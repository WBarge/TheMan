using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a CustomItemOptions.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("CustomItemOptions")]
    public class CustomItemOptions : ICustomItemOptions 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int OrderItemObjid { get; set; }
 
		
		
        public int ProductOptionObjid { get; set; }
 
		
		
        public string Note { get; set; }
    }
}
