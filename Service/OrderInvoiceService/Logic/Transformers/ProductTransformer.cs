// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ProductTransformer.cs" company="OrderInvoiceService">
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
    /// Class ProductTransformer.
    /// Class for mapping between service side models and client side models
    /// This one handles the Product
    /// </summary>
    public class ProductTransformer
    {
        /// <summary>
        /// transforms the Product bo to the client model.
        /// </summary>
        /// <param name="bo">The bo.</param>
        /// <returns>ProductModel.</returns>
        public static ProductModel GetClientModelFromBo(Product bo)
        {
            return new ProductModel()
            {
                id = bo.Id.ToString(),
                name = bo.Name,
                description = bo.Description
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="productModel">The Product model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Product.</returns>
        /// <exception cref="DataException">The Product Id is invalid</exception>
        public static Product GetBoFromClientModel(ProductModel productModel, IRepository repository)
        {
            Product returnValue;
            if (productModel.id.IsEmpty())
            {
                returnValue = new Product(repository);
            }
            else
            {
                if (!int.TryParse(productModel.id, out int id))
                {
                    throw new DataException("The Product Id is invalid");
                }
                returnValue = Product.GetById(id, repository);
            }
            returnValue.Name = productModel.name;
            returnValue.Description = productModel.description;
            return returnValue;
        }
    }
}
