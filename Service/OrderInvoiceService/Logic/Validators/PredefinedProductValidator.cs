// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="PredefinedProductValidator.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptions;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Validators
{
    /// <summary>
    /// Class PredefinedProductValidator.
    /// </summary>
    public class PredefinedProductValidator
    {
        /// <summary>
        /// Validates the packaged product model.
        /// </summary>
        /// <param name="packagedProduct">The packaged product.</param>
        /// <exception cref="RequiredFieldException">The packaged product ID or the productID is required
        /// or
        /// The quantity is required</exception>
        /// <exception cref="DataException">The quantity is not a valid integer</exception>
        public static void ValidatePackagedProductModel(PackagedProductModel packagedProduct)
        {
            if (packagedProduct.id.IsEmpty() && packagedProduct.productId.IsEmpty())
            {
                throw new RequiredFieldException("The packaged product ID or the productID is required");
            }

            if (packagedProduct.quantity.IsEmpty())
            {
                throw new RequiredFieldException("The quantity is required");
            }
            if (!int.TryParse(packagedProduct.quantity.ToString(), out int quantity))
            {
                throw new DataException("The quantity is not a valid integer");
            }
        }
    }
}
