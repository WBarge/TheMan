using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using Utilites;

// ReSharper disable once CheckNamespace
namespace OrderInvoice_DL.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// This part of the class will hold all methods needed by the products area of the system
    /// </summary>
    public partial class Repository : IRepository
    {
		#region OptionAttriValue

		/// <inheritdoc />
		/// <summary>
		/// Gets the option attri value.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public IOptionsAttributeValues GetOptionAttriValue(int id)
		{
            return Context.OptionsAttributeValues.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the option attri values.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOptionsAttributeValues> GetOptionAttriValues()
		{
			return Context.OptionsAttributeValues.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the option attri value.
        /// </summary>
        /// <returns></returns>
        public IOptionsAttributeValues CreateOptionAttriValue()
		{
			return Context.OptionsAttributeValues.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the option attri value.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertOptionAttriValue(IOptionsAttributeValues newObj)
		{
			Context.OptionsAttributeValues.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the option attri value.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateOptionAttriValue(IOptionsAttributeValues obj)
		{
			Context.OptionsAttributeValues.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the option attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteOptionAttriValue(int id)
		{
            Context.OptionsAttributeValues.Delete(GetOptionAttriValue(id));
		}

        #endregion OptionAttriValue

        #region ProductAttriValue

        /// <inheritdoc />
		/// <summary>
        /// Gets the product attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IProductAttributeValues GetProductAttriValue(int id)
		{
            return Context.ProductAttributeValues.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the product attri values.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProductAttributeValues> GetProductAttriValues()
		{
			return Context.ProductAttributeValues.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the product attri value.
        /// </summary>
        /// <returns></returns>
        public IProductAttributeValues CreateProductAttriValue()
		{
			return Context.ProductAttributeValues.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the product attri value.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertProductAttriValue(IProductAttributeValues newObj)
		{
			Context.ProductAttributeValues.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the product attri value.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateProductAttriValue(IProductAttributeValues obj)
		{
			Context.ProductAttributeValues.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the product attri value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProductAttriValue(int id)
		{
            Context.ProductAttributeValues.Delete(GetProductAttriValue(id));
		}

	    public void AddAttributeValueToProduct(int productId, IAttributes attribute, IProductAttributeValues productAttributeValue)
	    {
	        IMtmProductAttributes connectionTable = Context.MtmProductAttributes.GetAll().FirstOrDefault(mpa => mpa.AttributeObjid == attribute.Objid && mpa.ProductObjid == productId);
	        if (connectionTable.IsNotEmpty())
	        {
	            // ReSharper disable once PossibleNullReferenceException
	            productAttributeValue.ProductAttributesObjid = connectionTable.Objid;
	            InsertProductAttriValue(productAttributeValue);
	        }

	    }


        #endregion ProductAttriValue

        #region Attribute

        /// <inheritdoc />
        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IAttributes GetAttribute(int id)
		{
            return Context.Attributes.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IAttributes> GetAttributes()
		{
			return Context.Attributes.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the attribute.
        /// </summary>
        /// <returns></returns>
        public IAttributes CreateAttribute()
		{
			return Context.Attributes.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the attribute.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertAttribute(IAttributes newObj)
		{
			Context.Attributes.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the attribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateAttribute(IAttributes obj)
		{
			Context.Attributes.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the attribute.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteAttribute(int id)
		{
            Context.Attributes.Delete(GetAttribute(id));
		}

        #endregion Attribute

        #region OptionPrice

        /// <inheritdoc />
		/// <summary>
        /// Gets the option price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IOptionPrice GetOptionPrice(int id)
		{
            return Context.OptionPrice.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the option prices.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOptionPrice> GetOptionPrices()
		{
			return Context.OptionPrice.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the option price.
        /// </summary>
        /// <returns></returns>
        public IOptionPrice CreateOptionPrice()
		{
			return Context.OptionPrice.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the option price.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertOptionPrice(IOptionPrice newObj)
		{
			Context.OptionPrice.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the option price.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateOptionPrice(IOptionPrice obj)
		{
			Context.OptionPrice.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the option price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteOptionPrice(int id)
		{
            Context.OptionPrice.Delete(GetOptionPrice(id));
		}

        #endregion OptionPrice

        #region ProductPrice

        /// <inheritdoc />
		/// <summary>
        /// Gets the product price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IProductPrice GetProductPrice(int id)
		{
            return Context.ProductPrice.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the product prices.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProductPrice> GetProductPrices()
		{
			return Context.ProductPrice.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the product price.
        /// </summary>
        /// <returns></returns>
        public IProductPrice CreateProductPrice()
		{
			return Context.ProductPrice.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the product price.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertProductPrice(IProductPrice newObj)
		{
			Context.ProductPrice.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the product price.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateProductPrice(IProductPrice obj)
		{
			Context.ProductPrice.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the product price.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProductPrice(int id)
		{
            Context.ProductPrice.Delete(GetProductPrice(id));
		}

		#endregion OptionPrice

		#region ProductOption

		/// <inheritdoc />
		/// <summary>
		/// Gets the product option.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public IProductOptions GetProductOption(int id)
		{
            return Context.ProductOptions.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the product options.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProductOptions> GetProductOptions()
		{
			return Context.ProductOptions.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the product option.
        /// </summary>
        /// <returns></returns>
        public IProductOptions CreateProductOption()
		{
			return Context.ProductOptions.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the product option.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertProductOption(IProductOptions newObj)
		{
			Context.ProductOptions.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the product option.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateProductOption(IProductOptions obj)
		{
			Context.ProductOptions.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the product option.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProductOption(int id)
		{
            Context.ProductOptions.Delete(GetProductOption(id));
		}

        /// <inheritdoc />
        /// <summary>
        /// Adds the attribute to product option.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        public void AddAttributeToProductOption(int productId, int productOptionId, int attributeId)
		{
            IMtmOptions referenceTable = Context.MtmOptions.GetAll().FirstOrDefault(po => po.ProductObjid == productId && po.OptionObjid == productOptionId);
		    if (referenceTable.IsNotEmpty())
		    {
		        IMtmOptionAttributes connectionTable = Context.MtmOptionAttributes.Create();
		        // ReSharper disable once PossibleNullReferenceException
		        connectionTable.MtmOptionObjid = referenceTable.Objid;
		        connectionTable.AttributeObjid = attributeId;
		        Context.MtmOptionAttributes.Insert(connectionTable);
		    }
		}

        /// <inheritdoc />
        /// <summary>
        /// Removes the attribute from product option.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="optionId">The option identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveAttributeFromProductOption(int productId, int optionId, int attributeId)
		{
			bool returnValue = false;
            //we have to remove and child values before we can delete the attribute
            IAttributes attributeObj = this.GetAttribute(attributeId);
		    IEnumerable<IOptionsAttributeValues> dependentValues = this.GetOptionAttributeValues(productId, optionId, attributeObj, true);
		    foreach (IOptionsAttributeValues dependentAttributeValue in dependentValues)
		    {
		        this.DeleteOptionAttriValue(dependentAttributeValue.Objid);
		    }

            IMtmOptions referenceTable = Context.MtmOptions.GetAll().FirstOrDefault(po => po.ProductObjid == productId && po.OptionObjid == optionId);
		    if (referenceTable.IsNotEmpty())
		    {
		        IMtmOptionAttributes connectionTable = Context.MtmOptionAttributes.GetAll()
                    .FirstOrDefault(mp => mp.MtmOptionObjid == referenceTable.Objid && mp.AttributeObjid == attributeId);
		        if (connectionTable.IsNotEmpty())
		        {
		            Context.MtmOptionAttributes.Delete(connectionTable);
		            returnValue = true;
		        }
		    }
		    return returnValue;
		}

        /// <inheritdoc />
        /// <summary>
        /// Gets the product option attributes.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns>IEnumerable&lt;IAttributes&gt;.</returns>
        public IEnumerable<IAttributes> GetProductOptionAttributes(int productId, int productOptionId, bool includeDeleted)
		{
			List<IAttributes> returnValue = new List<IAttributes>();
		    IMtmOptions referenceTable = Context.MtmOptions.GetAll().FirstOrDefault(po => po.ProductObjid == productId && po.OptionObjid == productOptionId);
		    if (referenceTable.IsNotEmpty())
		    {
		        List<IMtmOptionAttributes> productOption = Context.MtmOptionAttributes.GetAll().Where(po => po.MtmOptionObjid == referenceTable.Objid).ToList();
		        if (productOption.IsNotEmpty())
		        {
		            foreach (IMtmOptionAttributes obj in productOption)
		            {
		                IAttributes att = GetAttribute(obj.AttributeObjid);
		                if (includeDeleted)
		                {
		                    returnValue.Add(att);
		                }
		                else if (att.Deleted == false)
		                {
		                    returnValue.Add(att);
		                }
		            }
		        }
		    }
		    return returnValue;
		}

        /// <inheritdoc />
        /// <summary>
        /// Adds the attribute value to product option.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="optionAttributeValue">The option attribute value.</param>
        public void AddAttributeValueToProductOption(int productId, int productOptionId, IAttributes attribute, IOptionsAttributeValues optionAttributeValue)
		{
		    IMtmOptions referenceTable = Context.MtmOptions.GetAll().FirstOrDefault(po => po.ProductObjid == productId && po.OptionObjid == productOptionId);
		    if (referenceTable.IsNotEmpty())
		    {
		        IMtmOptionAttributes connectionTable = Context.MtmOptionAttributes.GetAll()
		            .FirstOrDefault(mpa => mpa.AttributeObjid == attribute.Objid && mpa.MtmOptionObjid == referenceTable.Objid);
		        if (connectionTable.IsNotEmpty())
		        {
		            // ReSharper disable once PossibleNullReferenceException
		            optionAttributeValue.OptionsAttributesObjid = connectionTable.Objid;
		            InsertOptionAttriValue(optionAttributeValue);
		        }
		    }

		}

        /// <inheritdoc />
        /// <summary>
        /// Gets the option attribute values.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productOptionId">The product option identifier.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        public IEnumerable<IOptionsAttributeValues> GetOptionAttributeValues(int productId, int productOptionId, IAttributes attribute, bool includeDeleted)
		{
			List<IOptionsAttributeValues> returnValue = new List<IOptionsAttributeValues>();
		    IMtmOptions referenceTable = Context.MtmOptions.GetAll().FirstOrDefault(po => po.ProductObjid == productId && po.OptionObjid == productOptionId);
		    if (referenceTable.IsNotEmpty())
		    {

		        IMtmOptionAttributes connectionTable = Context.MtmOptionAttributes
		            .GetAll()
		            .FirstOrDefault(mpa => mpa.AttributeObjid == attribute.Objid && mpa.MtmOptionObjid == referenceTable.Objid);
		        if (connectionTable.IsNotEmpty())
		        {
		            foreach (IOptionsAttributeValues oav in Context.OptionsAttributeValues.GetAll()
		                .Where(optAttVal => optAttVal.OptionsAttributesObjid == connectionTable.Objid)
		                .ToList())
		            {
		                if (includeDeleted || oav.Deleted == false)
		                {
		                    returnValue.Add(oav);
		                }
		            }
		        }
		    }
		    return (returnValue);
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the option prices.
		/// </summary>
		/// <param name="optionId">The option identifier.</param>
		/// <param name="timePeriod">The time period.</param>
		/// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
		/// <returns></returns>
		public IEnumerable<IOptionPrice> GetOptionPrices(int optionId, bool includeDeleted)
		{
			List<IOptionPrice> returnValue = new List<IOptionPrice>();
			foreach (IOptionPrice op in Context.OptionPrice.GetAll().Where(op => op.OptionObjid == optionId).ToList())
			{
				if (includeDeleted || op.Deleted == false)
				{
                    returnValue.Add(op);
				}
			}

			return returnValue;
		}

		#endregion ProductOption

		#region Product

		/// <inheritdoc />
		/// <summary>
		/// Gets the product.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public IProducts GetProduct(int id)
		{
            return Context.Products.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IProducts> GetProducts()
		{
			return Context.Products.GetAll().ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the product.
        /// </summary>
        /// <returns></returns>
        public IProducts CreateProduct()
		{
			return Context.Products.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertProduct(IProducts newObj)
		{
			Context.Products.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateProduct(IProducts obj)
		{
			Context.Products.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProduct(int id)
		{
            Context.Products.Delete(GetProduct(id));
		}

        /// <inheritdoc />
		/// <summary>
        /// Adds the attribute to product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        public void AddAttributeToProduct(int productId, int attributeId)
		{
            IMtmProductAttributes connectionTable = Context.MtmProductAttributes.Create();
			connectionTable.ProductObjid = productId;
			connectionTable.AttributeObjid = attributeId;
			Context.MtmProductAttributes.Insert(connectionTable);
		}

        /// <inheritdoc />
		/// <summary>
        /// Removes the attribute from product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        public bool RemoveAttributeFromProduct(int productId, int attributeId)
		{
			bool returnValue = false;
		    IAttributes attributeObj = this.GetAttribute(attributeId);
		    foreach (IProductAttributeValues productAttributeValue in this.GetProductAttributeValues(productId,attributeObj,true))
		    {
		        this.DeleteProductAttriValue(productAttributeValue.Objid);
		    }

            IMtmProductAttributes connectionTable = Context.MtmProductAttributes.GetAll().FirstOrDefault(mp => mp.ProductObjid == productId && mp.AttributeObjid == attributeId);
			if (connectionTable.IsNotEmpty())
			{
				Context.MtmProductAttributes.Delete(connectionTable);
				returnValue = true;
			}
			return returnValue;
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the product attributes.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        public IEnumerable<IAttributes> GetProductAttributes(int productId, bool includeDeleted)
		{
			List<IAttributes> returnValue = new List<IAttributes>();
            List<IMtmProductAttributes> productAtt = Context.MtmProductAttributes.GetAll().Where(po => po.ProductObjid == productId).ToList();
			if (productAtt.IsNotEmpty())
			{
				foreach (IMtmProductAttributes obj in productAtt)
				{
                    IAttributes att = Context.Attributes.GetAll().FirstOrDefault(a => a.Objid == obj.AttributeObjid);
                    if (includeDeleted)
					{
						returnValue.Add(att);
					}
                    // ReSharper disable once PossibleNullReferenceException
					else if (att.Deleted == false)
					{
						returnValue.Add(att);
					}
				}
			}
			return returnValue;
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the product attribute values.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="attribute">The attribute.</param>
		/// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
		/// <returns></returns>
		public IEnumerable<IProductAttributeValues> GetProductAttributeValues(int productId, IAttributes attribute, bool includeDeleted)
		{
            List<IProductAttributeValues> returnValue = new List<IProductAttributeValues>();
            IMtmProductAttributes connectionTableRecord = Context.MtmProductAttributes.GetAll().FirstOrDefault(mpoa => mpoa.AttributeObjid == attribute.Objid && mpoa.ProductObjid == productId);
			if (connectionTableRecord.IsNotEmpty())
			{
				foreach (IProductAttributeValues oav in Context.ProductAttributeValues.GetAll().Where(a=>a.ProductAttributesObjid == connectionTableRecord.Objid).ToList())
				{
					if (includeDeleted || oav.Deleted == false)
					{
						returnValue.Add(oav);
					}
				}
			}
			return (returnValue);
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the product prices.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		
		/// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
		/// <returns></returns>
		public IEnumerable<IProductPrice> GetProductPrices(int productId, bool includeDeleted)
		{
			List<IProductPrice> returnValue = new List<IProductPrice>();
			foreach (IProductPrice op in Context.ProductPrice.GetAll().Where(op => op.ProductObjid == productId).ToList())
			{
				if (includeDeleted || op.Deleted == false)
				{
				    returnValue.Add(op);
				}
			}

			return returnValue;
		}

		/// <inheritdoc />
		/// <summary>
		/// Adds the option to product.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="optionId">The option identifier.</param>
		public void AddOptionToProduct(int productId, int optionId)
		{
            IMtmOptions connectionTable = Context.MtmOptions.Create();
			connectionTable.ProductObjid = productId;
			connectionTable.OptionObjid = optionId;
			Context.MtmOptions.Insert(connectionTable);
		}

		/// <inheritdoc />
		/// <summary>
		/// Removes the option from product.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="optionId">The option identifier.</param>
		/// <returns></returns>
		public bool RemoveOptionFromProduct(int productId, int optionId)
		{
			bool returnValue = false;
            IMtmOptions connectionTable = Context.MtmOptions.GetAll().FirstOrDefault(mp => mp.OptionObjid == optionId && mp.ProductObjid == productId);
			if (connectionTable.IsNotEmpty())
			{
				Context.MtmOptions.Delete(connectionTable);
				returnValue = true;
			}
			return returnValue;
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the product options.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
		/// <returns></returns>
		public IEnumerable<IProductOptions> GetProductOptions(int productId, bool includeDeleted)
		{
			List<IProductOptions> returnValue = new List<IProductOptions>();
            List<IMtmOptions> products = Context.MtmOptions.GetAll().Where(po => po.ProductObjid == productId).ToList();
			if (products.IsNotEmpty())
			{
				foreach (IMtmOptions obj in products)
				{
                    IProductOptions att = GetProductOption(obj.OptionObjid);
					if (includeDeleted)
					{
						returnValue.Add(att);
					}
					else if (att.Deleted == false)
					{
						returnValue.Add(att);
					}
				}
			}
			return returnValue;
		}

		#endregion Product

		#region Predefined Product

		/// <inheritdoc />
		/// <summary>
		/// Gets the predefined product.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public IPredefinedProducts GetPredefinedProduct(int id)
		{
            return Context.PredefinedProducts.Get(id);
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the predefined products.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IPredefinedProducts> GetPredefinedProducts()
		{
			return Context.PredefinedProducts.GetAll().ToList();
		}

		/// <inheritdoc />
		/// <summary>
		/// Creates the predefined product.
		/// </summary>
		/// <returns></returns>
		public IPredefinedProducts CreatePredefinedProduct()
		{
			return Context.PredefinedProducts.Create();
		}

        /// <inheritdoc />
        /// <summary>
        /// Inserts the predefined product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertPredefinedProduct(IPredefinedProducts newObj)
		{
			Context.PredefinedProducts.Insert(newObj);
		}

		/// <inheritdoc />
		/// <summary>
		/// Updates the predefined product.
		/// </summary>
		/// <param name="obj">The object.</param>
		public void UpdatePredefinedProduct(IPredefinedProducts obj)
		{
			Context.PredefinedProducts.Update(obj);
		}

		/// <inheritdoc />
		/// <summary>
		/// Deletes the predefined product.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public void DeletePredefinedProduct(int id)
		{
			Context.PredefinedProducts.Delete(GetPredefinedProduct(id));
		}

		#endregion Predefined Product

		#region Predefined Option

		///// <summary>
		///// Gets the predefined option.
		///// </summary>
		///// <param name="id">The identifier.</param>
		///// <returns></returns>
		public IPredefinedOptions GetPredefinedOption(int id)
		{
            return Context.PredefinedOptions.Get(id);
		}

		///// <summary>
		///// Gets the predefined option.
		///// </summary>
		///// <returns></returns>
		public IEnumerable<IPredefinedOptions> GetPredefinedOptions()
		{
			return Context.PredefinedOptions.GetAll().ToList();
		}

		///// <summary>
		///// Creates the predefined option.
		///// </summary>
		///// <returns></returns>
		public IPredefinedOptions CreatePredefinedOption()
		{
			return Context.PredefinedOptions.Create();
		}

		///// <summary>
		///// Inserts the predefined option.
		///// </summary>
		///// <param name="newObj">The new object.</param>
		public void InsertPredefinedOption(IPredefinedOptions newObj)
		{
			Context.PredefinedOptions.Insert(newObj);
		}

		///// <summary>
		///// Updates the predefined option.
		///// </summary>
		///// <param name="obj">The object.</param>
		public void UpdatePredefinedOption(IPredefinedOptions obj)
		{
			Context.PredefinedOptions.Update(obj);
		}

		///// <summary>
		///// Deletes the predefined option.
		///// </summary>
		///// <param name="id">The identifier.</param>
		public void DeletePredefinedOption(int id)
		{
			Context.PredefinedOptions.Delete(GetPredefinedOption(id));
		}

		#endregion Predefined Product

		#region Predefined Product Detail

		/// <inheritdoc />
		/// <summary>
		/// Gets the predefined product Detail.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public IPredefinedProductDetail GetPredefinedProductDetail(int id)
		{
            return Context.PredefinedProductDetail.Get(id);
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the predefined product Details.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IPredefinedProductDetail> GetPredefinedProductDetails(int ppi)
		{
			return Context.PredefinedProductDetail.GetAll().Where(p=>p.PredefinedProductObjid == ppi).ToList();
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the predefined product detail for attribute.
		/// </summary>
		/// <param name="ppi">The predefined product identifier.</param>
		/// <param name="attributeId">The attribute identifier.</param>
		/// <returns></returns>
		public IPredefinedProductDetail GetPredefinedProductDetailForAttribute(int ppi, int attributeId)
		{
            IPredefinedProductDetail obj = Context.PredefinedProductDetail.GetAll().FirstOrDefault(p => p.PredefinedProductObjid == ppi && p.AttributeObjid == attributeId);
			return obj;
		}


        /// <inheritdoc />
		/// <summary>
        /// Creates the predefined product Detail.
        /// </summary>
        /// <returns></returns>
        public IPredefinedProductDetail CreatePredefinedProductDetail()
		{
			return Context.PredefinedProductDetail.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the predefined product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertPredefinedProductDetail(IPredefinedProductDetail newObj)
		{
			Context.PredefinedProductDetail.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the predefined product.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdatePredefinedProductDetail(IPredefinedProductDetail obj)
		{
			Context.PredefinedProductDetail.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the predefined product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeletePredefinedProductDetail(int id)
		{
			Context.PredefinedProductDetail.Delete(GetPredefinedProductDetail(id));
		}

        #endregion Predefined Product Detail

        #region Predefined Option Detail

        /// <inheritdoc />
		/// <summary>
        /// Gets the predefined Option Detail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IPredefinedOptionDetail GetPredefinedOptionDetail(int id)
		{
			return Context.PredefinedOptionDetail.Get(id);
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the predefined product Details.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPredefinedOptionDetail> GetPredefinedOptionDetails(int ppi)
		{
			return Context.PredefinedOptionDetail.GetAll().Where(p => p.PredefinedOptionObjid == ppi).ToList();
		}

        /// <inheritdoc />
		/// <summary>
        /// Gets the predefined product detail for attribute.
        /// </summary>
        /// <param name="ppi">The predefined product identifier.</param>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns></returns>
        public IPredefinedOptionDetail GetPredefinedOptionDetailForAttribute(int ppi, int attributeId)
		{
			return Context.PredefinedOptionDetail.GetAll().FirstOrDefault(p => p.PredefinedOptionObjid == ppi && p.AttribuiteObjid == attributeId);
		}

        /// <inheritdoc />
		/// <summary>
        /// Creates the predefined product Detail.
        /// </summary>
        /// <returns></returns>
        public IPredefinedOptionDetail CreatePredefinedOptionDetail()
		{
			return Context.PredefinedOptionDetail.Create();
		}

        /// <inheritdoc />
		/// <summary>
        /// Inserts the predefined product.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertPredefinedOptionDetail(IPredefinedOptionDetail newObj)
		{
			Context.PredefinedOptionDetail.Insert(newObj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Updates the predefined product.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdatePredefinedOptionDetail(IPredefinedOptionDetail obj)
		{
			Context.PredefinedOptionDetail.Update(obj);
		}

        /// <inheritdoc />
		/// <summary>
        /// Deletes the predefined product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeletePredefinedOptionDetail(int id)
		{
			Context.PredefinedOptionDetail.Delete(GetPredefinedOptionDetail(id));
		}

		#endregion Predefined Option Detail

	}
}
