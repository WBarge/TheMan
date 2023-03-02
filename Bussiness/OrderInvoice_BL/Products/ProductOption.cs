using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class ProductOption : BussinessObject
    {
        #region Constants
        public const int MaxNameLength = 150;
        public const int MaxDescriptionLength = 255;
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
                if (value.Length > MaxNameLength)
                {
                    throw (new InvalidLengthException("The Name field is too long"));
                }
                else
                {
                    _name = value.Trim();
                }//end of if-else
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
                if (value.Length > MaxDescriptionLength)
                {
                    throw (new InvalidLengthException("The Description field is too long"));
                }
                else
                {
                    _description = value.Trim();
                }//end of if-else
            }//end of set 
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="ProductOption"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProductOption(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        protected ProductOption(int id, IRepository repository) : this(repository)
        {
            IProductOptions dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

        #region ProductOption Manipulation

        /// <summary>
        /// Permanently remove the object from the system.
        /// </summary>
        /// <exception cref="DataException">You can not delete a new object</exception>
        public override void PermanentlyRemoveFromSystem()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            Repository.DeleteProductOption(Id);
            Repository.SaveChanges();
            IsNew = true;
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

        #endregion ProductOption Manipulation

        #region Attribute Manipulation

        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="attri">The attri.</param>
        /// <exception cref="InvalidParameterException">The passed in parameter to AddAttribute is null</exception>
        /// <exception cref="RequiredFieldException">The product option needs to be saved before any attributes can be added to it</exception>
        public void AddAttribute(Product product, Attribute attri)
        {
            if (product.IsEmpty())
            {
                throw(new InvalidParameterException("The passed in parameter (product) to AddAttribute is null"));
            }
            if (product.IsNew)
            {
                throw (new DataException("The product has to be saved before being used"));
            }
            if (attri.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter (attri) to AddAttribute is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The product option needs to be saved before any attributes can be added to it"));
            }//end of if
            if (attri.IsNew)//the attribute is a new attribute and has not been added to the db yet
            {
                attri.Save();
            }//end of if
            Repository.AddAttributeToProductOption(product.Id, Id, attri.Id);
            Repository.SaveChanges();
        }//end of method

        /// <summary>
        /// Removes the attribute.
        /// </summary>
        /// <param name="attri">The attri.</param>
        /// <returns></returns>
        /// <exception cref="InvalidParameterException">The passed in parameter to RemoveAttribute is null</exception>
        /// <exception cref="ClassDependancy">The attribute to remove has not been added to the system yet</exception>
        /// <exception cref="RequiredFieldException">The product needs to be saved before any attributes can be removed to it</exception>
        public bool RemoveAttribute(Product product, Attribute attri)
        {
            bool returnValue = false;
            if (product.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter (product) to RemoveAttribute is null"));
            }
            if (product.IsNew)
            {
                throw (new DataException("The product has to be saved before being used"));
            }
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
                throw (new RequiredFieldException("The product option needs to be saved before any attributes can be removed from it"));
            }//end of if
            returnValue = Repository.RemoveAttributeFromProductOption(product.Id, Id, attri.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Get all the active attributes for the product
        /// </summary>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetAttributes(Product product)
        {
            Attribute[] returnValues = null;
            returnValues = GetAttributes(product,false);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the attributes for the product
        /// </summary>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetAttributes(Product product, bool includeDeleted)
        {
            List<Attribute> returnValues = new List<Attribute>();
            IEnumerable<IAttributes> results = Repository.GetProductOptionAttributes(product.Id, Id, includeDeleted);
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
        /// Replaces the attributes for the option.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attributes">The attributes.</param>
        /// <exception cref="InvalidParameterException">
        /// The passed in parameter (product) to ReplaceAttributes is null
        /// or
        /// The passed in parameter to RemoveAttribute is null
        /// </exception>
        /// <exception cref="DataException">The product has to be saved before being used</exception>
        /// <exception cref="RequiredFieldException">The product option needs to be saved before any attributes can be removed from it</exception>
        /// <exception cref="ClassDependencyException">An attribute to replace has not been added to the system yet</exception>
        public void ReplaceAttributes(Product product, Attribute[] attributes)
        {
            if (product.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter (product) to ReplaceAttributes is null"));
            }
            if (product.IsNew)
            {
                throw (new DataException("The product has to be saved before being used"));
            }
            if (isNew)
            {
                throw (new RequiredFieldException("The product option needs to be saved before any attributes can be removed from it"));
            }//end of if
            foreach (Attribute attribute in this.GetAttributes(product))
            {
                Repository.RemoveAttributeFromProductOption(product.Id, Id, attribute.Id);
            }
            if (attributes.IsNotEmpty())
            {
                foreach (Attribute attribute in attributes)
                {
                    if (attribute.IsNew)
                    {
                        throw (new ClassDependencyException(
                            "An attribute to replace has not been added to the system yet"));
                    } //end of if
                    Repository.AddAttributeToProductOption(product.Id, Id, attribute.Id);
                }
            }
            Repository.SaveChanges();
        }

        #endregion Attribute Manipulation

        #region Attribute Value Manipulation

        /// <summary>
        /// add an attribute value to an attribute
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attributeId">the ID of the attribute</param>
        /// <param name="pav">the value</param>
        public void AddAttributeValue(Product product, int attributeId, OptionAttributeValue pav)
        {
            Attribute attribute = null;
            attribute = Attribute.GetById(attributeId, Repository);
            AddAttributeValue(product, attribute, pav);
        }

        /// <summary>
        /// add an attribute value to an attribute
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attribute">the attribute</param>
        /// <param name="optionAttributeValue">the value</param>
        /// <exception cref="RequiredFieldException">
        /// The product option needs to be saved before any attributes can be added to it
        /// or
        /// The attribute needs to be saved before any values can be added to it
        /// </exception>
        /// <exception cref="DataException">The attribute value needs to be a new value</exception>
        public void AddAttributeValue(Product product, Attribute attribute, OptionAttributeValue optionAttributeValue)
        {
            if (isNew)
            {
                throw (new RequiredFieldException("The product option needs to be saved before any attributes can be added to it"));
            }//end of if
            if (attribute.IsNew)
            {
                throw (new RequiredFieldException("The attribute needs to be saved before any values can be added to it"));
            }
            if (!optionAttributeValue.IsNew)
            {
                throw (new DataException("The attribute value needs to be a new value"));
            }
            IAttributes attributeDbObj = Repository.GetAttribute(attribute.Id);
            IOptionsAttributeValues optionAttributeValueDbObj = Repository.CreateOptionAttriValue();
            optionAttributeValue.CopyPropertiesToDbObj(optionAttributeValueDbObj);
            Repository.AddAttributeValueToProductOption(product.Id, Id, attributeDbObj, optionAttributeValueDbObj);
            optionAttributeValue.CopyPropertiesFromDbObj(optionAttributeValueDbObj);
            optionAttributeValue.IsNew = false;
            Repository.SaveChanges();
        }

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attributeId">the id of the attribute</param>
        /// <returns>OptionAttributeValue[].</returns>
        public OptionAttributeValue[] GetAttributeValues(Product product, int attributeId)
        {
            return GetAttributeValues(product, attributeId, false);
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attributeId">the id of the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns>OptionAttributeValue[].</returns>
        public OptionAttributeValue[] GetAttributeValues(Product product, int attributeId, bool includeDeleted)
        {
            return GetAttributeValues(product, Attribute.GetById(attributeId, Repository), includeDeleted).ToArray();
        }

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="attri">the attribute</param>
        /// <returns></returns>
        public OptionAttributeValue[] GetAttributeValues(Product product, Attribute attri)
        {
            return GetAttributeValues(product, attri, false).ToArray();
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attri">the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns>List&lt;OptionAttributeValue&gt;.</returns>
        public List<OptionAttributeValue> GetAttributeValues(Product product, Attribute attri, bool includeDeleted)
        {
            List<OptionAttributeValue> returnValue = new List<OptionAttributeValue>();
            IAttributes attribute = Repository.GetAttribute(attri.Id);
            IEnumerable<IOptionsAttributeValues> values = Repository.GetOptionAttributeValues(product.Id, Id, attribute, includeDeleted);
            foreach (IOptionsAttributeValues dbObj in values)
            {
                OptionAttributeValue tempOptionsAttributeValue = new OptionAttributeValue(Repository);
                tempOptionsAttributeValue.CopyPropertiesFromDbObj(dbObj);
                tempOptionsAttributeValue.IsNew = false;
                returnValue.Add(tempOptionsAttributeValue);
            }
            return (returnValue);
        }

        /// <summary>
        /// Replaces the attribute values.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="optionAttributeValues">The option attribute values.</param>
        /// <exception cref="DataException">Only one product option attribute value can be set as the default value.</exception>
        public void ReplaceAttributeValues(Product product, Attribute attribute,IEnumerable<OptionAttributeValue> optionAttributeValues)

        {
            bool found = false;
            foreach (OptionAttributeValue av in optionAttributeValues)
            {
                if (av.IsDefault)
                {
                    if (found)
                    {
                        throw new DataException("Only one product option attribute value can be set as the default value.");
                    }
                    found = true;
                }
            }
            foreach (OptionAttributeValue optionAttributeValue in this.GetAttributeValues(product,attribute))
            {
                Repository.DeleteOptionAttriValue(optionAttributeValue.Id);
            }
            IAttributes attributeDbObj = Repository.GetAttribute(attribute.Id);
            foreach (OptionAttributeValue optionAttributeValue in optionAttributeValues)
            {
                IOptionsAttributeValues optionAttributeValueDbObj = Repository.CreateOptionAttriValue();
                optionAttributeValue.CopyPropertiesToDbObj(optionAttributeValueDbObj);
                Repository.AddAttributeValueToProductOption(product.Id, Id, attributeDbObj, optionAttributeValueDbObj);
                optionAttributeValue.CopyPropertiesFromDbObj(optionAttributeValueDbObj);
                optionAttributeValue.IsNew = false;
            }
            Repository.SaveChanges();
        }

        #endregion Attribute Value Manipulation

        #region OptionPrice Manipulation

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
            OptionPrice todaysPrice = GetPrice(DateTime.Now);
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
        public void AddOptionPrice(OptionPrice pop)
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

            OptionPrice[] prices = GetPrice(false, pop.ValidTimePeriod);
            OptionPrice defaultPrice = prices.FirstOrDefault(p => p.ValidTimePeriod == p.DefaultTimePeriod);
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
                pop.OptionId = Id;
                pop.Save();
            }//end of if
        }

        /// <summary>
        /// Gets the price for a date
        /// </summary>
        /// <param name="asOfDate">the date the price is for</param>
        /// <returns></returns>
        public OptionPrice GetPrice(DateTime asOfDate)
        {
            OptionPrice returnValue = null;
            OptionPrice defaultPrice = null;
            OptionPrice[] prices = GetPrice(false, asOfDate);
            foreach (OptionPrice pp in prices)
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
        /// Gets the price for today
        /// </summary>
        /// <param name="includeDeleted">include any delete prices. Default is false</param>
        /// <returns></returns>
        public OptionPrice[] GetPrice(bool includeDeleted = false)
        {
            OptionPrice[] returnValues = null;
            returnValues = GetPrice(includeDeleted, new DateRange(DateTime.MinValue, DateTime.MaxValue));
            return (returnValues);
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <param name="asOfDate">As of date.</param>
        /// <returns></returns>
        public OptionPrice[] GetPrice(bool includeDeleted, DateTime asOfDate)
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
        public OptionPrice[] GetPrice(DateRange timePeriod, bool includeDeleted = false)
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
        public OptionPrice[] GetPrice(bool includeDeleted, DateRange timePeriod)
        {
            if (timePeriod.Start.Kind != DateTimeKind.Utc)
            {
                timePeriod.Start = timePeriod.Start.ToUniversalTime();
            }
            if (timePeriod.End.Kind != DateTimeKind.Utc)
            {
                timePeriod.End = timePeriod.End.ToUniversalTime();
            }
            List<OptionPrice> returnValues = new List<OptionPrice>();
            if (isNew)
            {
                throw (new RequiredFieldException("The product options needs to be saved before any price can be added to it"));
            }//end of if
            foreach (IOptionPrice dbObj in Repository.GetOptionPrices(Id, includeDeleted))
            {

                OptionPrice optionPrice = new OptionPrice(Repository);
                DateTime start = dbObj.StartDate.HasValue && dbObj.StartDate.IsNotEmpty() ? dbObj.StartDate.Value : optionPrice.DefaultTime;
                DateTime end = dbObj.EndDate.HasValue && dbObj.EndDate.IsNotEmpty() ? dbObj.EndDate.Value : optionPrice.DefaultTime;
                DateRange dbDateRange = new DateRange(start, end);
                if (dbDateRange.Equals(optionPrice.DefaultTimePeriod) || timePeriod.WithIn(dbDateRange))
                {
                    optionPrice.CopyPropertiesFromDbObj(dbObj);
                    optionPrice.IsNew = false;
                    returnValues.Add(optionPrice);
                }
            }
            return (returnValues.ToArray());
        }

        #endregion OptionPrice Manipulation

        #endregion Public Instance Methods

        #region Public Static Method

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static ProductOption GetById(int id, IRepository repository)
        {
            ProductOption returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new ProductOption(id, repository);
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
        public static List<ProductOption> GetAll(IRepository repository)
        {
            List<ProductOption> returnValue = null;
            returnValue = GetAll(false, repository);
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - return both active and inactive objects
        ///     false - return active objects only
        /// </param>
        /// <returns></returns>
        public static List<ProductOption> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IProductOptions> tempList = null;
            List<ProductOption> returnValue = new List<ProductOption>();
            ProductOption temp = null;
            tempList = repository.GetProductOptions();
            foreach (IProductOptions tempItem in tempList)
            {
                temp = new ProductOption(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.isNew = false;
                if (includeDeleted || temp.Deleted == false)
                {
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected override void CommonInit()
        {
            base.CommonInit();
            Name = string.Empty;
            Description = string.Empty;
            Deleted = false;
        }

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

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IProductOptions dbObj = Repository.CreateProductOption();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertProductOption(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IProductOptions dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateProductOption(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IProductOptions GetDbRecord(int id)
        {
            return Repository.GetProductOption(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IProductOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Name = this._name;
                dbObj.Description = this._description;
                dbObj.Deleted = this.Deleted;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IProductOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this._name = dbObj.Name;
                this._description = dbObj.Description;
                this.Deleted = dbObj.Deleted;
            }
        }

        #endregion

        #endregion Methods

    }
}
