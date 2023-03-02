// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="ProductPricingController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Logic.Validators;
using OrderInvoiceService.Models.API.Products;
using OrderInvoiceService.Models.API.Products.Requests;
using Utilites;

namespace OrderInvoiceService.Controllers.ProductPricing
{
    /// <summary>
    /// Class ProductPricingController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ProductPricingController : ControllerBase
    {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrderInvoiceService.Controllers.ProductPricing.ProductPricingController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public ProductPricingController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));

        }

        /// <summary>
        /// Gets the pricing for products.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult GetPricingForProducts()
        {
            List<ProductPricingModel> returnValues = new List<ProductPricingModel>();
            //This may cause a bottle neck as the number of products grows so we may need to push this
            //down to the bo and data layer - so the bo is loaded with prices already and the data layer returns
            //the Product and its prices (the number of hits to the db is up to the data layer - its abstracted)
            foreach (Product productsWithPrice in Product.GetAll(_repository))
            {
                ProductPricingModel tempProductPricingModel = new ProductPricingModel();
                string[] formulaVariables = productsWithPrice.GetAttributesAsVariables();
                ProductPrice[] prices = productsWithPrice.GetPrice();
                if (prices.IsNotEmpty())
                {
                    tempProductPricingModel.Product = ProductTransformer.GetClientModelFromBo(productsWithPrice);
                    List<PriceModel> tempList = new List<PriceModel>();
                    foreach (ProductPrice pp in prices)
                    {
                        PriceModel tempPrice = ProductPriceTransformer.GetClientModelFromBo(pp);
                        tempPrice.FormulaVariables = formulaVariables;
                        tempList.Add(tempPrice);
                    }

                    tempProductPricingModel.Prices = tempList.ToArray();
                    returnValues.Add(tempProductPricingModel);
                }
            }

            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>Gets the products with no prices.</summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        [Route("Products")]
        public JsonResult GetProductsWithNoPrices()
        {
            List<ProductModel> returnValues = new List<ProductModel>();

            //This may cause a bottle neck as the number of products grows so we may need to push this
            //down to the bo and data layer - so the bo is loaded with prices already and the data layer returns
            //the Product and its prices (the number of hits to the db is up to the data layer - its abstracted)
            List<Product> products = Product.GetAll(_repository);
            foreach (Product product in products)
            {
                if (!product.HasPrice())
                {
                    returnValues.Add(ProductTransformer.GetClientModelFromBo(product));
                }
            }

            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>Creates the initial product price.</summary>
        /// <param name="incomingProductPriceRequest">The incoming product price request.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product</exception>
        [HttpPost]
        [Route("NewProduct")]
        public ActionResult CreateInitialProductPrice([FromBody] InitialProductPriceRequest incomingProductPriceRequest)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingProductPriceRequest);
            ProductValidator.ValidateValuesForInitialProductPriceRequest(incomingProductPriceRequest);
            Product product = ProductTransformer.GetBoFromClientModel(incomingProductPriceRequest.Product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            ProductPrice productPrice = new ProductPrice(_repository);
            productPrice.SetPrice(incomingProductPriceRequest.InitialPrice);
            product.AddPrice(productPrice);
            return new AcceptedResult();
        }

        /// <summary>Sets the product price.</summary>
        /// <param name="incomingProductPriceRequest">The incoming product price request.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product</exception>
        [HttpPost]
        public ActionResult SetProductPrice([FromBody] ProductPriceRequest incomingProductPriceRequest)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingProductPriceRequest);
            ProductValidator.ValidateValuesForSetProductPrice(incomingProductPriceRequest);
            Product product = ProductTransformer.GetBoFromClientModel(incomingProductPriceRequest.Product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            ProductPrice productPrice =
                ProductPriceTransformer.GetBoFromClientModel(product, incomingProductPriceRequest.Price, _repository);

            if (productPrice.IsNew)
            {
                product.AddPrice(productPrice);
            }
            else
            {
                productPrice.Save();
            }

            return new AcceptedResult();
        }

    }
}
