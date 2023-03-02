using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// This part of the class will hold all methods needed by the products area of the system
    /// </summary>
    public partial interface IRepository
    {
        #region OptionAttriValue
        /// <summary>
        /// Gets the option attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IOptionsAttributeValues GetOptionAttriValue(int id);
        /// <summary>
        /// Gets the option attri values.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IOptionsAttributeValues> GetOptionAttriValues();
        /// <summary>
        /// Creates the option attri value.
        /// </summary>
        /// <returns></returns>
        IOptionsAttributeValues CreateOptionAttriValue();
        /// <summary>
        /// Inserts the option attri value.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertOptionAttriValue(IOptionsAttributeValues newObj);
        /// <summary>
        /// Updates the option attri value.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateOptionAttriValue(IOptionsAttributeValues obj);
        /// <summary>
        /// Deletes the option attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteOptionAttriValue(int id);
        #endregion OptionAttriValue

        #region ProductAttriValue
        /// <summary>
        /// Gets the product attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IProductAttributeValues GetProductAttriValue(int id);
        /// <summary>
        /// Gets the product attri values.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProductAttributeValues> GetProductAttriValues();
        /// <summary>
        /// Creates the product attri value.
        /// </summary>
        /// <returns></returns>
        IProductAttributeValues CreateProductAttriValue();
        /// <summary>
        /// Inserts the product attri value.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertProductAttriValue(IProductAttributeValues newObj);
        /// <summary>
        /// Updates the product attri value.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateProductAttriValue(IProductAttributeValues obj);
        /// <summary>
        /// Deletes the product attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteProductAttriValue(int id);
        #endregion ProductAttriValue

        #region Attribute
        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IAttributes GetAttribute(int id);
        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IAttributes> GetAttributes();
        /// <summary>
        /// Creates the attribute.
        /// </summary>
        /// <returns></returns>
        IAttributes CreateAttribute();
        /// <summary>
        /// Inserts the attribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertAttribute(IAttributes newObj);
        /// <summary>
        /// Updates the attribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateAttribute(IAttributes obj);
        /// <summary>
        /// Deletes the attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteAttribute(int id);
        #endregion Attribute

        #region OptionPrice
        /// <summary>
        /// Gets the option price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IOptionPrice GetOptionPrice(int id);
        /// <summary>
        /// Gets the option prices.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IOptionPrice> GetOptionPrices();
        /// <summary>
        /// Creates the option price.
        /// </summary>
        /// <returns></returns>
        IOptionPrice CreateOptionPrice();
        /// <summary>
        /// Inserts the option price.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertOptionPrice(IOptionPrice newObj);
        /// <summary>
        /// Updates the option price.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateOptionPrice(IOptionPrice obj);
        /// <summary>
        /// Deletes the option price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteOptionPrice(int id);
        #endregion OptionPrice

        #region ProductPrice
        /// <summary>
        /// Gets the product price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IProductPrice GetProductPrice(int id);
        /// <summary>
        /// Gets the product prices.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProductPrice> GetProductPrices();
        /// <summary>
        /// Creates the product price.
        /// </summary>
        /// <returns></returns>
        IProductPrice CreateProductPrice();
        /// <summary>
        /// Inserts the product price.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertProductPrice(IProductPrice newObj);
        /// <summary>
        /// Updates the product price.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateProductPrice(IProductPrice obj);
        /// <summary>
        /// Deletes the product price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteProductPrice(int id);
        #endregion ProductPrice

        #region ProductOption
        /// <summary>
        /// Gets the product option.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IProductOptions GetProductOption(int id);
        /// <summary>
        /// Gets the product options.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProductOptions> GetProductOptions();
        /// <summary>
        /// Creates the product option.
        /// </summary>
        /// <returns></returns>
        IProductOptions CreateProductOption();
        /// <summary>
        /// Inserts the product option.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertProductOption(IProductOptions newObj);
        /// <summary>
        /// Updates the product option.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateProductOption(IProductOptions obj);
        /// <summary>
        /// Deletes the product option.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteProductOption(int id);
        /// <summary>
        /// Adds the attribute to product option.
        /// </summary>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        void AddAttributeToProductOption(int productId, int productOptionId, int attributeId);
        /// <summary>
        /// Removes the attribute from product option.
        /// </summary>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        bool RemoveAttributeFromProductOption(int productId, int productOptionId, int attributeId);
        /// <summary>
        /// Gets the product option attributes.
        /// </summary>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IAttributes> GetProductOptionAttributes(int productId, int productOptionId, bool includeDeleted);
        /// <summary>
        /// Adds the attribute value to product option.
        /// </summary>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="optionAttributeValue">The option attribute value.</param>
        void AddAttributeValueToProductOption(int productId, int productOptionId, IAttributes attribute, IOptionsAttributeValues optionAttributeValue);
        /// <summary>
        /// Gets the option attribute values.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IOptionsAttributeValues> GetOptionAttributeValues(int productId, int productOptionId, IAttributes attribute, bool includeDeleted);
        /// <summary>
        /// Gets the option prices.
        /// </summary>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="timePeriod">The time period.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IOptionPrice> GetOptionPrices(int productOptionId, bool includeDeleted);
        #endregion ProductOption

        #region Product
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IProducts GetProduct(int id);
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProducts> GetProducts();
        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <returns></returns>
        IProducts CreateProduct();
        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertProduct(IProducts newObj);
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateProduct(IProducts obj);
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteProduct(int id);
        /// <summary>
        /// Adds the attribute to product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        void AddAttributeToProduct(int productId, int attributeId);
        /// <summary>
        /// Removes the attribute from product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        bool RemoveAttributeFromProduct(int productId, int attributeId);
        /// <summary>
        /// Gets the product attributes.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IAttributes> GetProductAttributes(int productId, bool includeDeleted);
        /// <summary>
        /// Adds the attribute value to product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="productAttributeValue">The product attribute value.</param>
        void AddAttributeValueToProduct(int productId, IAttributes attribute, IProductAttributeValues productAttributeValue);
        /// <summary>
        /// Gets the product attribute values.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IProductAttributeValues> GetProductAttributeValues(int productId, IAttributes attribute, bool includeDeleted);
        /// <summary>
        /// Gets the product prices.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="timePeriod">The time period.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IProductPrice> GetProductPrices(int productId, bool includeDeleted);
        /// <summary>
        /// Adds the option to product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="optionId">The option identifier.</param>
        void AddOptionToProduct(int productId, int optionId);
        /// <summary>
        /// Removes the option from product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="optionId">The option identifier.</param>
        /// <returns></returns>
        bool RemoveOptionFromProduct(int productId, int optionId);
        /// <summary>
        /// Gets the product options.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        IEnumerable<IProductOptions> GetProductOptions(int productId, bool includeDeleted);
        #endregion Product

        #region Predefined Product

        /// <summary>
        /// Gets the predefined product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IPredefinedProducts GetPredefinedProduct(int id);

        /// <summary>
        /// Gets the predefined products.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPredefinedProducts> GetPredefinedProducts();

        /// <summary>
        /// Creates the predefined product.
        /// </summary>
        /// <returns></returns>
        IPredefinedProducts CreatePredefinedProduct();

        /// <summary>
        /// Inserts the predefined product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertPredefinedProduct(IPredefinedProducts newObj);

        /// <summary>
        /// Updates the predefined product.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdatePredefinedProduct(IPredefinedProducts obj);

        /// <summary>
        /// Deletes the predefined product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePredefinedProduct(int id);

        #endregion Predefined Product

        #region Predefined Product Option

        ///// <summary>
        ///// Gets the predefined option.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        IPredefinedOptions GetPredefinedOption(int id);

        ///// <summary>
        ///// Gets the predefined option.
        ///// </summary>
        ///// <returns></returns>
        IEnumerable<IPredefinedOptions> GetPredefinedOptions();

        ///// <summary>
        ///// Creates the predefined option.
        ///// </summary>
        ///// <returns></returns>
        IPredefinedOptions CreatePredefinedOption();

        ///// <summary>
        ///// Inserts the predefined option.
        ///// </summary>
        ///// <param name="newObj">The new object.</param>
        void InsertPredefinedOption(IPredefinedOptions newObj);

        ///// <summary>
        ///// Updates the predefined option.
        ///// </summary>
        ///// <param name="obj">The object.</param>
        void UpdatePredefinedOption(IPredefinedOptions obj);

        ///// <summary>
        ///// Deletes the predefined option.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        void DeletePredefinedOption(int id);

        #endregion Predefined Product

        #region Predefined Product Detail

        /// <summary>
        /// Gets the predefined product Detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IPredefinedProductDetail GetPredefinedProductDetail(int id);

        /// <summary>
        /// Gets the predefined product Details.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPredefinedProductDetail> GetPredefinedProductDetails(int id);

        /// <summary>
        /// Gets the predefined product detail for attribute.
        /// </summary>
        /// <param name="ppi">The predefined product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        IPredefinedProductDetail GetPredefinedProductDetailForAttribute(int ppi, int attributeId);

        /// <summary>
        /// Creates the predefined product Detail.
        /// </summary>
        /// <returns></returns>
        IPredefinedProductDetail CreatePredefinedProductDetail();

        /// <summary>
        /// Inserts the predefined product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertPredefinedProductDetail(IPredefinedProductDetail newObj);

        /// <summary>
        /// Updates the predefined product.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdatePredefinedProductDetail(IPredefinedProductDetail obj);

        /// <summary>
        /// Deletes the predefined product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePredefinedProductDetail(int id);

        #endregion Predefined Product Detail

        #region Predefined Option Detail

        /// <summary>
        /// Gets the predefined Option Detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IPredefinedOptionDetail GetPredefinedOptionDetail(int id);

        /// <summary>
        /// Gets the predefined Option Details.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPredefinedOptionDetail> GetPredefinedOptionDetails(int id);

        /// <summary>
        /// Gets the predefined product detail for attribute.
        /// </summary>
        /// <param name="ppi">The predefined product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        IPredefinedOptionDetail GetPredefinedOptionDetailForAttribute(int ppi, int attributeId);

        /// <summary>
        /// Creates the predefined Option Detail.
        /// </summary>
        /// <returns></returns>
        IPredefinedOptionDetail CreatePredefinedOptionDetail();

        /// <summary>
        /// Inserts the predefined Option.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertPredefinedOptionDetail(IPredefinedOptionDetail newObj);

        /// <summary>
        /// Updates the predefined Option.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdatePredefinedOptionDetail(IPredefinedOptionDetail obj);

        /// <summary>
        /// Deletes the predefined Option.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePredefinedOptionDetail(int id);

        #endregion Predefined Option Detail
    }
}
