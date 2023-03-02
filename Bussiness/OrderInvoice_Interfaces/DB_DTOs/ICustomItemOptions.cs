// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="ICustomItemOptions.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a CustomItemOptions.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomItemOptions 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the order item objid.
        /// </summary>
        /// <value>The order item objid.</value>
        int OrderItemObjid { get; set; }

        /// <summary>
        /// Gets or sets the product option objid.
        /// </summary>
        /// <value>The product option objid.</value>
        int ProductOptionObjid { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        string Note { get; set; }
    }
}
