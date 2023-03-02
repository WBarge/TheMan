using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a States.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("States")]
    public class States : IStates 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string Name { get; set; }
 
		
		
        public string Abrv { get; set; }
    }
}
