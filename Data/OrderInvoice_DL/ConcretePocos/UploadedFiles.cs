using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a UploadedFiles.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("UploadedFiles")]
    public class UploadedFiles : IUploadedFiles 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public string FileName { get; set; }
 
		
		
        public byte[] FileContents { get; set; }
 
		
		
        public string LocationType { get; set; }
    }
}
