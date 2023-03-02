// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces
{

    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
	{
        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        /// <value>The application configuration.</value>
        IGenericRepository<IApplicationConfiguration> ApplicationConfiguration { get; }
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        IGenericRepository<IAttributes> Attributes { get; }
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        IGenericRepository<IContacts> Contacts { get; }
        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>The country.</value>
        IGenericRepository<ICountry> Country { get; }
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <value>The customers.</value>
        IGenericRepository<ICustomers> Customers { get; }
        /// <summary>
        /// Gets the custom item attributes.
        /// </summary>
        /// <value>The custom item attributes.</value>
        IGenericRepository<ICustomItemAttributes> CustomItemAttributes { get; }
        /// <summary>
        /// Gets the custom item option attributes.
        /// </summary>
        /// <value>The custom item option attributes.</value>
        IGenericRepository<ICustomItemOptionAttributes> CustomItemOptionAttributes { get; }
        /// <summary>
        /// Gets the custom item options.
        /// </summary>
        /// <value>The custom item options.</value>
        IGenericRepository<ICustomItemOptions> CustomItemOptions { get; }
        /// <summary>
        /// Gets the e mail addresses.
        /// </summary>
        /// <value>The e mail addresses.</value>
        IGenericRepository<IEMailAddresses> EMailAddresses { get; }
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <value>The employees.</value>
        IGenericRepository<IEmployees> Employees { get; }
        /// <summary>
        /// Gets the MTM option attributes.
        /// </summary>
        /// <value>The MTM option attributes.</value>
        IGenericRepository<IMtmOptionAttributes> MtmOptionAttributes { get; }
        /// <summary>
        /// Gets the MTM options.
        /// </summary>
        /// <value>The MTM options.</value>
        IGenericRepository<IMtmOptions> MtmOptions { get; }
        /// <summary>
        /// Gets the MTM phone.
        /// </summary>
        /// <value>The MTM phone.</value>
        IGenericRepository<IMtmPhone> MtmPhone { get; }
        /// <summary>
        /// Gets the MTM product attributes.
        /// </summary>
        /// <value>The MTM product attributes.</value>
        IGenericRepository<IMtmProductAttributes> MtmProductAttributes { get; }
        /// <summary>
        /// Gets the MTM snail mail.
        /// </summary>
        /// <value>The MTM snail mail.</value>
        IGenericRepository<IMtmSnailMail> MtmSnailMail { get; }
        /// <summary>
        /// Gets the MTM user roles.
        /// </summary>
        /// <value>The MTM user roles.</value>
        IGenericRepository<IMtmUserRoles> MtmUserRoles { get; }
        /// <summary>
        /// Gets the option price.
        /// </summary>
        /// <value>The option price.</value>
        IGenericRepository<IOptionPrice> OptionPrice { get; }
        /// <summary>
        /// Gets the options attribute values.
        /// </summary>
        /// <value>The options attribute values.</value>
        IGenericRepository<IOptionsAttributeValues> OptionsAttributeValues { get; }
        /// <summary>
        /// Gets the order invoice.
        /// </summary>
        /// <value>The order invoice.</value>
        IGenericRepository<IOrderInvoice> OrderInvoice { get; }
        /// <summary>
        /// Gets the order item.
        /// </summary>
        /// <value>The order item.</value>
        IGenericRepository<IOrderItem> OrderItem { get; }
        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <value>The phone numbers.</value>
        IGenericRepository<IPhoneNumbers> PhoneNumbers { get; }
        /// <summary>
        /// Gets the type of the phone number.
        /// </summary>
        /// <value>The type of the phone number.</value>
        IGenericRepository<IPhoneNumberType> PhoneNumberType { get; }
        /// <summary>
        /// Gets the predefined option detail.
        /// </summary>
        /// <value>The predefined option detail.</value>
        IGenericRepository<IPredefinedOptionDetail> PredefinedOptionDetail { get; }
        /// <summary>
        /// Gets the predefined options.
        /// </summary>
        /// <value>The predefined options.</value>
        IGenericRepository<IPredefinedOptions> PredefinedOptions { get; }
        /// <summary>
        /// Gets the predefined product detail.
        /// </summary>
        /// <value>The predefined product detail.</value>
        IGenericRepository<IPredefinedProductDetail> PredefinedProductDetail { get; }
        /// <summary>
        /// Gets the predefined products.
        /// </summary>
        /// <value>The predefined products.</value>
        IGenericRepository<IPredefinedProducts> PredefinedProducts { get; }
        /// <summary>
        /// Gets the product attribute values.
        /// </summary>
        /// <value>The product attribute values.</value>
        IGenericRepository<IProductAttributeValues> ProductAttributeValues { get; }
        /// <summary>
        /// Gets the product options.
        /// </summary>
        /// <value>The product options.</value>
        IGenericRepository<IProductOptions> ProductOptions { get; }
        /// <summary>
        /// Gets the product price.
        /// </summary>
        /// <value>The product price.</value>
        IGenericRepository<IProductPrice> ProductPrice { get; }
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        IGenericRepository<IProducts> Products { get; }
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        IGenericRepository<IRoles> Roles { get; }
        /// <summary>
        /// Gets the snail mail addresses.
        /// </summary>
        /// <value>The snail mail addresses.</value>
        IGenericRepository<ISnailMailAddresses> SnailMailAddresses { get; }
        /// <summary>
        /// Gets the type of the snail mail.
        /// </summary>
        /// <value>The type of the snail mail.</value>
        IGenericRepository<ISnailMailType> SnailMailType { get; }
        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <value>The states.</value>
        IGenericRepository<IStates> States { get; }
        /// <summary>
        /// Gets the system keys.
        /// </summary>
        /// <value>The system keys.</value>
        IGenericRepository<ISystemKeys> SystemKeys { get; }
        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <value>The uploaded files.</value>
        IGenericRepository<IUploadedFiles> UploadedFiles { get; }
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>The users.</value>
        IGenericRepository<IUsers> Users { get; }
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
	}
}