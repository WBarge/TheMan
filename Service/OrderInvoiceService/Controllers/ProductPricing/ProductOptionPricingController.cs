// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="ProductOptionPricingController.cs" company="OrderInvoiceService">
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductPricing
{
    /// <summary>
    /// Class ProductOptionPricingController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ProductOptionPricingController : ControllerBase
    {


        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrderInvoiceService.Controllers.ProductConfiguration.ProductPricingController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public ProductOptionPricingController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));

        }

        /// <summary>Gets the pricing from product options.</summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult GetPricingFromProductOptions()
        {
            List<ProductOptionPricingModel> returnValues = new List<ProductOptionPricingModel>();
            //This may cause a bottle neck just like getting the prices for products
            //ie it is the same case so if needed the resolution will be the same as a resolution for getting product pricing
            foreach (ProductOption productOptionsWithPrice in ProductOption.GetAll(_repository))
            {
                ProductOptionPricingModel tempProductPricingModel = new ProductOptionPricingModel();
                //formulas for product options are not currently supported - this just a place holder in case we change that
                //string[] formulaVariables = productsWithPrice.GetAttributesAsVariables();
                OptionPrice[] prices = productOptionsWithPrice.GetPrice();
                if (prices.IsNotEmpty())
                {
                    tempProductPricingModel.Option =
                        ProductOptionTransformer.GetClientModelFromBo(productOptionsWithPrice);
                    List<PriceModel> tempList = new List<PriceModel>();
                    foreach (OptionPrice pp in prices)
                    {
                        PriceModel tempPrice = ProductOptionPriceTransfomer.GetClientModelFromBo(pp);
                        //formulas for product options are not currently supported - this just a place holder in case we change that
                        //tempPrice.FormulaVariables = formulaVariables;
                        tempList.Add(tempPrice);
                    }

                    tempProductPricingModel.Prices = tempList.ToArray();
                    returnValues.Add(tempProductPricingModel);
                }
            }

            return new JsonResult(returnValues.ToArray());

        }

        /// <summary>Gets the product options with no prices.</summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        [Route("ProductOptions")]
        public JsonResult GetProductOptionsWithNoPrices()
        {
            List<ProductOptionModel> returnValues = new List<ProductOptionModel>();

            //This may cause a bottle neck as the number of options grows so we may need to push this
            //down to the bo and data layer - so the bo is loaded with prices already and the data layer returns
            //the option and its prices (the number of hits to the db is up to the data layer - its abstracted)
            List<ProductOption> options = ProductOption.GetAll(_repository);
            foreach (ProductOption option in options)
            {
                if (!option.HasPrice())
                {
                    returnValues.Add(ProductOptionTransformer.GetClientModelFromBo(option));
                }
            }

            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>Creates the initial option price.</summary>
        /// <param name="incomingOptionPriceRequest">The incoming option price request.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product</exception>
        [HttpPost]
        [Route("NewProductOption")]
        public ActionResult CreateInitialOptionPrice([FromBody] InitialOptionPriceRequest incomingOptionPriceRequest)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingOptionPriceRequest);
            ProductValidator.ValidateValuesForInitialProductOptionPriceRequest(incomingOptionPriceRequest);
            ProductOption product =
                ProductOptionTransformer.GetBoFromClientModel(incomingOptionPriceRequest.Option, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            OptionPrice productPrice = new OptionPrice(_repository);
            productPrice.SetPrice(incomingOptionPriceRequest.InitialPrice);
            product.AddOptionPrice(productPrice);
            return new AcceptedResult();
        }

        /// <summary>Sets the product option price.</summary>
        /// <param name="incomingProductPriceRequest">The incoming product price request.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product Option cannot be a newly created Option</exception>
        [HttpPost]
        public ActionResult SetProductOptionPrice([FromBody] ProductOptionPriceRequest incomingProductPriceRequest)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingProductPriceRequest);
            ProductValidator.ValidateValuesForSetProductOptionPrice(incomingProductPriceRequest);
            ProductOption option =
                ProductOptionTransformer.GetBoFromClientModel(incomingProductPriceRequest.Option, _repository);
            if (option.IsNew)
            {
                throw new Exception("The Product Option cannot be a newly created Option");
            }

            OptionPrice productOptionPrice =
                ProductOptionPriceTransfomer.GetBoFromClientModel(option, incomingProductPriceRequest.Price,
                    _repository);

            if (productOptionPrice.IsNew)
            {
                option.AddOptionPrice(productOptionPrice);
            }
            else
            {
                productOptionPrice.Save();
            }

            return new AcceptedResult();
        }

    }
}
