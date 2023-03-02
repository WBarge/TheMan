// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="ProductOptionAttributeValueTransformer.cs" company="OrderInvoiceService">
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
    /// Class ProductOptionAttributeValueTransformer.
    /// </summary>
    public class ProductOptionAttributeValueTransformer
    {
        /// <summary>
        /// transforms the Attribute Value bo to the client model.
        /// </summary>
        /// <param name="bo">The Attribute bo.</param>
        /// <returns>AttributeModel.</returns>
        public static AttributeValueModel GetClientModelFromBo(OrderInvoice_BL.Products.OptionAttributeValue bo)
        {
            return new AttributeValueModel()
            {
                id = bo.Id.ToString(),
                valueName = bo.Value,
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
        public static OrderInvoice_BL.Products.OptionAttributeValue GetBoFromClientModel(AttributeValueModel attributeModel, IRepository repository)
        {
            OrderInvoice_BL.Products.OptionAttributeValue attributeValue = null;
            if (attributeModel.id.IsEmpty())
            {
                attributeValue = new OrderInvoice_BL.Products.OptionAttributeValue(repository);
            }
            else
            {
                if (!int.TryParse(attributeModel.id, out int id))
                {
                    throw new DataException("The attribute Id is invalid");
                }
                attributeValue = OrderInvoice_BL.Products.OptionAttributeValue.GetById(id, repository);
            }
            attributeValue.Value = attributeModel.valueName;
            attributeValue.Description = attributeModel.description;
            attributeValue.IsDefault = attributeModel.isDefault;
            return attributeValue;
        }

    }
}
