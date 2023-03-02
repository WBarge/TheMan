// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-24-2021
// ***********************************************************************
// <copyright file="Assests.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

namespace OrderInvoiceService.Logic
{
    /// <summary>
    /// Class Assets.
    /// </summary>
    public class Assets
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        /// <summary>
        /// The application root
        /// </summary>
        private readonly string _applicationRoot;
        /// <summary>
        /// The assets path
        /// </summary>
        private readonly string _assetsPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assets" /> class.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        public Assets(string rootPath)
        {
            _applicationRoot = rootPath;
            _assetsPath = Path.Combine(_applicationRoot, Constants.AssestLocation);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is assets folder present.
        /// </summary>
        /// <value><c>true</c> if this instance is assets folder present; otherwise, <c>false</c>.</value>
        public bool IsAssetsFolderPresent
        {
            get
            {
                // ReSharper disable once ArrangeAccessorOwnerBody
                return Directory.Exists(_assetsPath);
            }
        }

        /// <summary>
        /// Creates the folder.
        /// </summary>
        public void CreateFolder()
        {
            if (!IsAssetsFolderPresent)
            {
                Directory.CreateDirectory(_assetsPath);
            }
        }

        /// <summary>
        /// Pushes to location.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="content">The content.</param>
        public void PushToLocation(string name, byte[] content)
        {
            string qualifiedFileName = Path.Combine(_assetsPath, name);
            if (File.Exists(qualifiedFileName))
            {
                File.Delete(qualifiedFileName);
            }
            File.WriteAllBytes(qualifiedFileName, content);
        }
    }
}
