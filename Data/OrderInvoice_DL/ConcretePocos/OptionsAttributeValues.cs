using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a OptionsAttributeValues.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("OptionsAttributeValues")]
    public class OptionsAttributeValues : IOptionsAttributeValues 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Value { get; set; }
 
		
		
        public string Description { get; set; }
 
		
		
        public bool DefaultValue { get; set; }
 
		
		
        public bool Deleted { get; set; }
 
		
		
        public int OptionsAttributesObjid { get; set; }
    }
}
