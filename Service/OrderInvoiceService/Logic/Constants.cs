// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="Constants.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace OrderInvoiceService.Logic
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    public static class Constants
    {
        //security constants
        /// <summary>
        /// The security scheme name
        /// </summary>
        public const string SecuritySchemeName = "Cookie";
        /// <summary>
        /// The admin policy name
        /// </summary>
        public const string AdminPolicyName = "AdministratorOnly";
        /// <summary>
        /// All users policy name
        /// </summary>
        public const string AllUsersPolicyName = "All_Users";
        /// <summary>
        /// The admin role name
        /// </summary>
        public const string AdminRoleName = "Administrator";
        /// <summary>
        /// The standard user role name
        /// </summary>
        public const string StandardUserRoleName = "User";

        //system constants
        /// <summary>
        /// The assest location
        /// </summary>
        public const string AssestLocation = "Assets";
        /// <summary>
        /// The banner file name
        /// </summary>
        public const string BannerFileName = "BannerFileName";
        /// <summary>
        /// The footer file name
        /// </summary>
        public const string FooterFileName = "FooterFileName";

        //Customer constants
        /// <summary>
        /// The default password
        /// </summary>
        public const string DefaultPassword = "password";
    }
}
