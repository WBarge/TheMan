using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a SystemKeys.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("SystemKeys")]
    public class SystemKeys : ISystemKeys 
    {

        [Key]
        [Required]
        public string TableName { get; set; }
        public int LatestKey { get; set; }
    }
}
