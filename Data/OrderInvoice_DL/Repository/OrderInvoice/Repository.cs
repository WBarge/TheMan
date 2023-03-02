// ***********************************************************************
// Assembly         : OrderInvoice_DL
// Author           : Bill Barge
// Created          : 01-14-2017
//
// Last Modified By : Admin
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="Repository.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_DL.Repository

{
    /// <summary>
    /// This part of the class will hold all methods needed by the order/invoice area of the system
    /// </summary>
    /// <seealso cref="IRepository" />
    public partial class Repository : IRepository
    {
        #region OrderInvoice Methods

        /// <summary>
        /// Gets the order invoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IOrderInvoice.</returns>
        public IOrderInvoice GetOrderInvoice(int id)
        { 
            IOrderInvoice obj = Context.OrderInvoice.Get(id);
            return obj;
        }

        /// <summary>
        /// Gets the OrderInvoices.
        /// </summary>
        /// <returns>IEnumerable&lt;IOrderInvoice&gt;.</returns>
        public IEnumerable<IOrderInvoice> GetOrderInvoices()
        {
            IEnumerable<IOrderInvoice> returnValues = Enumerable.ToList<IOrderInvoice>(Context.OrderInvoice.GetAll());
            return returnValues;
        }

        /// <summary>
        /// Creates the OrderInvoice.
        /// </summary>
        /// <returns>IOrderInvoice.</returns>
        public IOrderInvoice CreateOrderInvoice()
        {
            return Context.OrderInvoice.Create();
        }

        /// <summary>
        /// Inserts the OrderInvoice.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertOrderInvoice(IOrderInvoice newObj)
        {
            Context.OrderInvoice.Insert(newObj);
        }

        /// <summary>
        /// Updates the OrderInvoice.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateOrderInvoice(IOrderInvoice obj)
        {
            Context.OrderInvoice.Update(obj);
        }

        /// <summary>
        /// Deletes the OrderInvoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteOrderInvoice(int id)
        {
            Context.OrderInvoice.Delete(GetOrderInvoice(id));
        }

        #endregion OrderInvoice Methods

        #region OrderItem Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IOrderItem.</returns>
        public IOrderItem GetOrderItem(int id)
        {
            return Context.OrderItem.Get(id);
        }

        /// <summary>
        /// Gets the OrderItems.
        /// </summary>
        /// <returns>IEnumerable&lt;IOrderItem&gt;.</returns>
        public IEnumerable<IOrderItem> GetOrderItems()
        {
            return Enumerable.ToList<IOrderItem>(Context.OrderItem.GetAll());
        }

        /// <summary>
        /// Creates the OrderItem.
        /// </summary>
        /// <returns>IOrderItem.</returns>
        public IOrderItem CreateOrderItem()
        {
            return Context.OrderItem.Create();
        }

        /// <summary>
        /// Inserts the OrderItem.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertOrderItem(IOrderItem newObj)
        {
            Context.OrderItem.Insert(newObj);
        }

        /// <summary>
        /// Updates the OrderItem.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateOrderItem(IOrderItem obj)
        {
            Context.OrderItem.Update(obj);
        }

        /// <summary>
        /// Deletes the OrderItem.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteOrderItem(int id)
        {
            Context.OrderItem.Delete(GetOrderItem(id));
        }

        #endregion OrderItem Methods

        #region CustomItemOption Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemOptions.</returns>
        public ICustomItemOptions GetCustomItemOption(int id)
        {
            return Context.CustomItemOptions.Get(id);
        }

        /// <summary>
        /// Gets the CustomItemOptions.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemOptions&gt;.</returns>
        public IEnumerable<ICustomItemOptions> GetCustomItemOptions()
        {
            return Enumerable.ToList<ICustomItemOptions>(Context.CustomItemOptions.GetAll());
        }

        /// <summary>
        /// Creates the CustomItemOption.
        /// </summary>
        /// <returns>ICustomItemOptions.</returns>
        public ICustomItemOptions CreateCustomItemOption()
        {
            return Context.CustomItemOptions.Create();
        }

        /// <summary>
        /// Inserts the CustomItemOption.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertCustomItemOption(ICustomItemOptions newObj)
        {
            Context.CustomItemOptions.Insert(newObj);
        }

        /// <summary>
        /// Updates the CustomItemOption.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateCustomItemOption(ICustomItemOptions obj)
        {
            Context.CustomItemOptions.Update(obj);
        }

        /// <summary>
        /// Deletes the CustomItemOption.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCustomItemOption(int id)
        {
            Context.CustomItemOptions.Delete(GetCustomItemOption(id));
        }

        #endregion CustomItemOption Methods

        #region CustomItemAttribute Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemAttributes.</returns>
        public ICustomItemAttributes GetCustomItemAttribute(int id)
        {
            return Context.CustomItemAttributes.Get(id);
        }

        /// <summary>
        /// Gets the CustomItemAttributes.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemAttributes&gt;.</returns>
        public IEnumerable<ICustomItemAttributes> GetCustomItemAttributes()
        {
            return Enumerable.ToList<ICustomItemAttributes>(Context.CustomItemAttributes.GetAll());
        }

        /// <summary>
        /// Creates the CustomItemAttribute.
        /// </summary>
        /// <returns>ICustomItemAttributes.</returns>
        public ICustomItemAttributes CreateCustomItemAttribute()
        {
            return Context.CustomItemAttributes.Create();
        }

        /// <summary>
        /// Inserts the CustomItemAttribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertCustomItemAttribute(ICustomItemAttributes newObj)
        {
            Context.CustomItemAttributes.Insert(newObj);
        }

        /// <summary>
        /// Updates the CustomItemAttribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateCustomItemAttribute(ICustomItemAttributes obj)
        {
            Context.CustomItemAttributes.Update(obj);
        }

        /// <summary>
        /// Deletes the CustomItemAttribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCustomItemAttribute(int id)
        {
            Context.CustomItemAttributes.Delete(GetCustomItemAttribute(id));
        }

        #endregion CustomItemAttribute Methods

        #region CustomItemOptionAttribute Methods

        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomItemOptionAttributes.</returns>
        public ICustomItemOptionAttributes GetCustomItemOptionAttribute(int id)
        {
            return Context.CustomItemOptionAttributes.Get(id);
        }

        /// <summary>
        /// Gets the CustomItemOptionAttributes.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomItemOptionAttributes&gt;.</returns>
        public IEnumerable<ICustomItemOptionAttributes> GetCustomItemOptionAttributes()
        {
            return Enumerable.ToList<ICustomItemOptionAttributes>(Context.CustomItemOptionAttributes.GetAll());
        }

        /// <summary>
        /// Creates the CustomItemOptionAttribute.
        /// </summary>
        /// <returns>ICustomItemOptionAttributes.</returns>
        public ICustomItemOptionAttributes CreateCustomItemOptionAttribute()
        {
            return Context.CustomItemOptionAttributes.Create();
        }

        /// <summary>
        /// Inserts the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertCustomItemOptionAttribute(ICustomItemOptionAttributes newObj)
        {
            Context.CustomItemOptionAttributes.Insert(newObj);
        }

        /// <summary>
        /// Updates the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateCustomItemOptionAttribute(ICustomItemOptionAttributes obj)
        {
            Context.CustomItemOptionAttributes.Update(obj);
        }

        /// <summary>
        /// Deletes the CustomItemOptionAttribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCustomItemOptionAttribute(int id)
        {
            Context.CustomItemOptionAttributes.Delete(GetCustomItemOptionAttribute(id));
        }

        #endregion CustomItemOptionAttribute Methods

    }
}
