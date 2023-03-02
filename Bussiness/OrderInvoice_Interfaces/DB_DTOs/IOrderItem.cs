// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IOrderItem.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OrderItem.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOrderItem 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the order invoice objid.
        /// </summary>
        /// <value>The order invoice objid.</value>
        int OrderInvoiceObjid { get; set; }

        /// <summary>
        /// Gets or sets the predefined product objid.
        /// </summary>
        /// <value>The predefined product objid.</value>
        int? PredefinedProductObjid { get; set; }

        /// <summary>
        /// Gets or sets the product objid.
        /// </summary>
        /// <value>The product objid.</value>
        int? ProductObjid { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        string Note { get; set; }
    }
}
