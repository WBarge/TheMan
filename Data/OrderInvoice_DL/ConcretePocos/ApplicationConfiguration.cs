using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a ApplicationConfiguration.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("ApplicationConfiguration")]
    public class ApplicationConfiguration : IApplicationConfiguration 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Type { get; set; }
 
		
		
        public string Configuration { get; set; }
    }
}
