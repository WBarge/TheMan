using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    public partial interface IRepository
    {
        #region OrderInvoice Methods

        /// <summary>
        /// Gets the order invoice.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IOrderInvoice GetOrderInvoice(int id);
        /// <summary>
        /// Gets the OrderInvoices.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IOrderInvoice> GetOrderInvoices();
        /// <summary>
        /// Creates the OrderInvoice.
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        IOrderItem GetOrderItem(int id);
        /// <summary>
        /// Gets the OrderItems.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IOrderItem> GetOrderItems();
        /// <summary>
        /// Creates the OrderItem.
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        ICustomItemOptions GetCustomItemOption(int id);
        /// <summary>
        /// Gets the CustomItemOptions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICustomItemOptions> GetCustomItemOptions();
        /// <summary>
        /// Creates the CustomItemOption.
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        ICustomItemAttributes GetCustomItemAttribute(int id);
        /// <summary>
        /// Gets the CustomItemAttributes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICustomItemAttributes> GetCustomItemAttributes();
        /// <summary>
        /// Creates the CustomItemAttribute.
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        ICustomItemOptionAttributes GetCustomItemOptionAttribute(int id);
        /// <summary>
        /// Gets the CustomItemOptionAttributes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICustomItemOptionAttributes> GetCustomItemOptionAttributes();
        /// <summary>
        /// Creates the CustomItemOptionAttribute.
        /// </summary>
        /// <returns></returns>
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
