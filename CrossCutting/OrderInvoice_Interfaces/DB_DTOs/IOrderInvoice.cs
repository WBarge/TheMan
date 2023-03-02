
using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OrderInvoice.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOrderInvoice 
    {
        int Objid { get; set; }
 
        int CustomerObjid { get; set; }
 
        int? EmployeeObjid { get; set; }
 
        Int64 OrderNumber { get; set; }
 
        string ShippingAddressLine1 { get; set; }
 
        string ShippingAddressLine2 { get; set; }
 
        string ShippingCity { get; set; }
 
        string ShippingStateName { get; set; }
 
        string ShippingCountryName { get; set; }
 
        string Shippingzip { get; set; }
 
        string InvoiceAddressLine1 { get; set; }
 
        string InvoiceAddressLine2 { get; set; }
 
        string InvoiceCity { get; set; }
 
        string InvoiceStateName { get; set; }
 
        string InvoiceCountryName { get; set; }
 
        string Invoicezip { get; set; }
 
        decimal SubTotal { get; set; }
 
        decimal TaxRate { get; set; }
 
        decimal TaxAmount { get; set; }
 
        decimal Total { get; set; }
 
        string Note { get; set; }
    }
}
