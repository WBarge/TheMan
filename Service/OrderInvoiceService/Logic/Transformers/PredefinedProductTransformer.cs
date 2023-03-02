// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="PredefinedProductTransformer.cs" company="OrderInvoiceService">
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
    /// Class PredefinedProductTransformer.
    /// </summary>
    public class PredefinedProductTransformer
    {
        /// <summary>
        /// transforms the PredefinedProduct bo to the client model.
        /// </summary>
        /// <param name="bo">The bo.</param>
        /// <returns>ProductModel.</returns>
        public static PackagedProductModel GetClientModelFromBo(PredefinedProduct bo)
        {
            return new PackagedProductModel()
            {
                id = bo.Id.ToString(),
                productId = bo.ProductId.ToString(),
                description = bo.Description,
                price = bo.Price,
                quantity = bo.Quantity
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="productModel">The Product model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Product.</returns>
        /// <exception cref="DataException">The Product Id is invalid</exception>
        public static PredefinedProduct GetBoFromClientModel(PackagedProductModel productModel, IRepository repository)
        {
            PredefinedProduct returnValue;
            if (productModel.id.IsEmpty())
            {
                if (productModel.productId.IsEmpty() || !int.TryParse(productModel.id, out int baseProductId))
                {
                    throw new DataException("The Product Id is invalid");
                }

                Product tempProduct = Product.GetById(baseProductId, repository);
                returnValue = new PredefinedProduct(repository,tempProduct);
            }
            else
            {
                if (!int.TryParse(productModel.id, out int id))
                {
                    throw new DataException("The Predefined Product Id is invalid");
                }
                returnValue = PredefinedProduct.GetById(id, repository);
            }
            returnValue.Price = productModel.price;
            returnValue.Description = productModel.description;
            if (!int.TryParse(productModel.quantity.ToString(), out int quantity))
            {
                throw new DataException("The quantity is invalid");
            }
            returnValue.Quantity = quantity;
            return returnValue;
        }

    }
}
