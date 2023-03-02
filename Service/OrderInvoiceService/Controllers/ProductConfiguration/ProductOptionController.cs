// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-24-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductOptionController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Logic.Validators;
using OrderInvoiceService.Models.API.Products;
using OrderInvoiceService.Models.API.Products.Requests;
using Utilites;
using Attribute = OrderInvoice_BL.Products.Attribute;//remove ambudity between the BO attribute and the System.Attribute0

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductConfiguration
{
    /// <summary>
    /// Class ProductOptionController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public ProductOptionController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));

        }

        /// <summary>
        /// Saves the option to the systems
        /// This endpoint will create or update the option based on the id property
        /// </summary>
        /// <param name="incomingProductOptionModel">The incoming product option model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] ProductOptionModel incomingProductOptionModel)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingProductOptionModel);
            ProductValidator.ValidateProductOption(incomingProductOptionModel);
            ProductOption productOption =
                ProductOptionTransformer.GetBoFromClientModel(incomingProductOptionModel, _repository);
            productOption.Save();
            return new AcceptedResult();

        }

        /// <summary>
        /// Sets the attributes for the option.
        /// This endpoint will reset the relationships between the option and the attributes
        /// </summary>
        /// <param name="incomingRequestObject">The incoming request object.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product
        /// or
        /// The Product is not a valid Product option for the given Product
        /// or
        /// The attributes cannot be newly created</exception>
        [HttpPost]
        [Route("Attributes")]
        public ActionResult SetAttributesForProductOption([FromBody] AttributesForProductOptionRequest incomingRequestObject)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingRequestObject);
            ProductValidator.ValidateAttributesForProductOptionRequest(incomingRequestObject);
            Product product = ProductTransformer.GetBoFromClientModel(incomingRequestObject.Product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            ProductOption productOption = product.GetOptions()
                .FirstOrDefault(x =>
                {
                    bool returnValue = false;
                    if (int.TryParse(incomingRequestObject.ProductOption.id, out int idInt))
                    {
                        returnValue = (idInt == x.Id);
                    }

                    return returnValue;
                });
            if (productOption.IsEmpty())
            {
                throw new Exception("The Product is not a valid Product option for the given Product");
            }

            List<Attribute> attributes = new List<Attribute>();
            foreach (AttributeModel incomingAttributeModel in incomingRequestObject.Attributes)
            {
                Attribute tempAttribute =
                    AttributeTransformer.GetBoFromClientModel(incomingAttributeModel, _repository);
                if (tempAttribute.IsNew)
                {
                    throw new Exception("The attributes cannot be newly created");
                }

                attributes.Add(tempAttribute);
            }
            // ReSharper disable once PossibleNullReferenceException
            productOption.ReplaceAttributes(product, attributes.ToArray());
            return new AcceptedResult();
        }

        /// <summary>Sets the attribute values for product option.</summary>
        /// <param name="incomingRequestObject">The incoming request object.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product</exception>
        /// <exception cref="DataException">The attribute Id is invalid
        /// or
        /// The Product option Id is invalid
        /// or
        /// The attribute Id is invalid
        /// or
        /// The attribute Id is invalid</exception>
        [HttpPost]
        [Route("AttributeValues")]
        public ActionResult SetAttributeValuesForProductOption([FromBody] AttributeValuesForProductOptionRequest incomingRequestObject)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingRequestObject);
            ProductValidator.ValidateAttributeValuesForProductOptionRequest(incomingRequestObject);

            Product product = ProductTransformer.GetBoFromClientModel(incomingRequestObject.product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            if (!int.TryParse(incomingRequestObject.productOption.id, out int optionId))
            {
                throw new DataException("The attribute Id is invalid");
            }


            ProductOption option = product.GetOptions().FirstOrDefault(o => o.Id == optionId);
            if (option.IsEmpty())
            {
                throw new DataException("The Product option Id is invalid");
            }

            if (!int.TryParse(incomingRequestObject.attribute.id, out int attributeId))
            {
                throw new DataException("The attribute Id is invalid");
            }

            Attribute att = product.GetAttributes().FirstOrDefault(a => a.Id == attributeId);
            if (att.IsEmpty())
            {
                throw new DataException("The attribute Id is invalid");
            }

            List<OptionAttributeValue> attributeValues = new List<OptionAttributeValue>();

            foreach (AttributeValueModel incomingAttributeModel in incomingRequestObject.attributeValues)
            {
                OptionAttributeValue tempAttribute =
                    ProductOptionAttributeValueTransformer.GetBoFromClientModel(incomingAttributeModel, _repository);
                attributeValues.Add(tempAttribute);
            }

            // ReSharper disable once PossibleNullReferenceException
            option.ReplaceAttributeValues(product, att, attributeValues);
            return new AcceptedResult();
        }

    }
}
