// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="PhoneNumberTypesController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Models.API;

namespace OrderInvoiceService.Controllers.Customer
{
    /// <summary>
    /// Class PhoneNumberTypesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class PhoneNumberTypesController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public PhoneNumberTypesController( IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }


        /// <summary>
        /// Gets the phone number types available in the system.
        /// </summary>
        /// <returns>System.Threading.Tasks.Task&lt;Microsoft.AspNetCore.Mvc.JsonResult&gt;.</returns>
        [HttpGet]
        public JsonResult GetPhoneNumberTypes()
        {
            return new JsonResult(PhoneNumberType.GetAll(_repository)
                .Select(pt => UIHelpers.CreateFileDropDownItem(pt.Type.ToString(), pt.Id.ToString(), pt.Type.ToString())).ToArray());
        }

    }
}
