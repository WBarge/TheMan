// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-24-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="AttributesController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Models.API.Products;
using Attribute = OrderInvoice_BL.Products.Attribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductConfiguration
{
    /// <summary>
    /// Class AttributesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributesController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public AttributesController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// Gets the attributes in the system
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult Get()
        {
            List<AttributeModel> returnValues = new List<AttributeModel>();

            List<Attribute> attributes =
                Attribute.GetAll(_repository);

            returnValues.AddRange(attributes.Select(AttributeTransformer.GetClientModelFromBo));

            return new JsonResult(returnValues.ToArray());

        }
    }
}
