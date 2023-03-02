// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IMTMPhone.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.DB_DTOs
{
    /// <summary>
    /// Represents a MTMPhone.
    /// NOTE: This interface is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public interface IMtmPhone 
    {
        /// <summary>
        /// Gets or sets the objid.
        /// </summary>
        /// <value>The objid.</value>
        int Objid { get; set; }

        /// <summary>
        /// Gets or sets the contact objid.
        /// </summary>
        /// <value>The contact objid.</value>
        int ContactObjid { get; set; }

        /// <summary>
        /// Gets or sets the phone number objid.
        /// </summary>
        /// <value>The phone number objid.</value>
        int PhoneNumberObjid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [default number].
        /// </summary>
        /// <value><c>true</c> if [default number]; otherwise, <c>false</c>.</value>
        bool DefaultNumber { get; set; }
    }
}
