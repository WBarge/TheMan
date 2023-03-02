// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductAttributeValueTransformer.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptions;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API.Products;
using Utilites;

namespace OrderInvoiceService.Logic.Transformers
{
    /// <summary>
    /// Class ProductAttributeValueTransformer.
    /// </summary>
    public class ProductAttributeValueTransformer
    {
        /// <summary>
        /// transforms the Attribute Value bo to the client model.
        /// </summary>
        /// <param name="bo">The Attribute bo.</param>
        /// <returns>AttributeModel.</returns>
        public static AttributeValueModel GetClientModelFromBo(OrderInvoice_BL.Products.ProductAttributeValue bo)
        {
            return new AttributeValueModel()
            {
                id = bo.Id.ToString(),
                valueName = bo.ValueName,
                description = bo.Description,
                isDefault = bo.IsDefault
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="attributeModel">The Attribute client model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Attribute</returns>
        /// <exception cref="DataException">The attribute Id is invalid</exception>
        public static OrderInvoice_BL.Products.ProductAttributeValue GetBoFromClientModel(AttributeValueModel attributeModel, IRepository repository)
        {
            OrderInvoice_BL.Products.ProductAttributeValue attributeValue = null;
            if (attributeModel.id.IsEmpty())
            {
                attributeValue = new OrderInvoice_BL.Products.ProductAttributeValue(repository);
            }
            else
            {
                if (!int.TryParse(attributeModel.id, out int id))
                {
                    throw new DataException("The attribute Id is invalid");
                }
                attributeValue = OrderInvoice_BL.Products.ProductAttributeValue.GetById(id, repository);
            }
            attributeValue.ValueName = attributeModel.valueName;
            attributeValue.Description = attributeModel.description;
            attributeValue.IsDefault = attributeModel.isDefault;
            return attributeValue;
        }
    }
}
