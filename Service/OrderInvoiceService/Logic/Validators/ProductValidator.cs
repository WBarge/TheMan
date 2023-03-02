// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductValidator.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptions;
using OrderInvoiceService.Models.API.Products;
using OrderInvoiceService.Models.API.Products.Requests;
using Utilites;

namespace OrderInvoiceService.Logic.Validators
{
    /// <summary>
    /// Class holds validators to validate models related to products.
    /// </summary>
    public class ProductValidator
    {

        /// <summary>
        /// Validates the Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <exception cref="RequiredFieldException">
        /// Name is required
        /// or
        /// Description is required
        /// </exception>
        public static void ValidateProduct(ProductModel product)
        {
            if (product.name.IsEmpty())
            {
                throw new RequiredFieldException("Name is required");
            }
            if (product.description.IsEmpty())
            {
                throw new RequiredFieldException("Description is required");
            }
        }

        /// <summary>
        /// Validates the Product option.
        /// </summary>
        /// <param name="productOption">The Product option.</param>
        /// <exception cref="RequiredFieldException">
        /// Name is required
        /// or
        /// Description is required
        /// </exception>
        public static void ValidateProductOption(ProductOptionModel productOption)
        {
            if (productOption.name.IsEmpty())
            {
                throw new RequiredFieldException("Name is required");
            }
            if (productOption.description.IsEmpty())
            {
                throw new RequiredFieldException("Description is required");
            }
        }

        /// <summary>
        /// Validates the attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <exception cref="RequiredFieldException">
        /// Name is required
        /// or
        /// Description is required
        /// </exception>
        public static void ValidateAttribute(AttributeModel attribute)
        {
            if (attribute.name.IsEmpty())
            {
                throw new RequiredFieldException("Name is required");
            }
            if (attribute.description.IsEmpty())
            {
                throw new RequiredFieldException("Description is required");
            }
        }

        /// <summary>
        /// Validates the request to set the production options for a Product
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">
        /// The Product Id is required
        /// or
        /// At least one Product option Id is missing
        /// </exception>
        public static void ValidateProductionOptionsForProductRequest(ProductOptionsForProductRequest request)
        {
            if (request.Product.IsEmpty() || request.Product.id.IsEmpty())
            {
                throw  new RequiredFieldException("The Product Id is required");
            }
            foreach (ProductOptionModel pom in request.Options)
            {
                if (pom.id.IsEmpty())
                {
                    throw new RequiredFieldException("At least one Product option Id is missing");
                }
            }
        }

        /// <summary>
        /// Validates the attributes for Product request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// At least one attribute Id is missing</exception>
        public static void ValidateAttributesForProductRequest(AttributesForProductRequest request)
        {
            if (request.Product.IsEmpty() || request.Product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            foreach (AttributeModel att in request.Attributes)
            {
                if (att.id.IsEmpty())
                {
                    throw new RequiredFieldException("At least one attribute Id is missing");
                }
            }
        }

        /// <summary>
        /// Validates the attributes for Product option request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The Product option Id is required
        /// or
        /// At least one attribute Id is missing</exception>
        public static void ValidateAttributesForProductOptionRequest(AttributesForProductOptionRequest request)
        {
            if (request.Product.IsEmpty() || request.Product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            if (request.ProductOption.IsEmpty() || request.ProductOption.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product option Id is required");
            }
            foreach (AttributeModel att in request.Attributes)
            {
                if (att.id.IsEmpty())
                {
                    throw new RequiredFieldException("At least one attribute Id is missing");
                }
            }
        }

        /// <summary>
        /// Validates the attribute values for Product request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The attribute Id is required
        /// or
        /// At least one attribute value is missing</exception>
        public static void ValidateAttributeValuesForProductRequest(AttributeValuesForProductRequest request)
        {
            if (request.product.IsEmpty() || request.product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            if (request.attribute.IsEmpty() || request.attribute.id.IsEmpty())
            {
                throw new RequiredFieldException("The attribute Id is required");
            }
            foreach (AttributeValueModel att in request.attributeValues)
            {
                if (att.valueName.IsEmpty())
                {
                    throw new RequiredFieldException("At least one attribute value is missing");
                }
            }

        }

        /// <summary>
        /// Validates the attribute values for Product option request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The Product option id is required
        /// or
        /// The attribute Id is required
        /// or
        /// At least one attribute value is missing</exception>
        public static void ValidateAttributeValuesForProductOptionRequest(AttributeValuesForProductOptionRequest request)
        {
            if (request.product.IsEmpty() || request.product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            if (request.productOption.IsEmpty() || request.productOption.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product option id is required");
            }
            if (request.attribute.IsEmpty() || request.attribute.id.IsEmpty())
            {
                throw new RequiredFieldException("The attribute Id is required");
            }
            foreach (AttributeValueModel att in request.attributeValues)
            {
                if (att.valueName.IsEmpty())
                {
                    throw new RequiredFieldException("At least one attribute value is missing");
                }
            }

        }

        /// <summary>
        /// Validates the values for initial Product Price request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The initial Price has to be greater than .01</exception>
        public static void ValidateValuesForInitialProductPriceRequest(InitialProductPriceRequest request)
        {
            if (request.Product.IsEmpty() || request.Product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            if (request.InitialPrice.IsEmpty() || request.InitialPrice.LessThan(0.01M,2))
            {
                throw new RequiredFieldException("The initial Price has to be greater than .01");
            }
        }

        /// <summary>
        /// Validates the values for set Product Price.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The Price is required
        /// or
        /// The date range the Price is valid for ie required
        /// or
        /// The Price is required. Set the formula or the flat Price.</exception>
        public static void ValidateValuesForSetProductPrice(ProductPriceRequest request)
        {
            if (request.Product.IsEmpty() || request.Product.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Id is required");
            }
            if (request.Price.FormulaPrice.IsEmpty() &&
                (request.Price.FlatPrice.IsEmpty() || request.Price.FlatPrice.LessThan(0.01M, 2)))
            {
                throw new RequiredFieldException("The Price is required. Set the formula or the flat Price.");
            }

        }

        /// <summary>
        /// Validates the values for initial product option price request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">The Product Id is required
        /// or
        /// The initial Price has to be greater than .01</exception>
        public static void ValidateValuesForInitialProductOptionPriceRequest(InitialOptionPriceRequest request)
        {
            if (request.Option.IsEmpty() || request.Option.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Option Id is required");
            }
            if (request.InitialPrice.IsEmpty() || request.InitialPrice.LessThan(0.01M, 2))
            {
                throw new RequiredFieldException("The initial Price has to be greater than .01");
            }
        }

        /// <summary>
        /// Validates the values for set product option price.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="RequiredFieldException">
        /// The Product Option Id is required
        /// or
        /// The Price is required. Set the flat Price.
        /// </exception>
        public static void ValidateValuesForSetProductOptionPrice(ProductOptionPriceRequest request)
        {
            if (request.Option.IsEmpty() || request.Option.id.IsEmpty())
            {
                throw new RequiredFieldException("The Product Option Id is required");
            }
            if (request.Price.FlatPrice.IsEmpty() || request.Price.FlatPrice.LessThan(0.01M, 2))
            {
                throw new RequiredFieldException("The Price is required. Set the flat Price.");
            }

        }
    }
}
