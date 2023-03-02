
using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a Customers.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomers 
    {
        int Objid { get; set; }
 
        int Number { get; set; }
 
        bool ShippingIsSameAsBilling { get; set; }
    }
}
