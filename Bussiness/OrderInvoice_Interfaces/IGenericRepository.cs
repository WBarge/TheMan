// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IGenericRepository.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;

namespace OrderInvoice_Interfaces
{
    /// <summary>
    /// Interface IGenericRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>T.</returns>
        T Create();
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T Get(int id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetPaged(int pageNumber, int itemsPerPage);
        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Insert(T obj);
        /// <summary>
        /// Inserts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        void Insert(IEnumerable<T> list);
        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Update(T obj);
        /// <summary>
        /// Updates the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        void Update(IEnumerable<T> list);
        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Delete(T obj);
        /// <summary>
        /// Deletes the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        void Delete(IEnumerable<T> list);
    }
}