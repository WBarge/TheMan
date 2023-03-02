
using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a ProductPrice.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IProductPrice 
    {
        int Objid { get; set; }
 
        int ProductObjid { get; set; }
 
        decimal? FlatPrice { get; set; }
 
        string FormulaPrice { get; set; }
 
        DateTime? StartDate { get; set; }
 
        DateTime? EndDate { get; set; }
 
        bool? Deleted { get; set; }
    }
}
