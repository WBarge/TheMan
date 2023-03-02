
using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OptionPrice.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOptionPrice 
    {
        int Objid { get; set; }
 
        int OptionObjid { get; set; }
 
        decimal? FlatPrice { get; set; }
 
        DateTime? StartDate { get; set; }
 
        DateTime? EndDate { get; set; }
 
        bool Deleted { get; set; }
    }
}
