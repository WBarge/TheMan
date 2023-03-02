// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IOrderInvoice.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OrderInvoice.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOrderInvoice 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the customer objid.
        /// </summary>
        /// <value>The customer objid.</value>
        int CustomerObjid { get; set; }

        /// <summary>
        /// Gets or sets the employee objid.
        /// </summary>
        /// <value>The employee objid.</value>
        int? EmployeeObjid { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>The order number.</value>
        Int64 OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the shipping address line1.
        /// </summary>
        /// <value>The shipping address line1.</value>
        string ShippingAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the shipping address line2.
        /// </summary>
        /// <value>The shipping address line2.</value>
        string ShippingAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the shipping city.
        /// </summary>
        /// <value>The shipping city.</value>
        string ShippingCity { get; set; }

        /// <summary>
        /// Gets or sets the name of the shipping state.
        /// </summary>
        /// <value>The name of the shipping state.</value>
        string ShippingStateName { get; set; }

        /// <summary>
        /// Gets or sets the name of the shipping country.
        /// </summary>
        /// <value>The name of the shipping country.</value>
        string ShippingCountryName { get; set; }

        /// <summary>
        /// Gets or sets the shippingzip.
        /// </summary>
        /// <value>The shippingzip.</value>
        string Shippingzip { get; set; }

        /// <summary>
        /// Gets or sets the invoice address line1.
        /// </summary>
        /// <value>The invoice address line1.</value>
        string InvoiceAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the invoice address line2.
        /// </summary>
        /// <value>The invoice address line2.</value>
        string InvoiceAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the invoice city.
        /// </summary>
        /// <value>The invoice city.</value>
        string InvoiceCity { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice state.
        /// </summary>
        /// <value>The name of the invoice state.</value>
        string InvoiceStateName { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice country.
        /// </summary>
        /// <value>The name of the invoice country.</value>
        string InvoiceCountryName { get; set; }

        /// <summary>
        /// Gets or sets the invoicezip.
        /// </summary>
        /// <value>The invoicezip.</value>
        string Invoicezip { get; set; }

        /// <summary>
        /// Gets or sets the sub total.
        /// </summary>
        /// <value>The sub total.</value>
        decimal SubTotal { get; set; }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>The tax rate.</value>
        decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>The tax amount.</value>
        decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        string Note { get; set; }
    }
}
