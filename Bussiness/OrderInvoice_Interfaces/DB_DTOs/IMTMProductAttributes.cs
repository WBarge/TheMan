// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IMTMProductAttributes.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a MTMProductAttributes.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IMtmProductAttributes 
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
        /// Gets or sets the attribute objid.
        /// </summary>
        /// <value>The attribute objid.</value>
        int AttributeObjid { get; set; }
    }
}
