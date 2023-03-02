// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="AttributeValuesForProductRequest.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products.Requests
{
    /// <summary>
    /// Class AttributeValuesForProductRequest.
    /// </summary>
    public class AttributeValuesForProductRequest
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ProductModel product { get; set; }
        /// <summary>
        /// Gets or sets the attribute.
        /// </summary>
        /// <value>The attribute.</value>
        public AttributeModel attribute { get; set; }
        /// <summary>
        /// Gets or sets the attribute values.
        /// </summary>
        /// <value>The attribute values.</value>
        public AttributeValueModel[] attributeValues { get; set; }
    }
}
