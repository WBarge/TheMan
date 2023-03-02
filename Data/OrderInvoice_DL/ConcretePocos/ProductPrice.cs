
using System;
using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a ProductPrice.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("ProductPrice")]
    public class ProductPrice : IProductPrice 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int ProductObjid { get; set; }
 
		
		
        public decimal? FlatPrice { get; set; }
 
		
		
        public string FormulaPrice { get; set; }
 
		
		
        public DateTime? StartDate { get; set; }
 
		
		
        public DateTime? EndDate { get; set; }
 
		
		
        public bool? Deleted { get; set; }
    }
}
