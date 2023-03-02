// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="CustomerModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API
{
    /// <summary>
    /// Class CustomerModel.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer number.
        /// </summary>
        /// <value>The customer number.</value>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomerModel"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [shipping is same as billing].
        /// </summary>
        /// <value><c>true</c> if [shipping is same as billing]; otherwise, <c>false</c>.</value>
        public bool ShippingIsSameAsBilling { get; set; }
        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        /// <value>The shipping address.</value>
        public AddressModel ShippingAddress { get; set; }
        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>The billing address.</value>
        public AddressModel BillingAddress { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the phone number type value.
        /// </summary>
        /// <value>The phone number type value.</value>
        public DropDownItemValue PhoneNumberTypeValue { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; set; }
    }
}
