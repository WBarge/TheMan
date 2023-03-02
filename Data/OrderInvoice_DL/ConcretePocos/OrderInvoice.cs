
using System;
using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a OrderInvoice.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("OrderInvoice")]
    public class OrderInvoice : IOrderInvoice 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int CustomerObjid { get; set; }
 
		
		
        public int? EmployeeObjid { get; set; }
 
		
		
        public Int64 OrderNumber { get; set; }
 
		
		
        public string ShippingAddressLine1 { get; set; }
 
		
		
        public string ShippingAddressLine2 { get; set; }
 
		
		
        public string ShippingCity { get; set; }
 
		
		
        public string ShippingStateName { get; set; }
 
		
		
        public string ShippingCountryName { get; set; }
 
		
		
        public string Shippingzip { get; set; }
 
		
		
        public string InvoiceAddressLine1 { get; set; }
 
		
		
        public string InvoiceAddressLine2 { get; set; }
 
		
		
        public string InvoiceCity { get; set; }
 
		
		
        public string InvoiceStateName { get; set; }
 
		
		
        public string InvoiceCountryName { get; set; }
 
		
		
        public string Invoicezip { get; set; }
 
		
		
        public decimal SubTotal { get; set; }
 
		
		
        public decimal TaxRate { get; set; }
 
		
		
        public decimal TaxAmount { get; set; }
 
		
		
        public decimal Total { get; set; }
 
		
		
        public string Note { get; set; }
    }
}
