// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IRepository.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    public partial interface IRepository
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}
