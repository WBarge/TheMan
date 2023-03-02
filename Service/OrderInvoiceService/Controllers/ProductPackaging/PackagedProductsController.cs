// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-27-2021
//
// Last Modified By : Admin
// Last Modified On : 02-27-2021
// ***********************************************************************
// <copyright file="PackagedProductsController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Models.API.Products;
using Utilites;
using Attribute = System.Attribute;

namespace OrderInvoiceService.Controllers.ProductPackaging
{
    /// <summary>
    /// Class PackagedProductsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class PackagedProductsController : ControllerBase
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
        public PackagedProductsController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));

        }

        /// <summary>
        /// Gets the packaged products.
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        public JsonResult GetPackagedProducts()
        {
            List<PackagedProductModel> returnValues = new List<PackagedProductModel>();

            //This may cause a bottle neck just like getting the prices for products
            //ie it is the same case so if needed the resolution will be the same
            foreach (PredefinedProduct predefinedProduct in PredefinedProduct.GetAll(_repository))
            {
                PackagedProductModel tempProductPricingModel =
                    PredefinedProductTransformer.GetClientModelFromBo(predefinedProduct);
                //load the product details
                OrderInvoice_BL.Products.Attribute[] productAttributes = predefinedProduct.GetProductAttributes();
                if (productAttributes.IsNotEmpty())
                {
                    List<PackagedProductDetailModel> details = new List<PackagedProductDetailModel>();
                    foreach (OrderInvoice_BL.Products.Attribute attribute in productAttributes)
                    {
                        string attributeValue = predefinedProduct.GetAttributeValue(attribute);
                        PackagedProductDetailModel tempDetail = new PackagedProductDetailModel
                        {
                            attribute = AttributeTransformer.GetClientModelFromBo(attribute),
                            attributeValue = attributeValue
                        };
                        ProductAttributeValue[] possbleValues = predefinedProduct.GetProductAttributeValues(attribute);

                        tempDetail.possibleValues = possbleValues
                            .Select(ProductAttributeValueTransformer.GetClientModelFromBo).ToArray();
                        details.Add(tempDetail);
                    }

                    tempProductPricingModel.details = details.ToArray();
                }

                //load options
                PredefinedOption[] predefinedOptions = predefinedProduct.GetPredefinedOptions();
                if (predefinedOptions.IsNotEmpty())
                {
                    List<PackagedProductOptionModel> packagedProductOptionModels =
                        new List<PackagedProductOptionModel>();
                    foreach (PredefinedOption option in predefinedOptions)
                    {
                        PackagedProductOptionModel packagedProductOptionModel =
                            PredefinedProductOptionTransformer.GetClientModelFromBo(option);
                        //load option attributes
                        OrderInvoice_BL.Products.Attribute[] optionAttributes = option.GetOptionAttributes(predefinedProduct);
                        if (optionAttributes.IsNotEmpty())
                        {
                            List<PackagedProductOptionDetailModel> optionDetailModels =
                                new List<PackagedProductOptionDetailModel>();
                            foreach (OrderInvoice_BL.Products.Attribute attribute in optionAttributes)
                            {
                                string attributeValue = option.GetAttributeValue(attribute);
                                PackagedProductOptionDetailModel packagedProductOptionDetailModel =
                                    new PackagedProductOptionDetailModel
                                    {
                                        attribute = AttributeTransformer.GetClientModelFromBo(attribute),
                                        attributeValue = attributeValue
                                    };
                                OptionAttributeValue[] possbleValues =
                                    option.GetOptionAttributeValues(predefinedProduct, attribute);

                                packagedProductOptionDetailModel.possibleValues = possbleValues
                                    .Select(ProductOptionAttributeValueTransformer.GetClientModelFromBo).ToArray();
                                optionDetailModels.Add(packagedProductOptionDetailModel);
                            }

                            packagedProductOptionModel.details = optionDetailModels.ToArray();
                        }

                        packagedProductOptionModels.Add(packagedProductOptionModel);
                    }

                    tempProductPricingModel.options = packagedProductOptionModels.ToArray();
                }

                returnValues.Add(tempProductPricingModel);
            }

            return new JsonResult(returnValues.ToArray());
        }
    }
}
