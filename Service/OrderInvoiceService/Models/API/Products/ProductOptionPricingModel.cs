// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductOptionPricingModel.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Models.API.Products
{
    /// <summary>
    /// Class ProductOptionPricingModel.
    /// </summary>
    public class ProductOptionPricingModel
    {
        /// <summary>
        /// Gets or sets the option.
        /// </summary>
        /// <value>The option.</value>
        public ProductOptionModel Option { get; set; }
        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        /// <value>The prices.</value>
        public PriceModel[] Prices { get; set; }
        // Formulas are not currently supported for product options
        // this is a place holder in case we change that
        //public string[] FormulaVariables { get; set; }
    }
}
