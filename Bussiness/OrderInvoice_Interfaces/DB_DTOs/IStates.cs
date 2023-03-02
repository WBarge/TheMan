// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IStates.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a States.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IStates 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the abrv.
        /// </summary>
        /// <value>The abrv.</value>
        string Abrv { get; set; }
    }
}
