namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PredefinedOptions.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPredefinedOptions 
    {
        int Objid { get; set; }
 
        int PredefinedProductObjid { get; set; }
 
        int OptionObjid { get; set; }
 
        string MarketDescription { get; set; }
 
        bool Deleted { get; set; }
    }
}
