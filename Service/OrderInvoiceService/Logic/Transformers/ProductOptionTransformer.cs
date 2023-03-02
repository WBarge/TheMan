// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductOptionTransformer.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptions;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Transformers
{
    /// <summary>
    /// Class ProductOptionTransformer.
    /// Class for mapping between service side models and client side models
    /// This one handles the Product option
    /// </summary>
    public class ProductOptionTransformer
    {
        /// <summary>
        /// transforms the Product option bo to the client model.
        /// </summary>
        /// <param name="bo">The bo.</param>
        /// <returns>ProductOptionModel.</returns>
        public static ProductOptionModel GetClientModelFromBo(ProductOption bo)
        {
            return new ProductOptionModel()
            {
                id = bo.Id.ToString(),
                name = bo.Name,
                description = bo.Description
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="productOptionModel">The Product option model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Product.</returns>
        /// <exception cref="DataException">The Product option Id is invalid</exception>
        public static ProductOption GetBoFromClientModel(ProductOptionModel productOptionModel, IRepository repository)
        {
            ProductOption productOption;
            if (productOptionModel.id.IsEmpty())
            {
                productOption = new ProductOption(repository);
            }
            else
            {
                if (!int.TryParse(productOptionModel.id, out int id))
                {
                    throw new DataException("The Product option Id is invalid");
                }
                productOption = ProductOption.GetById(id, repository);
            }
            productOption.Name = productOptionModel.name;
            productOption.Description = productOptionModel.description;
            return productOption;
        }
    }
}
