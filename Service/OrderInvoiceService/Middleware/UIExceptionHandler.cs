// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-07-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="UIExceptionHandler.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OrderInvoiceService.Models;

namespace OrderInvoiceService.Middleware
{
    /// <summary>
    /// Class UiExceptionHandler.
    /// </summary>
    public class UiExceptionHandler
    {
        /// <summary>
        /// The next
        /// </summary>
        readonly RequestDelegate _next;
        /// <summary>
        /// Initializes a new instance of the <see cref="UiExceptionHandler" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public UiExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// called by the system as part of the request pipe-line
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
          
            catch (System.Exception x)
            {
                if (!context.Response.HasStarted)
                {
                    int statusCodeToSentToClient = (int)System.Net.HttpStatusCode.InternalServerError;

                    switch (x.GetType().Name)
                    {
                        case "ClassDependencyException":
                            statusCodeToSentToClient = (int)System.Net.HttpStatusCode.Conflict;
                            break;
                        case "DataException":
                        case "InvalidLengthException":
                        case "InvalidParameterException":
                        case "RequiredFieldException":
                        case "WarningException":
                        case "ZeroResultsException":
                            statusCodeToSentToClient = (int)System.Net.HttpStatusCode.BadRequest;
                            break;
                    }

                    context.Response.StatusCode = statusCodeToSentToClient;
                    await BuildResponseBodyAsync(context, x);
                }
            }
        }

        /// <summary>
        /// build response body as an asynchronous operation.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="x">The x.</param>
        /// <returns>Task.</returns>
        public async Task BuildResponseBodyAsync(HttpContext context, System.Exception x)
        {
            ErrorMessageForClient errorStruct = new ErrorMessageForClient(x);
            string stringToSendToClient = JsonConvert.SerializeObject(errorStruct);

            using (StreamWriter sw = new StreamWriter(context.Response.Body))
            {
                await sw.WriteAsync(stringToSendToClient);
            }

        }
    }
}
