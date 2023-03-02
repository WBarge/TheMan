// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IProductPrice.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a ProductPrice.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IProductPrice 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the product objid.
        /// </summary>
        /// <value>The product objid.</value>
        int ProductObjid { get; set; }

        /// <summary>
        /// Gets or sets the flat price.
        /// </summary>
        /// <value>The flat price.</value>
        decimal? FlatPrice { get; set; }

        /// <summary>
        /// Gets or sets the formula price.
        /// </summary>
        /// <value>The formula price.</value>
        string FormulaPrice { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IProductPrice"/> is deleted.
        /// </summary>
        /// <value><c>null</c> if [deleted] contains no value, <c>true</c> if [deleted]; otherwise, <c>false</c>.</value>
        bool? Deleted { get; set; }
    }
}
