using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a MTMUserRoles.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("MTMUserRoles")]
    public class MtmUserRoles : IMtmUserRoles 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int UserObjid { get; set; }
 
		
		
        public int RoleObjid { get; set; }
    }
}
