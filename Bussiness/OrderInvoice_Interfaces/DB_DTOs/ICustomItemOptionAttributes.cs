// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="ICustomItemOptionAttributes.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a CustomItemOptionAttributes.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface ICustomItemOptionAttributes 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the custom item option objid.
        /// </summary>
        /// <value>The custom item option objid.</value>
        int CustomItemOptionObjid { get; set; }

        /// <summary>
        /// Gets or sets the attribute objid.
        /// </summary>
        /// <value>The attribute objid.</value>
        int AttributeObjid { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        string Value { get; set; }
    }
}
