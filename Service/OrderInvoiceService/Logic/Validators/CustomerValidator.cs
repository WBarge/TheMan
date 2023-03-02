// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="CustomerValidator.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Exceptions;
using OrderInvoiceService.Models.API;
using Utilites;

namespace OrderInvoiceService.Logic.Validators
{
    /// <summary>
    /// Class CustomerValidator.
    /// Contains methods to validate customer data
    /// </summary>
    public class CustomerValidator
    {
        /// <summary>
        /// Validates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="RequiredFieldException">First Name is required
        /// or
        /// Last Name is required
        /// or
        /// User Name is required
        /// or
        /// Billing address is required
        /// or
        /// Shipping address is required
        /// or
        /// Email address is required
        /// or
        /// Phone Number is required
        /// or
        /// Number Type is required</exception>
        /// <exception cref="Exception">Fatal System Error- The customer number has to be numeric</exception>
        public static void ValidateCustomer(CustomerModel customer)
        {
            if (customer.FirstName.IsEmpty())    
                throw new RequiredFieldException("First Name is required");
            if (customer.LastName.IsEmpty())
                throw new RequiredFieldException("Last Name is required");
            if (customer.Id.IsNotEmpty()  && !customer.CustomerNumber.IsNumeric())
                throw new Exception("Fatal System Error- The customer number has to be numeric");
            if (customer.UserName.IsEmpty())
                throw new RequiredFieldException("User Name is required");
            if (customer.BillingAddress.IsEmpty())
                throw new RequiredFieldException("Billing address is required");
            ValidateAddress(customer.BillingAddress,"Billing");
            if (!customer.ShippingIsSameAsBilling)
            {
                if (customer.ShippingAddress.IsEmpty())
                    throw new RequiredFieldException("Shipping address is required");
                ValidateAddress(customer.ShippingAddress,"Shipping");
            }
            if (customer.Email.IsEmpty())
                throw new RequiredFieldException("Email address is required");
            if (customer.PhoneNumber.IsEmpty())
                throw new RequiredFieldException("Phone Number is required");
            if (customer.PhoneNumberTypeValue.IsEmpty())
                throw new RequiredFieldException("Number Type is required");

        }

        /// <summary>
        /// Validates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="addressQualifier">The address qualifier.</param>
        /// <exception cref="RequiredFieldException">
        /// </exception>
        public static void ValidateAddress(AddressModel address,string addressQualifier)
        {
            if (address.Address1.IsEmpty())
                throw new RequiredFieldException( $" {addressQualifier} Address line 1 is required");
            if (address.City.IsEmpty())
                throw new RequiredFieldException($" {addressQualifier} City is required");
            if (address.StateValue.IsEmpty())
                throw new RequiredFieldException($" {addressQualifier} State is required");
            if (address.Zip.IsEmpty())
                throw new RequiredFieldException($" {addressQualifier} Zip is required");
        }
    }
}
