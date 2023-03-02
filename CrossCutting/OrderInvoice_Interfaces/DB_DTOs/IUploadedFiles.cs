namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a UploadedFiles.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IUploadedFiles 
    {
        int Objid { get; set; }
 
        string FileName { get; set; }
 
        byte[] FileContents { get; set; }
 
        string LocationType { get; set; }
    }
}
