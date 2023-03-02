// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductOptionPriceTransfomer.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Exceptions;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Transformers
{
    /// <summary>
    /// Class ProductOptionPriceTransfomer.
    /// </summary>
    public class ProductOptionPriceTransfomer
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
        public static PriceModel GetClientModelFromBo(OptionPrice bo)
        {
            return new PriceModel()
            {
                Id = bo.Id.ToString(),
                StartDateTimeString = bo.Start.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                EndDateTimeString = bo.End.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                FlatPrice = bo.FlatPrice
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="productOptionPricesAreFor">The Product Option prices are for.</param>
        /// <param name="priceModel">The Price model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>ProductPrice.</returns>
        /// <exception cref="DataException">The Product Id is invalid</exception>
        public static OptionPrice GetBoFromClientModel(ProductOption productOptionPricesAreFor, PriceModel priceModel, IRepository repository)
        {
            if (productOptionPricesAreFor.IsEmpty())
            {
                throw new DataException("Invaild Call to data transformer for Product Option Price - the Product Option can not be null");
            }
            OptionPrice returnValue = null;
            if (priceModel.Id.IsNotEmpty())
            {
                DateRange allTime = new DateRange(DateTime.MinValue, DateTime.MaxValue);
                if (!int.TryParse(priceModel.Id, out int id))
                {
                    throw new DataException("The Product Price Id is invalid");
                }

                foreach (OptionPrice priceForProductOption in productOptionPricesAreFor.GetPrice(allTime))
                {
                    if (id == priceForProductOption.Id)
                    {
                        returnValue = priceForProductOption;
                        break;
                    }
                }
            }

            if (returnValue.IsEmpty())
            {
                returnValue = new OptionPrice(repository);
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
            return returnValue;
        }

    }
}
