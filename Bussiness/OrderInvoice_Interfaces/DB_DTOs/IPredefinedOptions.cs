// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IPredefinedOptions.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a PredefinedOptions.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IPredefinedOptions 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the predefined product objid.
        /// </summary>
        /// <value>The predefined product objid.</value>
        int PredefinedProductObjid { get; set; }

        /// <summary>
        /// Gets or sets the option objid.
        /// </summary>
        /// <value>The option objid.</value>
        int OptionObjid { get; set; }

        /// <summary>
        /// Gets or sets the market description.
        /// </summary>
        /// <value>The market description.</value>
        string MarketDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IPredefinedOptions"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        bool Deleted { get; set; }
    }
}
