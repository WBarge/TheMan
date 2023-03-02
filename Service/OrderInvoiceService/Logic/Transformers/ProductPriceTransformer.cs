// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductPriceTransformer.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Exceptions;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Transformers
{
    /// <summary>
    /// Class ProductPriceTransformer.
    /// </summary>
    public class ProductPriceTransformer
    {
        /// <summary>
        /// The datetime maxvalue
        /// </summary>
        private const string DATETIME_MAXVALUE = "9999-12-31T23:59:59.999Z";

        /// <summary>
        /// Gets the client model from bo.
        /// </summary>
        /// <param name="bo">The bo.</param>
        /// <returns>PriceModel.</returns>
        public static PriceModel GetClientModelFromBo(ProductPrice bo)
        {
            return new PriceModel()
            {
                Id = bo.Id.ToString(),
                StartDateTimeString = bo.Start.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                EndDateTimeString = bo.End.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                FlatPrice = bo.FlatPrice,
                FormulaPrice= bo.FormulaPrice

            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="productPricesAreFor">The Product prices are for.</param>
        /// <param name="priceModel">The Price model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>ProductPrice.</returns>
        /// <exception cref="DataException">The Product Id is invalid</exception>
        public static ProductPrice GetBoFromClientModel(Product productPricesAreFor, PriceModel priceModel , IRepository repository)
        {
            if (productPricesAreFor.IsEmpty())
            {
                throw new DataException("Invaild Call to data transformer for Product Price - the Product can not be null");
            }
            ProductPrice returnValue = null;
            if (priceModel.Id.IsNotEmpty())
            {
                DateRange allTime = new DateRange(DateTime.MinValue, DateTime.MaxValue);
                if (!int.TryParse(priceModel.Id, out int id))
                {
                    throw new DataException("The Product Price Id is invalid");
                }

                foreach (ProductPrice priceForProduct in productPricesAreFor.GetPrice(allTime))
                {
                    if (id == priceForProduct.Id)
                    {
                        returnValue = priceForProduct;
                        break;
                    }
                }
            }

            if (returnValue.IsEmpty())
            {
                returnValue = new ProductPrice(repository);
            }

            // ReSharper disable once PossibleNullReferenceException
            if (priceModel.StartDateTimeString != DATETIME_MAXVALUE)
            {
                //this check is a work around for the parse to UTC convertion being off by 1 second
                returnValue.Start = DateTime.Parse(priceModel.StartDateTimeString).ToUniversalTime();
            }

            if (priceModel.EndDateTimeString != DATETIME_MAXVALUE)
            {
                //this check is a work around for the parse to UTC convertion being off by 1 second
                // ReSharper disable once PossibleNullReferenceException
                returnValue.End = DateTime.Parse(priceModel.EndDateTimeString).Date.ToUniversalTime();
            }
            // ReSharper disable once PossibleNullReferenceException
            returnValue.SetPrice(priceModel.FlatPrice);
            if (priceModel.FormulaPrice.IsNotEmpty())
            {
                returnValue.SetPrice(priceModel.FormulaPrice, out List<string> errors);
                if (errors.IsNotEmpty())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string error in errors)
                    {
                        sb.Append($"{error} \r\n");
                    }

                    string errorMsg = $"The formula has the following errors : \r\n {sb}";
                    throw  new DataException(errorMsg);
                }
            }

            return returnValue;
        }

    }
}
