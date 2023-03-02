// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="ISnailMailAddresses.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a SnailMailAddresses.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ISnailMailAddresses 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the line1.
        /// </summary>
        /// <value>The line1.</value>
        string Line1 { get; set; }

        /// <summary>
        /// Gets or sets the line2.
        /// </summary>
        /// <value>The line2.</value>
        string Line2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the state object identifier.
        /// </summary>
        /// <value>The state object identifier.</value>
        int StateObjId { get; set; }

        /// <summary>
        /// Gets or sets the country objid.
        /// </summary>
        /// <value>The country objid.</value>
        int CountryObjid { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        string Zip { get; set; }

        /// <summary>
        /// Gets or sets the snail mail type objid.
        /// </summary>
        /// <value>The snail mail type objid.</value>
        int SnailMailTypeObjid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISnailMailAddresses"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        bool Deleted { get; set; }
    }
}
