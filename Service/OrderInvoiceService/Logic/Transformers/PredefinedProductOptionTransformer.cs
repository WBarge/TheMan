// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="PredefinedProductOptionTransformer.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using Exceptions;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Transformers
{
    /// <summary>
    /// Class PredefinedProductOptionTransformer.
    /// </summary>
    public class PredefinedProductOptionTransformer
    {
        /// <summary>
        /// transforms the PredefinedOption bo to the client model.
        /// </summary>
        /// <param name="bo">The bo.</param>
        /// <returns>ProductModel.</returns>
        public static PackagedProductOptionModel GetClientModelFromBo(PredefinedOption bo)
        {
            return new PackagedProductOptionModel
            {
                id = bo.Id.ToString(),
                optionId = bo.OptionId.ToString(),
                description = bo.Description
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="optionModel">The option model.</param>
        /// <param name="predefinedProduct">The predefined product.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Product.</returns>
        /// <exception cref="DataException">The Product Id is invalid</exception>
        public static PredefinedOption GetBoFromClientModel(PackagedProductOptionModel optionModel, PredefinedProduct predefinedProduct,IRepository repository)
        {
            PredefinedOption returnValue;
            if (optionModel.id.IsEmpty())
            {
                if (!int.TryParse(optionModel.optionId, out int optionId))
                {
                    throw new DataException("The option Id is invalid");
                }

                ProductOption option = Product.GetById(predefinedProduct.ProductId, repository)
                    .GetOptions().FirstOrDefault(op => op.Id == optionId);
                if (option.IsEmpty())
                {
                    throw new DataException("The option Id is invalid");
                }
                returnValue = new PredefinedOption(repository,predefinedProduct, option);
            }
            else
            {
                if (!int.TryParse(optionModel.id, out int optionId))
                {
                    throw new DataException("The Id is invalid");
                }

                returnValue = PredefinedOption.GetById(optionId, repository);
            }
            returnValue.Description = optionModel.description;
            return returnValue;
        }

    }
}
