using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a PredefinedOptionDetail.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("PredefinedOptionDetail")]
    public class PredefinedOptionDetail : IPredefinedOptionDetail 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int PredefinedOptionObjid { get; set; }
 
		
		
        public int AttribuiteObjid { get; set; }
 
		
		
        public string Value { get; set; }
 
		
		
        public bool Deleted { get; set; }
    }
}
