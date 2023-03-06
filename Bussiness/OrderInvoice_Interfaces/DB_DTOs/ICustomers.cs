// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="ICustomers.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a Customers.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomers 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [shipping is same as billing].
        /// </summary>
        /// <value><c>true</c> if [shipping is same as billing]; otherwise, <c>false</c>.</value>
        bool ShippingIsSameAsBilling { get; set; }
    }
}
