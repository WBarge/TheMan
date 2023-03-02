// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductPricingModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products
{
    /// <summary>
    /// Class ProductPricingModel.
    /// </summary>
    public class ProductPricingModel
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public ProductModel Product { get; set; }
        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>The prices.</value>
        public PriceModel[] Prices { get; set; }
        /// <summary>
        /// Gets or sets the formula variables.
        /// </summary>
        /// <value>The formula variables.</value>
        public string[] FormulaVariables { get; set; }
    }
}
