// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="StatesController.cs" company="OrderInvoiceService">
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
    /// Class StatesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public StatesController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>Gets the states for the USA.</summary>
        [HttpGet]
        public JsonResult GetStates()
        {
            List<DropDownItemModel> returnValue = new List<DropDownItemModel>();
            const int counter = 0;
            returnValue.Add(UIHelpers.CreateFileDropDownItem("Select State", counter.ToString(), "Select State"));
            foreach (State s in State.GetAll(_repository))
            {
                returnValue.Add(UIHelpers.CreateFileDropDownItem(s.Name.ToString(), s.Id.ToString(),
                    s.Name.ToString()));
            }

            return new JsonResult(returnValue.ToArray());

        }
    }
}
