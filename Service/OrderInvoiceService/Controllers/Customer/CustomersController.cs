// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="CustomersController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Models.API;

namespace OrderInvoiceService.Controllers.Customer
{
    /// <summary>
    /// Class CustomersController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public CustomersController( IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        public JsonResult GetCustomers()
        {
            List<CustomerModel> returnValue = new List<CustomerModel>();
            IEnumerable<OrderInvoice_BL.People.Customer> customers = OrderInvoice_BL.People.Customer.GetAllCustomers(_repository);
            foreach (OrderInvoice_BL.People.Customer c in customers)
            {
                SnailMailAddress billingSnailMailAddress = c.GetBillingAddress();
                SnailMailAddress shippingSnailMailAddress = c.GetShippingAddress();
                PhoneNumber phone = c.GetDefaultNumber();
                CustomerModel tempContactReadModel = new CustomerModel();


                tempContactReadModel.Id = c.Id.ToString();
                tempContactReadModel.FirstName = c.FirstName;
                tempContactReadModel.LastName = c.LastName;
                tempContactReadModel.CustomerNumber = c.Number.ToString();
                tempContactReadModel.UserName = c.UserName;
                tempContactReadModel.Password = "";
                tempContactReadModel.Active = c.Active;
                tempContactReadModel.ShippingIsSameAsBilling = c.ShippingIsSameAsBilling;
                tempContactReadModel.BillingAddress = new AddressModel()
                {
                    Id = billingSnailMailAddress.Id.ToString(),
                    Address1 = billingSnailMailAddress.Line1,
                    Address2 = billingSnailMailAddress.Line2,
                    City = billingSnailMailAddress.City,
                    StateValue = UIHelpers.CreateFileDropDownItem(billingSnailMailAddress.State.Name.ToString(),
                            billingSnailMailAddress.State.Id.ToString(),
                            billingSnailMailAddress.State.Name.ToString())
                        .Value,
                    Zip = billingSnailMailAddress.Zip
                };
                tempContactReadModel.ShippingAddress = null;
                tempContactReadModel.Email = c.GetDefaultEMailAddress().Address;
                tempContactReadModel.PhoneNumberTypeValue = UIHelpers
                    .CreateFileDropDownItem(phone.Type.Type.ToString(), phone.Type.Id.ToString(),
                        phone.Type.Type.ToString())
                    .Value;
                tempContactReadModel.PhoneNumber = phone.Number;

                if (!c.ShippingIsSameAsBilling)
                {
                    tempContactReadModel.ShippingAddress = new AddressModel()
                    {
                        Id = shippingSnailMailAddress.Id.ToString(),
                        Address1 = shippingSnailMailAddress.Line1,
                        Address2 = shippingSnailMailAddress.Line2,
                        City = shippingSnailMailAddress.City,
                        StateValue = UIHelpers
                            .CreateFileDropDownItem(shippingSnailMailAddress.State.Name.ToString(),
                                shippingSnailMailAddress.State.Id.ToString(),
                                shippingSnailMailAddress.State.Name.ToString())
                            .Value,
                        Zip = shippingSnailMailAddress.Zip
                    };
                }

                returnValue.Add(tempContactReadModel);
            }

            return new JsonResult(returnValue.ToArray());
        }

    }
}
