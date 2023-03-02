// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-24-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="AttributeController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Logic.Validators;
using OrderInvoiceService.Models.API.Products;
using Attribute = OrderInvoice_BL.Products.Attribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductConfiguration
{
    /// <summary>
    /// Class AttributeController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public AttributeController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        //create / update an attribute in the system
        /// <summary>
        /// Saves the attribute to the systems
        /// This endpoint will create or update the attribute based on the id property
        /// </summary>
        /// <param name="incomingAttributeModel">The incoming attribute model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] AttributeModel incomingAttributeModel)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingAttributeModel);
            ProductValidator.ValidateAttribute(incomingAttributeModel);
            Attribute attribute =
                AttributeTransformer.GetBoFromClientModel(incomingAttributeModel, _repository);
            attribute.Save();
            return new AcceptedResult();

        }
    }
}
