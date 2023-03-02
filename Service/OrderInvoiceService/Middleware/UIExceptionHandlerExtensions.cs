// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-07-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="UIExceptionHandlerExtensions.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Builder;

namespace OrderInvoiceService.Middleware
{
    /// <summary>
    /// Class UiExceptionHandlerExtensions.
    /// </summary>
    public static class UiExceptionHandlerExtensions
    {
        /// <summary>
        /// Uses the UI exception handler.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IApplicationBuilder.</returns>
        public static IApplicationBuilder UseUIExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UiExceptionHandler>();
        }
    }
}
