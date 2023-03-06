using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class PredefinedOption : BussinessObject
    {
        #region Constants
        public const int DESCRIPTION_LENGTH = 255;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        // ReSharper disable once InconsistentNaming
        internal PredefinedProduct PredefinedProduct;

        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int PredefinedProductId { get { return PredefinedProduct.Id; } }

        // ReSharper disable once InconsistentNaming
        internal ProductOption Option;

        public int OptionId { get { return Option.Id; } }

        private string _description;
        /// <summary>
        /// Gets or sets the description.
        /// Intended use is for a marketing description of the product
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
                else
                {
                    _description = value.Trim();
                }//end of if-else
            }//end of set 
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Products.PredefinedProduct"/> is deleted.
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
        protected PredefinedOption(IRepository repository)
            : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Products.PredefinedProduct" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="product">The product which has already been made and is ready to be sold.</param>
        /// <param name="option">The option for the product.</param>
        public PredefinedOption(IRepository repository, PredefinedProduct product, ProductOption option)
            : this(repository)
        {
            this.PredefinedProduct = product;
            this.Option = option;
        }//end of constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected PredefinedOption(int id, IRepository repository)
            : this(repository)
        {
            IPredefinedOptions dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

        #region PredefinedOption Manipulation

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
            Repository.DeletePredefinedOption(Id);
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

        #endregion PredefinedOption Manipulation

        #region Attribute Manipulation

        /// <summary>
        /// Get all the active default attributes for the option
        /// These are the attributes for the base product
        /// </summary>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetOptionAttributes(PredefinedProduct predefinedProduct)
        {
            Attribute[] returnValues = null;
            returnValues = Option.GetAttributes(predefinedProduct.Product);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the default attributes for the product
        /// These are the attributes for the base product
        /// </summary>
        /// <param name="predefinedProduct">The predefined product.</param>
        /// <param name="includeDeleted">true - include deleted attributes
        /// false - do not include deleted attributes</param>
        /// <returns>An array of attribute objects</returns>
        public Attribute[] GetOptionAttributes(PredefinedProduct predefinedProduct, bool includeDeleted)
        {
            Attribute[] returnValues = null;
            returnValues = Option.GetAttributes(predefinedProduct.Product, includeDeleted);
            return (returnValues);
        }//end of method

        #endregion Attribute Manipulation

        #region Attribute Value Manipulation

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="predefinedProduct">The predefined product.</param>
        /// <param name="attri">the attribute</param>
        /// <returns>OptionAttributeValue[].</returns>
        public OptionAttributeValue[] GetOptionAttributeValues(PredefinedProduct predefinedProduct, Attribute attri)
        {
            return GetOptionAttributeValues(predefinedProduct,attri, false).ToArray();
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="predefinedProduct">The predefined product.</param>
        /// <param name="attri">the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns>List&lt;OptionAttributeValue&gt;.</returns>
        public List<OptionAttributeValue> GetOptionAttributeValues(PredefinedProduct predefinedProduct, Attribute attri, bool includeDeleted)
        {
            List<OptionAttributeValue> returnValue = new List<OptionAttributeValue>();
            returnValue = Option.GetAttributeValues(predefinedProduct.Product, attri, includeDeleted);
            return (returnValue);
        }

        /// <summary>
        /// Adds the attribute value.
        /// </summary>
        /// <param name="attri">The attri.</param>
        /// <param name="attriValue">The value.</param>
        /// <exception cref="InvalidParameterException">The attribute and value are manditory in order to add the attribute value to the predefined product</exception>
        public void AddAttributeValue(Attribute attri, string attriValue)
        {
            if (attri.IsEmpty())
            {
                throw new InvalidParameterException("The attribute is mandatory in order to add the attribute value to the predefined option");
            }
            if (attriValue.IsEmpty())
            {
                throw new InvalidParameterException("The attribute value is mandatory in order to add the attribute value to the predefined option");
            }
            PredefinedOptionDetail ppd = PredefinedOptionDetail.GetForAttribute(this.Repository, this.Id, attri);
            if (ppd.IsEmpty())
            {
                ppd = new PredefinedOptionDetail(this.Repository, this, attri);
            }
            ppd.Value = attriValue;
            ppd.Save();
        }

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <param name="attri">The attribute.</param>
        /// <returns></returns>
        /// <exception cref="InvalidParameterException">The attribute in order to get the attribute value for the predefined product</exception>
        public string GetAttributeValue(Attribute attri)
        {
            string returnValue = string.Empty;
            if (attri.IsEmpty())
            {
                throw new InvalidParameterException("The attribute in order to get the attribute value for the predefined option");
            }
            PredefinedOptionDetail ppd = PredefinedOptionDetail.GetForAttribute(this.Repository, this.Id, attri);
            if (ppd.IsNotEmpty())
            {
                returnValue = ppd.Value;
            }
            return returnValue;
        }

        /// <summary>
        /// Removes all attribute values.
        /// </summary>
        public void RemoveAllAttributeValues()
        {
            List<PredefinedOptionDetail> ppds = PredefinedOptionDetail.GetAll(true, this.Id, this.Repository);
            ppds.ForEach(p => p.PermanentlyRemoveFromSystem());
        }

        #endregion Attribute Value Manipulation

        #endregion Public Instance Methods

        #region Public Static Method

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static PredefinedOption GetById(int id, IRepository repository)
        {
            PredefinedOption returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PredefinedOption(id, repository);
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
        public static List<PredefinedOption> GetAll(IRepository repository)
        {
            List<PredefinedOption> returnValue = null;
            returnValue = GetAll(false, repository);
            return returnValue;
        }

        /// <summary>
        /// Factoy method - Gets objects in a list
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - return both active and inactive objects
        ///     false - return active objects only
        /// </param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static List<PredefinedOption> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IPredefinedOptions> tempList = null;
            List<PredefinedOption> returnValue = new List<PredefinedOption>();
            PredefinedOption temp = null;
            tempList = repository.GetPredefinedOptions();
            foreach (IPredefinedOptions tempItem in tempList)
            {
                if (includeDeleted || tempItem.Deleted == false)
                {
                    temp = new PredefinedOption(repository);
                    temp.CopyPropertiesFromDbObj(tempItem);
                    temp.isNew = false;
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
            PredefinedProduct = null;
            Option = null;
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
            if (PredefinedProductId.IsEmpty())
            {
                throw (new ClassDependencyException("The Predefined Product has to be saved before the predefined option is saved"));
            }
            if (OptionId.IsEmpty())
            {
                throw (new ClassDependencyException("The ProductOption has to be saved before the predefined option is saved"));
            }

        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IPredefinedOptions dbObj = Repository.CreatePredefinedOption();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPredefinedOption(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPredefinedOptions dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePredefinedOption(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPredefinedOptions GetDbRecord(int id)
        {
            return Repository.GetPredefinedOption(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPredefinedOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Deleted = Deleted;
                dbObj.MarketDescription = _description;
                dbObj.PredefinedProductObjid = this.PredefinedProduct.Id;
                dbObj.OptionObjid = this.Option.Id;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPredefinedOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Deleted = dbObj.Deleted;
                this._description = dbObj.MarketDescription;
                this.PredefinedProduct = PredefinedProduct.GetById(dbObj.PredefinedProductObjid, this.Repository);
                this.Option = ProductOption.GetById(dbObj.OptionObjid, this.Repository);
            }
        }


        #endregion

        #endregion Methods

    }
}
