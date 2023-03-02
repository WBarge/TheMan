using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using Utilites;
using DataException = Exceptions.DataException;

namespace OrderInvoice_BL.Products
{
    /// <summary>
    /// Product is where you define the product the company makes
    /// and define custom made products
    /// </summary>
    public class Product : BussinessObject
    {
        #region Constants
        public const int NAME_LENGTH = 150;
        public const int DESCRIPTION_LENGTH = 255;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        private string _name;
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="InvalidLengthException">The Name field is too long</exception>
        public string Name
        {
            get { return (_name); }
            set
            {
                if (value.Length > NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The Name field is too long"));
                }
                _name = value.Trim();
            }//end of set 
        }
        private string _description;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <exception cref="InvalidLengthException">The Description field is too long</exception>
        public string Description
        {
            get { return (_description); }
            set
            {
                if (value.Length > DESCRIPTION_LENGTH)
                {
                    throw (new InvalidLengthException("The Description field is too long"));
                }
                _description = value.Trim();
            }//end of set 
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="Product"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Product(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <inheritdoc />
        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected Product(int id, IRepository repository) : this(repository)
        {
            IProducts dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

        #region Product Manipulation

        /// <inheritdoc />
        /// <summary>
        /// Permanently remove the object from the system.
        /// </summary>
        /// <exception cref="T:Exceptions.DataException">You can not delete a new object</exception>
        public override void PermanentlyRemoveFromSystem()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            Repository.DeleteProduct(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// Mark the record as deleted
        /// ie. make the item inactive
        /// </summary>
        public void Delete()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            Deleted = true;
            Update();
            Repository.SaveChanges();
        }//end of method

        #endregion Product Manipulation

        #region Attribute Manipulation

        /// <summary>
        /// Add an attribute to the product
        /// </summary>
        /// <param name="attri">the attribute to add</param>
        public void AddAttribute(Attribute attri)
        {
            if (attri.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddAttribute is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any attributes can be added to it"));
            }//end of if
            if (attri.IsNew)//the attribute is a new attribute and has not been added to the db yet
            {
                attri.Save();
            }//end of if
            Repository.AddAttributeToProduct(Id, attri.Id);
            Repository.SaveChanges();
        }//end of method

        public void ReplaceAttributes(Attribute[] attributes)
        {
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any attributes can be added to it"));
            }//end of if
            foreach (Attribute oldAttribute in GetAttributes())
            {
                Repository.RemoveAttributeFromProduct(Id, oldAttribute.Id);
            }
            foreach (Attribute attribute in attributes)
            {
                Repository.AddAttributeToProduct(Id, attribute.Id);
            }
            Repository.SaveChanges();
        }


        /// <summary>
        /// Remove an attribute from the product
        /// </summary>
        /// <param name="attri">the attribute to remove</param>
        /// <returns></returns>
        public bool RemoveAttribute(Attribute attri)
        {
            if (attri.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to RemoveAttribute is null"));
            }//end of if
            if (attri.IsNew)
            {
                throw (new ClassDependencyException("The attribute to remove has not been added to the system yet"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any attributes can be removed to it"));
            }//end of if
            bool returnValue = Repository.RemoveAttributeFromProduct(Id, attri.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Get all the active attributes for the product
        /// </summary>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetAttributes()
        {
            Attribute[] returnValues = GetAttributes(false);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the attributes for the product
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - include deleted attributes
        ///     false - do not include deleted attributes
        /// </param>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetAttributes(bool includeDeleted)
        {
            List<Attribute> returnValues = new List<Attribute>();
            IEnumerable<IAttributes> results = Repository.GetProductAttributes(Id, includeDeleted);
            foreach (IAttributes ia in results)
            {
                Attribute tempObj = new Attribute(Repository);
                tempObj.CopyPropertiesFromDbObj(ia);
                tempObj.IsNew = false;
                returnValues.Add(tempObj);
            }
            return (returnValues.ToArray());
        }//end of method

        /// <summary>
        /// Gets the names of the attributes associated with the product in a format that can allow them to be used in a formula
        /// </summary>
        /// <returns></returns>
        public string[] GetAttributesAsVariables()
        {
           return GetAttributes().Select(attribute => attribute.Name.Replace(" ","_").ToUpper()).ToArray();
        }

        #endregion Attribute Manipulation

        #region Attribute Value Manipulation

        /// <summary>
        /// add an attribute value to an attribute
        /// </summary>
        /// <param name="attributeId">the ID of the attribute</param>
        /// <param name="pav">the value</param>
        public void AddAttributeValue(int attributeId, ProductAttributeValue pav)
        {
            Attribute attribute = Attribute.GetById(attributeId, Repository);
            AddAttributeValue(attribute, pav);
        }

        /// <summary>
        /// add an attribute value to an attribute
        /// </summary>
        /// <param name="attribute">the attribute</param>
        /// <param name="productAttributeValue">the value</param>
        public void AddAttributeValue(Attribute attribute, ProductAttributeValue productAttributeValue)
        {
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any attributes can be added to it"));
            }//end of if
            if (attribute.IsNew)
            {
                throw (new RequiredFieldException("The attribute needs to be saved before any values can be added to it"));
            }
            if (!productAttributeValue.IsNew)
            {
                throw (new DataException("The attribute value needs to be a new value"));
            }
            IAttributes attributeDbObj = Repository.GetAttribute(attribute.Id);
            IProductAttributeValues productAttributeValueDbObj = Repository.CreateProductAttriValue();

            productAttributeValue.CopyPropertiesToDbObj(productAttributeValueDbObj);
            Repository.AddAttributeValueToProduct(Id, attributeDbObj, productAttributeValueDbObj);
            productAttributeValue.CopyPropertiesFromDbObj(productAttributeValueDbObj);
            productAttributeValue.IsNew = false;
            Repository.SaveChanges();
        }

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="attributeId">the id of the attribute</param>
        /// <returns></returns>
        public ProductAttributeValue[] GetAttributeValues(int attributeId)
        {
            return GetAttributeValues(attributeId, false);
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="attributeId">the id of the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns></returns>
        public ProductAttributeValue[] GetAttributeValues(int attributeId, bool includeDeleted)
        {
            return GetAttributeValues(Attribute.GetById(attributeId, Repository), includeDeleted).ToArray();
        }

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="attri">the attribute</param>
        /// <returns></returns>
        public ProductAttributeValue[] GetAttributeValues(Attribute attri)
        {
            return GetAttributeValues(attri, false).ToArray();
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="attribute">the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns></returns>
        public List<ProductAttributeValue> GetAttributeValues(Attribute attribute, bool includeDeleted)
        {
            List<ProductAttributeValue> returnValue = new List<ProductAttributeValue>();
            IAttributes attributeDbObj = Repository.GetAttribute(attribute.Id);
            IEnumerable<IProductAttributeValues> values = Repository.GetProductAttributeValues(Id, attributeDbObj, includeDeleted);
            foreach (IProductAttributeValues dbObj in values)
            {
                ProductAttributeValue tempOptionsAttributeValue = new ProductAttributeValue(Repository);
                tempOptionsAttributeValue.CopyPropertiesFromDbObj(dbObj);
                tempOptionsAttributeValue.IsNew = false;
                returnValue.Add(tempOptionsAttributeValue);
            }
            return (returnValue);
        }

        /// <summary>
        /// Replaces the attribute values.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="attributeValues">The attribute values.</param>
        public void ReplaceAttributeValues(Attribute attribute, IEnumerable<ProductAttributeValue> attributeValues)
        {
            bool found = false;
            IEnumerable<ProductAttributeValue> productAttributeValues = attributeValues as IList<ProductAttributeValue> ?? attributeValues.ToList();
            foreach (ProductAttributeValue av in productAttributeValues)
            {
                if (av.IsDefault)
                {
                    if (found)
                    {
                        throw new DataException("Only one product attribute value can be set as the default value.");
                    }
                    found = true;
                }
            }
            foreach (ProductAttributeValue productAttributeValue in GetAttributeValues(attribute.Id))
            {
                Repository.DeleteProductAttriValue(productAttributeValue.Id);
            }
            IAttributes attributeDbObj = Repository.GetAttribute(attribute.Id);
            foreach (ProductAttributeValue productAttributeValue in productAttributeValues)
            {
                IProductAttributeValues productAttributeValueDbObj = Repository.CreateProductAttriValue();

                productAttributeValue.CopyPropertiesToDbObj(productAttributeValueDbObj);
                Repository.AddAttributeValueToProduct(Id, attributeDbObj, productAttributeValueDbObj);
                productAttributeValue.CopyPropertiesFromDbObj(productAttributeValueDbObj);
                productAttributeValue.IsNew = false;
            }
            Repository.SaveChanges();
        }

        #endregion Attribute Value Manipulation

        #region Option Manipulation

        /// <summary>
        /// add an option to the product
        /// </summary>
        /// <param name="option">the option to add</param>
        public void AddOption(ProductOption option)
        {
            if (option.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddOption is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any options can be added to it"));
            }//end of if
            if (option.IsNew)//the option is a new options and has not been added to the db yet
            {
                option.Save();
            }//end of if
            Repository.AddOptionToProduct(Id, option.Id);
            Repository.SaveChanges();
        }//end of method

        /// <summary>
        /// Replaces the options for the product.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <exception cref="InvalidParameterException">The passed in parameter to ReplaceOptions is null</exception>
        /// <exception cref="RequiredFieldException">The product needs to be saved before any options can be added to it</exception>
        public void ReplaceOptions(ProductOption[] options)
        {
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any options can be added to it"));
            }//end of if
            foreach (ProductOption oldOption in GetOptions())
            {
                if (IsInOptionList(options, oldOption))
                {
                    //remove all attributes associated with the product option since
                    //the attribute is associated to the product-option association
                    oldOption.ReplaceAttributes(this,null);
                }
                Repository.RemoveOptionFromProduct(Id, oldOption.Id);
            }
            foreach (ProductOption newOption in options)
            {
                Repository.AddOptionToProduct(Id, newOption.Id);
            }
            Repository.SaveChanges();
        }

        private bool IsInOptionList(ProductOption[] options, ProductOption oldOption)
        {
            ProductOption selectedProductOption = options.FirstOrDefault(o => o.Id == oldOption.Id);
            bool returnValue = selectedProductOption != null;
            return returnValue;
        }

        /// <summary>
        /// remove an option from the product
        /// </summary>
        /// <param name="option">the option to remove</param>
        /// <returns></returns>
        public bool RemoveOption(ProductOption option)
        {
            if (option.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to RemoveOption is null"));
            }//end of if
            if (option.IsNew)
            {
                throw (new ClassDependencyException("The options to remove has not been added to the system yet"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any options can be removed to it"));
            }//end of if
            bool returnValue = Repository.RemoveOptionFromProduct(Id, option.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// get all the active options for the product
        /// </summary>
        /// <returns>
        /// an array of option objects
        /// </returns>
        public ProductOption[] GetOptions()
        {
            ProductOption[] returnValues = GetOptions(false);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the options for the product
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - include deleted options
        ///     false - do not include deleted options
        /// </param>
        /// <returns>
        ///  an array of option ojects
        /// </returns>
        public ProductOption[] GetOptions(bool includeDeleted)
        {
            List<ProductOption> returnValues = new List<ProductOption>();
            IEnumerable<IProductOptions> results = Repository.GetProductOptions(Id, includeDeleted);
            foreach (IProductOptions ia in results)
            {
                ProductOption tempObj = new ProductOption(Repository);
                tempObj.CopyPropertiesFromDbObj(ia);
                tempObj.IsNew = false;
                returnValues.Add(tempObj);
            }
            return (returnValues.ToArray());
        }//end of method

        #endregion Option Manipulation

        #region Price Manipulation

        /// <summary>
        /// Determines whether this product has a price including the default price.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has price; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPrice()
        {
            bool returnValue = false;
            returnValue = GetPrice().IsNotEmpty();
            return returnValue;
        }

        /// <summary>
        /// Determines whether [has price today] EXCLUDING the default price.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has price today] excluding the default price; otherwise, <c>false</c>.
        /// </returns>
        public bool HasPriceToday()
        {
            bool returnValue = false;
            ProductPrice todaysPrice = GetPrice(DateTime.Now);
            returnValue = todaysPrice.ValidTimePeriod.Overlaps(todaysPrice.DefaultTimePeriod);
            return returnValue;

        }

        /// <summary>
        /// Adds the option price.
        /// </summary>
        /// <param name="pop">The pop.</param>
        /// <exception cref="InvalidParameterException">The passed in parameter to AddOptionPrice is null</exception>
        /// <exception cref="RequiredFieldException">The product options needs to be saved before any price can be added to it</exception>
        /// <exception cref="DataException">The time period for the price overlaps another price. Only one price is valid for a time period.</exception>
        public void AddPrice(ProductPrice pop)
        {
            if (pop.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddPrice is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any price can be added to it"));
            }//end of if

            if (pop.Start.Kind != DateTimeKind.Utc)
            {
                pop.Start = pop.Start.ToUniversalTime();
            }

            if (pop.End.Kind != DateTimeKind.Utc)
            {
                pop.End = pop.End.ToUniversalTime();
            }

            ProductPrice[] prices = GetPrice(false, pop.ValidTimePeriod);
            ProductPrice defaultPrice = prices.FirstOrDefault(p => p.ValidTimePeriod == p.DefaultTimePeriod);
            if (defaultPrice.IsNotEmpty() && pop.IsConfiguredAsADefaultPrice())
            {
                throw (new DataException("The product already has a default price"));
            }
            prices = prices.Where(p => p.ValidTimePeriod != p.DefaultTimePeriod).ToArray();
            if (prices.IsNotEmpty())
            {
                throw (new DataException("The time period for the price overlaps another price. Only one price is valid for a time period."));
            }
            if (pop.IsNew)//the price is a new ProductPrice and has not been added to the db yet
            {
                pop.ProductId = Id;
                pop.Save();
            }//end of if
        }

        /// <summary>
        /// Gets the price for a date
        /// if there is not a price for the specified date the default price will be returned
        /// </summary>
        /// <param name="asOfDate">the date the price is for</param>
        /// <returns></returns>
        public ProductPrice GetPrice(DateTime asOfDate)
        {
            ProductPrice defaultPrice = null;
            ProductPrice returnValue = null;
            ProductPrice[] prices = GetPrice(false, asOfDate);
            foreach (ProductPrice pp in prices)
            {
                if (pp.ValidTimePeriod.Equals(pp.DefaultTimePeriod))
                {
                    defaultPrice = pp;
                }
                //besides the default price we should only have one price on a given day
                if (pp.ValidTimePeriod.Overlaps(asOfDate))
                {
                    returnValue = pp;
                    break;
                }
            }
            //if there is not a price for the date then fall back to the default price
            if (returnValue.IsEmpty())
            {
                returnValue = defaultPrice;
            }
            return (returnValue);
        }

        /// <summary>
        /// Gets the all prices
        /// </summary>
        /// <param name="includeDeleted">include any delete prices. Default is false</param>
        /// <returns></returns>
        public ProductPrice[] GetPrice(bool includeDeleted = false)
        {
            ProductPrice[] returnValues = GetPrice(includeDeleted, new DateRange(DateTime.MinValue, DateTime.MaxValue));
            return (returnValues);
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <param name="asOfDate">As of date.</param>
        /// <returns></returns>
        public ProductPrice[] GetPrice(bool includeDeleted, DateTime asOfDate)
        {
            if (asOfDate.Kind != DateTimeKind.Utc)
            {
                asOfDate = asOfDate.ToUniversalTime();
            }
            return (GetPrice(includeDeleted, new DateRange(asOfDate, asOfDate)));
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="timePeriod">The time period.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns></returns>
        public ProductPrice[] GetPrice(DateRange timePeriod, bool includeDeleted = false)
        {
            if (timePeriod.Start.Kind != DateTimeKind.Utc)
            {
                timePeriod.Start = timePeriod.Start.ToUniversalTime();
            }
            if (timePeriod.End.Kind != DateTimeKind.Utc)
            {
                timePeriod.End = timePeriod.End.ToUniversalTime();
            }
            return (GetPrice(includeDeleted, timePeriod));
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <param name="timePeriod">The time period.</param>
        /// <returns></returns>
        public ProductPrice[] GetPrice(bool includeDeleted, DateRange timePeriod)
        {
            if (timePeriod.Start.Kind != DateTimeKind.Utc)
            {
                timePeriod.Start = timePeriod.Start.ToUniversalTime();
            }
            if (timePeriod.End.Kind != DateTimeKind.Utc)
            {
                timePeriod.End = timePeriod.End.ToUniversalTime();
            }

            List<ProductPrice> returnValues = new List<ProductPrice>();
            if (isNew)
            {
                throw (new RequiredFieldException("The product needs to be saved before any price can be retrieved for it"));
            }//end of if
            foreach (IProductPrice dbObj in Repository.GetProductPrices(Id, includeDeleted))
            {
                ProductPrice productPrice = new ProductPrice(Repository);
                DateTime start = dbObj.StartDate.HasValue&&dbObj.StartDate.IsNotEmpty()?dbObj.StartDate.Value:productPrice.DefaultTime;
                DateTime end = dbObj.EndDate.HasValue&&dbObj.EndDate.IsNotEmpty()?dbObj.EndDate.Value:productPrice.DefaultTime;
                DateRange dbDateRange = new DateRange(start, end);
                if (dbDateRange.Equals(productPrice.DefaultTimePeriod) || timePeriod.WithIn(dbDateRange))
                {
                    productPrice.CopyPropertiesFromDbObj(dbObj);
                    productPrice.IsNew = false;
                    returnValues.Add(productPrice);
                }
            }
            return (returnValues.ToArray());
        }

        #endregion Price Manipulation

        #endregion Public Instance Methods

        #region Public Static Method

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static Product GetById(int id, IRepository repository)
        {
            Product returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Product(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Factory method - Gets all active objects in a list
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAll(IRepository repository)
        {
            List<Product> returnValue = GetAll(false, repository);
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - return both active and inactive objects
        ///     false - return active objects only
        /// </param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static List<Product> GetAll(bool includeDeleted, IRepository repository)
        {
            List<Product> returnValue = new List<Product>();
            IEnumerable<IProducts> tempList = repository.GetProducts();
            foreach (IProducts tempItem in tempList)
            {
                if (includeDeleted || tempItem.Deleted == false)
                {
                    Product temp = new Product(repository);
                    temp.CopyPropertiesFromDbObj(tempItem);
                    temp.isNew = false;
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected sealed override void CommonInit()
        {
            base.CommonInit();
            Name = string.Empty;
            Description = string.Empty;
            Deleted = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            if (Name.IsEmpty())
            {
                throw (new RequiredFieldException("Name is Mandatory"));
            }//end of if
            if (Description.IsEmpty())
            {
                throw (new RequiredFieldException("Description is Mandatory"));
            }//end of if			
        }

        /// <inheritdoc />
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IProducts dbObj = Repository.CreateProduct();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertProduct(dbObj);
            Id = dbObj.Objid;
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IProducts dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateProduct(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IProducts GetDbRecord(int id)
        {
            return Repository.GetProduct(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IProducts dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (Id.IsNotEmpty())
                {
                    dbObj.Objid = Id;
                }
                dbObj.Name = _name;
                dbObj.Description = _description;
                dbObj.Deleted = Deleted;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IProducts dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                Id = dbObj.Objid;
                _name = dbObj.Name;
                _description = dbObj.Description;
                Deleted = dbObj.Deleted;
            }
        }

        #endregion

        #endregion Methods

    }
}
