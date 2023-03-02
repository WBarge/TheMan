// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="CustomerController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using Exceptions;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Logic.Validators;
using OrderInvoiceService.Models.API;
using Utilites;

namespace OrderInvoiceService.Controllers.Customer
{
    /// <summary>
    /// Class CustomerController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public CustomerController( IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// saves the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Task.</returns>
        /// <exception cref="DataException">The customer Id is invalid
        /// or
        /// The customer Id is invalid
        /// or
        /// The customer Id is invalid</exception>
        [HttpPost]
        public ActionResult SetCustomer([FromBody] CustomerModel customer)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(customer);
            CustomerValidator.ValidateCustomer(customer);
            OrderInvoice_BL.People.Customer cust;
            if (customer.Id.IsEmpty())
            {
                cust = new OrderInvoice_BL.People.Customer(this._repository)
                {
                    Password = Constants.DefaultPassword,
                    Number = CustomerHelper.GetNextCustomerNumber(new ConfigurationManager(_repository))
                    //TODO send out email to customer to change their password
                    //The email should have a token in it to a specific page
                };
            }
            else
            {
                if (!int.TryParse(customer.Id, out int id))
                {
                    throw new DataException("The customer Id is invalid");
                }

                cust = OrderInvoice_BL.People.Customer.GetCustomerById(id, this._repository);
                cust.Number = int.Parse(customer.CustomerNumber); //validation insures its an numeric
            }

            cust.FirstName = customer.FirstName;
            cust.LastName = customer.LastName;
            cust.UserName = customer.UserName;
            cust.Active = customer.Active;
            cust.ShippingIsSameAsBilling = customer.ShippingIsSameAsBilling;
            cust.Save();
            SnailMailAddress billingAddress;
            if (!customer.BillingAddress.Id.IsEmpty())
            {
                if (!int.TryParse(customer.Id, out int billingId))
                {
                    throw new DataException("The customer Id is invalid");
                }

                billingAddress = SnailMailAddress.GetById(billingId, _repository);
            }
            else
            {
                billingAddress = new SnailMailAddress(_repository);
            }

            billingAddress.Line1 = customer.BillingAddress.Address1;
            billingAddress.Line2 = customer.BillingAddress.Address2;
            billingAddress.City = customer.BillingAddress.City;
            billingAddress.State = State.GetById(int.Parse(customer.BillingAddress.StateValue.Id), _repository);
            billingAddress.Zip = customer.BillingAddress.Zip;
            billingAddress.Country = Country.GetOrCreateCountry(CountryName.UnitedStates, _repository);
            billingAddress.Type = SnailMailType.GetOrCreateSnailMailType(_repository, MailType.Billing);
            if (billingAddress.IsNew)
            {
                cust.AddAddress(billingAddress);
            }
            else
            {
                billingAddress.Save();
            }

            if (!customer.ShippingIsSameAsBilling)
            {
                SnailMailAddress shippingAddress;
                if (!customer.ShippingAddress.Id.IsEmpty())
                {
                    if (!int.TryParse(customer.Id, out int shippingId))
                    {
                        throw new DataException("The customer Id is invalid");
                    }

                    shippingAddress = SnailMailAddress.GetById(shippingId, _repository);
                }
                else
                {
                    shippingAddress = new SnailMailAddress(_repository);
                }

                shippingAddress.Line1 = customer.ShippingAddress.Address1;
                shippingAddress.Line2 = customer.ShippingAddress.Address2;
                shippingAddress.City = customer.ShippingAddress.City;
                shippingAddress.State = State.GetById(int.Parse(customer.ShippingAddress.StateValue.Id), _repository);
                shippingAddress.Zip = customer.ShippingAddress.Zip;
                shippingAddress.Country =
                    Country.GetOrCreateCountry(CountryName.UnitedStates,
                        _repository); // we are supporting USA only currently
                shippingAddress.Type = SnailMailType.GetOrCreateSnailMailType(_repository, MailType.Shipping);
                if (shippingAddress.IsNew)
                {
                    cust.AddAddress(shippingAddress);
                }
                else
                {
                    shippingAddress.Save();
                }
            }

            PhoneNumber phone = cust.GetDefaultNumber();
            bool hasDefaultNumber = true;
            if (phone.IsEmpty())
            {
                phone = new PhoneNumber(_repository);
                hasDefaultNumber = false;
            }

            phone.CountryCode = "1"; // we are supporting USA only currently
            phone.Number = customer.PhoneNumber;
            phone.Type = PhoneNumberType.GetById(int.Parse(customer.PhoneNumberTypeValue.Id), _repository);
            if (hasDefaultNumber)
            {
                phone.Save();
            }
            else
            {
                cust.AddPhoneNumber(phone);
                cust.SetDefaultNumber(phone);
            }

            EmailAddress ea = cust.GetDefaultEMailAddress();
            if (ea.IsEmpty())
            {
                cust.AddEmailAddress(customer.Email);
            }
            else
            {
                ea.Address = customer.Email;
                ea.Save();
            }

            return new AcceptedResult();
        }
    }
}
