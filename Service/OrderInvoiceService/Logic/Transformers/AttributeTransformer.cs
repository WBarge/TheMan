// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="AttributeTransformer.cs" company="OrderInvoiceService">
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
    /// Class AttributeTransformer.
    /// Class for mapping between service side models and client side models
    /// This one handles the attribute
    /// </summary>
    public class AttributeTransformer
    {
        /// <summary>
        /// transforms the Attribute bo to the client model.
        /// </summary>
        /// <param name="bo">The Attribute bo.</param>
        /// <returns>AttributeModel.</returns>
        public static AttributeModel GetClientModelFromBo(OrderInvoice_BL.Products.Attribute bo)
        {
            return new AttributeModel()
            {
                id = bo.Id.ToString(),
                name = bo.Name,
                description = bo.Description
            };
        }

        /// <summary>
        /// transforms the client bo to an instance of the bo
        /// </summary>
        /// <param name="attributeModel">The Attribute client model.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Attribute</returns>
        /// <exception cref="DataException">The attribute Id is invalid</exception>
        public static OrderInvoice_BL.Products.Attribute GetBoFromClientModel(AttributeModel attributeModel, IRepository repository)
        {
            OrderInvoice_BL.Products.Attribute attribute;
            if (attributeModel.id.IsEmpty())
            {
                attribute = new OrderInvoice_BL.Products.Attribute(repository);
            }
            else
            {
                if (!int.TryParse(attributeModel.id, out int id))
                {
                    throw new DataException("The attribute Id is invalid");
                }
                attribute = OrderInvoice_BL.Products.Attribute.GetById(id, repository);
            }
            attribute.Name = attributeModel.name;
            attribute.Description = attributeModel.description;
            return attribute;
        }

    }
}
