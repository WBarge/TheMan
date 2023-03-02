// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-24-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Logic.Transformers;
using OrderInvoiceService.Logic.Validators;
using OrderInvoiceService.Models.API.Products;
using OrderInvoiceService.Models.API.Products.Requests;
using Utilites;
using Attribute = OrderInvoice_BL.Products.Attribute;//remove ambudity between the BO attribute and the System.Attribute


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderInvoiceService.Controllers.ProductConfiguration
{
    /// <summary>
    /// Class ProductController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <exception cref="ArgumentNullException">repo</exception>
        public ProductController(IRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// Gets the specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>JsonResult.</returns>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Product product = Product.GetById(id,_repository);

            ProductModel returnValue = ProductTransformer.GetClientModelFromBo(product);

            return new JsonResult(returnValue);
        }

        /// <summary>
        /// Will create or update a product with this endpoint
        /// </summary>
        /// <param name="incomingProductModel">The incoming product model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] ProductModel incomingProductModel)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingProductModel);
            ProductValidator.ValidateProduct(incomingProductModel);
            Product product = ProductTransformer.GetBoFromClientModel(incomingProductModel, _repository);
            product.Save();
            return new AcceptedResult();

        }

        /// <summary>
        /// Gets the options for a product.
        /// </summary>
        /// <param name="id">The Id of the product to get the options for.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="InvalidParameterException">Invalid Id</exception>
        /// <exception cref="DataException">Invalid Product</exception>
        [HttpGet]
        [Route("{id}/ProductOptions")]
        public JsonResult GetOptionsForProduct(int id)
        {
            if (id.IsEmpty())
            {
                throw new InvalidParameterException("Invalid Id");
            }

            List<ProductOptionModel> returnValues = new List<ProductOptionModel>();
            Product product = Product.GetById(id, _repository);
            if (product.IsEmpty())
            {
                throw new DataException("Invalid Product");
            }

            returnValues.AddRange(product.GetOptions().Select(ProductOptionTransformer.GetClientModelFromBo));
            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>
        /// Saves the options to the product
        /// This endpoint will reset the relationships between the product and the options
        /// </summary>
        /// <param name="incomingRequestObject">The incoming request object.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product
        /// or
        /// The production options cannot be newly created</exception>
        [HttpPost]
        [Route("ProductOptions")]
        public ActionResult SetProductOptionsForProduct([FromBody] ProductOptionsForProductRequest incomingRequestObject)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingRequestObject);
            ProductValidator.ValidateProductionOptionsForProductRequest(incomingRequestObject);
            Product product = ProductTransformer.GetBoFromClientModel(incomingRequestObject.Product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            List<ProductOption> options = new List<ProductOption>();
            foreach (ProductOptionModel incomingOptionModel in incomingRequestObject.Options)
            {
                ProductOption tempProductOption =
                    ProductOptionTransformer.GetBoFromClientModel(incomingOptionModel, _repository);
                if (tempProductOption.IsNew)
                {
                    throw new Exception("The production options cannot be newly created");
                }

                options.Add(tempProductOption);
            }

            product.ReplaceOptions(options.ToArray());
            return new AcceptedResult();
        }

        /// <summary>
        /// Gets the attributes for a product.
        /// </summary>
        /// <param name="id">The Id of the product to get the attributes for.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="InvalidParameterException">Invalid Id</exception>
        /// <exception cref="DataException">Invalid Product</exception>
        [HttpGet]
        [Route("{id}/Attributes")]
        public JsonResult GetAttributesForProduct(int id)
        {
            if (id.IsEmpty())
            {
                throw new InvalidParameterException("Invalid Id");
            }

            List<AttributeModel> returnValues = new List<AttributeModel>();
            Product product = Product.GetById(id, _repository);
            if (product.IsEmpty())
            {
                throw new DataException("Invalid Product");
            }

            returnValues.AddRange(product.GetAttributes().Select(AttributeTransformer.GetClientModelFromBo));
            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>
        /// Saves the attributes for product.
        /// This endpoint will reset the relationships between the product and the attributes
        /// </summary>
        /// <param name="incomingRequestObject">The incoming request object.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product
        /// or
        /// The attributes cannot be newly created</exception>
        [HttpPost]
        [Route("Attributes")]
        public ActionResult SetAttributesForProduct([FromBody] AttributesForProductRequest incomingRequestObject)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingRequestObject);
            ProductValidator.ValidateAttributesForProductRequest(incomingRequestObject);
            Product product = ProductTransformer.GetBoFromClientModel(incomingRequestObject.Product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
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

            product.ReplaceAttributes(attributes.ToArray());
            return new AcceptedResult();

        }

        /// <summary>
        /// Gets the attributes for an option.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="InvalidParameterException">The Product Id is invalid
        /// or
        /// The Product option Id is invalid</exception>
        /// <exception cref="DataException">Invalid Product
        /// or
        /// Invalid Product option</exception>
        [HttpGet]
        [Route("{productId}/ProductOption/{productOptionId}/Attributes")]
        public JsonResult GetAttributesForProductOption( int productId, int productOptionId)
        {
            if (productId.IsEmpty())
            {
                throw new InvalidParameterException("The Product Id is invalid");
            }
            if (productOptionId.IsEmpty())
            {
                throw new InvalidParameterException("The Product option Id is invalid");
            }

            List<AttributeModel> returnValues = new List<AttributeModel>();
            Product product = Product.GetById(productId, _repository);
            if (product.IsEmpty())
            {
                throw new DataException("Invalid Product");
            }

            //even though we can get the production option directly with a getByID 
            //this guanetees the Product option is related to the Product
            ProductOption productOption = product.GetOptions().FirstOrDefault(po => po.Id == productOptionId);
            if (productOption.IsEmpty())
            {
                throw new DataException("Invalid Product option");
            }

            // ReSharper disable once PossibleNullReferenceException  -- ReSharper does not see the IsEmpty check above
            returnValues.AddRange(
                productOption.GetAttributes(product).Select(AttributeTransformer.GetClientModelFromBo));
            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>
        /// Gets the attribute values for a product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="InvalidParameterException">The Product Id is invalid
        /// or
        /// The attribute Id is invalid</exception>
        /// <exception cref="DataException">Invalid Product</exception>
        [HttpGet]
        [Route("{productId}/Attribute/{attributeId}")]
        public JsonResult GetAttributeValuesForProduct(int productId, int attributeId)
        {
            if (productId.IsEmpty())
            {
                throw new InvalidParameterException("The Product Id is invalid");
            }
            if (attributeId.IsEmpty())
            {
                throw new InvalidParameterException("The attribute Id is invalid");
            }

            List<AttributeValueModel> returnValues = new List<AttributeValueModel>();
            Product product = Product.GetById(productId, _repository);
            if (product.IsEmpty())
            {
                throw new DataException("Invalid Product");
            }

            ProductAttributeValue[] attributeValues = product.GetAttributeValues(attributeId);

            returnValues.AddRange(attributeValues.Select(ProductAttributeValueTransformer.GetClientModelFromBo));
            return new JsonResult(returnValues.ToArray());
        }

        /// <summary>
        /// Save the attribute values for a product.
        /// This endpoint will reset the relationships between the product and the attribute values
        /// </summary>
        /// <param name="incomingRequestObject">The incoming request object.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="Exception">The Product cannot be a newly created Product</exception>
        /// <exception cref="DataException">The attribute Id is invalid</exception>
        [HttpPost]
        [Route("AttributeValues")]
        public ActionResult SetAttributeValuesForProduct([FromBody] AttributeValuesForProductRequest incomingRequestObject)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(incomingRequestObject);
            ProductValidator.ValidateAttributeValuesForProductRequest(incomingRequestObject);
            Product product = ProductTransformer.GetBoFromClientModel(incomingRequestObject.product, _repository);
            if (product.IsNew)
            {
                throw new Exception("The Product cannot be a newly created Product");
            }

            if (!int.TryParse(incomingRequestObject.attribute.id, out int attributeId))
            {
                throw new DataException("The attribute Id is invalid");
            }


            Attribute att = product.GetAttributes().FirstOrDefault(a => a.Id == attributeId);

            List<ProductAttributeValue> attributeValues = new List<ProductAttributeValue>();

            foreach (AttributeValueModel incomingAttributeModel in incomingRequestObject.attributeValues)
            {
                ProductAttributeValue tempAttribute =
                    ProductAttributeValueTransformer.GetBoFromClientModel(incomingAttributeModel, _repository);
                attributeValues.Add(tempAttribute);
            }

            product.ReplaceAttributeValues(att, attributeValues);
            return new AcceptedResult();

        }

        /// <summary>Gets the attribute values for product option.</summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns>JsonResult.</returns>
        /// <exception cref="DataException">The Product Id is invalid
        /// or
        /// The Product option Id is invalid
        /// or
        /// The attribute Id is invalid
        /// or
        /// Invalid Product
        /// or
        /// Invalid Product Option</exception>
        [HttpGet]
        [Route("{productId}/ProductOption/{productOptionId}/Attribute/{attributeId}")]
        public JsonResult GetAttributeValuesForProductOption(string productId, string productOptionId, string attributeId)
        {
            if (!int.TryParse(productId, out int prodId))
            {
                throw new DataException("The Product Id is invalid");
            }

            if (!int.TryParse(productOptionId, out int prodOptionId))
            {
                throw new DataException("The Product option Id is invalid");
            }

            if (!int.TryParse(attributeId, out int attriId))
            {
                throw new DataException("The attribute Id is invalid");
            }

            List<AttributeValueModel> returnValues = new List<AttributeValueModel>();
            Product product = Product.GetById(prodId, _repository);
            if (product.IsEmpty())
            {
                throw new DataException("Invalid Product");
            }

            ProductOption productOption = product.GetOptions().FirstOrDefault(po => po.Id == prodOptionId);
            if (productOption.IsEmpty())
            {
                throw new DataException("Invalid Product Option");
            }

            // ReSharper disable once PossibleNullReferenceException
            OptionAttributeValue[] attributeValues = productOption.GetAttributeValues(product, attriId);

            returnValues.AddRange(attributeValues.Select(ProductOptionAttributeValueTransformer.GetClientModelFromBo));
            return new JsonResult(returnValues.ToArray());
        }

    }
}
