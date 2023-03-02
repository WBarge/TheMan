// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IOptionsAttributeValues.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a OptionsAttributeValues.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IOptionsAttributeValues 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        string Value { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [default value].
        /// </summary>
        /// <value><c>true</c> if [default value]; otherwise, <c>false</c>.</value>
        bool DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IOptionsAttributeValues"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the options attributes objid.
        /// </summary>
        /// <value>The options attributes objid.</value>
        int OptionsAttributesObjid { get; set; }
    }
}
