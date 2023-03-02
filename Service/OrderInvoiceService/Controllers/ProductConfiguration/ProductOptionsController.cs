// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-24-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductOptionsController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Models.API.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductConfiguration
{
    /// <summary>
    /// Class ProductOptionsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ProductOptionsController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionsController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public ProductOptionsController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        //get all product options in the system
        /// <summary>
        /// Gets all options in the system
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult Get()
        {
            List<ProductOptionModel> returnValues = new List<ProductOptionModel>();

            List<ProductOption> productOptions = ProductOption.GetAll(_repository);

            returnValues.AddRange(productOptions.Select(ProductOptionTransformer.GetClientModelFromBo));

            return new JsonResult(returnValues.ToArray());

        }


       


    }
}
