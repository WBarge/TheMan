// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-07-2021
//
// Last Modified By : Admin
// Last Modified On : 02-07-2021
// ***********************************************************************
// <copyright file="ErrorMessageForClient.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderInvoiceService.Models
{
    /// <summary>
    /// Class ErrorMessageForClient.
    /// </summary>
    public class ErrorMessageForClient
    {
        //the variables are in lower case so the client can handle them and match the object names in JS
        //JS variables start in lower case
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string message { get; set; }
        /// <summary>
        /// Gets or sets the type of the exception.
        /// </summary>
        /// <value>The type of the exception.</value>
        public string exceptionType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessageForClient"/> class.
        /// </summary>
        public ErrorMessageForClient() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessageForClient"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        public ErrorMessageForClient(System.Exception x)
        {
            message = x.Message;
            exceptionType = x.GetType().Name;
        }
    }
}
