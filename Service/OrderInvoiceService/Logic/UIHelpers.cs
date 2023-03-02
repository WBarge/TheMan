// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="UIHelpers.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Exceptions;
using OrderInvoiceService.Models.API;
using Utilites;

namespace OrderInvoiceService.Logic
{
    /// <summary>
    /// Class UIHelpers.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class UIHelpers
    {
        /// <summary>
        /// Creates the file drop down item to be used by the ngPrime drop-down control/tag on the client.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>DropDownItemModel.</returns>
        public static DropDownItemModel CreateFileDropDownItem(string label, string id, string name)
        {
            return new DropDownItemModel() { Label = label, Value = new DropDownItemValue() { Label = label, Id = id, Name = name } };
        }
    }
}
