// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="PackagedProductOptionDetailModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products
{
    /// <summary>
    /// Class PackagedProductOptionDetailModel.
    /// </summary>
    public class PackagedProductOptionDetailModel
    {
        /// <summary>
        /// Gets or sets the attribute.
        /// </summary>
        /// <value>The attribute.</value>
        public AttributeModel attribute { get; set; }
        /// <summary>
        /// Gets or sets the possible values.
        /// </summary>
        /// <value>The possible values.</value>
        public AttributeValueModel[] possibleValues { get; set; }
        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        /// <value>The attribute value.</value>
        public string attributeValue { get; set; }
    }
}
