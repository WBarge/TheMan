
using System;
using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a OptionPrice.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("OptionPrice")]
    public class OptionPrice : IOptionPrice 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int OptionObjid { get; set; }
 
		
		
        public decimal? FlatPrice { get; set; }
 
		
        public DateTime? StartDate { get; set; }
 
		
		
        public DateTime? EndDate { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
