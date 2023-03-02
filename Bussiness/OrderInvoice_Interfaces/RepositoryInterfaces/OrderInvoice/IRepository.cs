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
using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    public partial interface IRepository
    {
        #region OrderInvoice Methods

        /// <summary>
        /// Gets the order invoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IOrderInvoice.</returns>
        IOrderInvoice GetOrderInvoice(int id);
        /// <summary>
        /// Gets the OrderInvoices.
        /// </summary>
        /// <returns>IEnumerable&lt;IOrderInvoice&gt;.</returns>
        IEnumerable<IOrderInvoice> GetOrderInvoices();
        /// <summary>
        /// Creates the OrderInvoice.
        /// </summary>
        /// <returns>IOrderInvoice.</returns>
        IOrderInvoice CreateOrderInvoice();
        /// <summary>
        /// Inserts the OrderInvoice.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertOrderInvoice(IOrderInvoice newObj);
        /// <summary>
        /// Updates the OrderInvoice.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateOrderInvoice(IOrderInvoice obj);
        /// <summary>
        /// Deletes the OrderInvoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteOrderInvoice(int id);

        #endregion OrderInvoice Methods

        #region OrderItem Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IOrderItem.</returns>
        IOrderItem GetOrderItem(int id);
        /// <summary>
        /// Gets the OrderItems.
        /// </summary>
        /// <returns>IEnumerable&lt;IOrderItem&gt;.</returns>
        IEnumerable<IOrderItem> GetOrderItems();
        /// <summary>
        /// Creates the OrderItem.
        /// </summary>
        /// <returns>IOrderItem.</returns>
        IOrderItem CreateOrderItem();
        /// <summary>
        /// Inserts the OrderItem.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertOrderItem(IOrderItem newObj);
        /// <summary>
        /// Updates the OrderItem.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateOrderItem(IOrderItem obj);
        /// <summary>
        /// Deletes the OrderItem.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteOrderItem(int id);

        #endregion OrderItem Methods

        #region CustomItemOption Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemOptions.</returns>
        ICustomItemOptions GetCustomItemOption(int id);
        /// <summary>
        /// Gets the CustomItemOptions.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemOptions&gt;.</returns>
        IEnumerable<ICustomItemOptions> GetCustomItemOptions();
        /// <summary>
        /// Creates the CustomItemOption.
        /// </summary>
        /// <returns>ICustomItemOptions.</returns>
        ICustomItemOptions CreateCustomItemOption();
        /// <summary>
        /// Inserts the CustomItemOption.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertCustomItemOption(ICustomItemOptions newObj);
        /// <summary>
        /// Updates the CustomItemOption.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateCustomItemOption(ICustomItemOptions obj);
        /// <summary>
        /// Deletes the CustomItemOption.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCustomItemOption(int id);

        #endregion CustomItemOption Methods

        #region CustomItemAttribute Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemAttributes.</returns>
        ICustomItemAttributes GetCustomItemAttribute(int id);
        /// <summary>
        /// Gets the CustomItemAttributes.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemAttributes&gt;.</returns>
        IEnumerable<ICustomItemAttributes> GetCustomItemAttributes();
        /// <summary>
        /// Creates the CustomItemAttribute.
        /// </summary>
        /// <returns>ICustomItemAttributes.</returns>
        ICustomItemAttributes CreateCustomItemAttribute();
        /// <summary>
        /// Inserts the CustomItemAttribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertCustomItemAttribute(ICustomItemAttributes newObj);
        /// <summary>
        /// Updates the CustomItemAttribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateCustomItemAttribute(ICustomItemAttributes obj);
        /// <summary>
        /// Deletes the CustomItemAttribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCustomItemAttribute(int id);

        #endregion CustomItemAttribute Methods

        #region CustomItemOptionAttribute Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemOptionAttributes.</returns>
        ICustomItemOptionAttributes GetCustomItemOptionAttribute(int id);
        /// <summary>
        /// Gets the CustomItemOptionAttributes.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemOptionAttributes&gt;.</returns>
        IEnumerable<ICustomItemOptionAttributes> GetCustomItemOptionAttributes();
        /// <summary>
        /// Creates the CustomItemOptionAttribute.
        /// </summary>
        /// <returns>ICustomItemOptionAttributes.</returns>
        ICustomItemOptionAttributes CreateCustomItemOptionAttribute();
        /// <summary>
        /// Inserts the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertCustomItemOptionAttribute(ICustomItemOptionAttributes newObj);
        /// <summary>
        /// Updates the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateCustomItemOptionAttribute(ICustomItemOptionAttributes obj);
        /// <summary>
        /// Deletes the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCustomItemOptionAttribute(int id);

        #endregion CustomItemOptionAttribute Methods

    }
}
