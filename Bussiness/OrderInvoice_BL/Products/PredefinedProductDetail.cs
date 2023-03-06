using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    internal class PredefinedProductDetail : BussinessObject
    {
        #region Constants
        public const int VALUE_LENGTH = 150;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        /// <summary>
        /// The predefined product
        /// </summary>
        // ReSharper disable once InconsistentNaming
        internal PredefinedProduct PredefinedProduct;

        /// <summary>
        /// Gets the PredefinedProduct identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int PredefinedProductId { get { return PredefinedProduct.Id; } }

        /// <summary>
        /// The attribute
        /// </summary>
        // ReSharper disable once InconsistentNaming
        internal Attribute Attribute;

        /// <summary>
        /// Gets the attribute identifier.
        /// </summary>
        /// <value>
        /// The attribute identifier.
        /// </value>
        public int AttributeId { get { return Attribute.Id; } }

        private string _value;

        /// <summary>
        /// This is the description from the attribute value
        /// The attibute value is an instance of the <see cref="ProductAttributeValue"/>
        /// or if there are no values associated with the attirbute then the attribute value a just a string
        /// i.e. the setting for the atttribute
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        /// <exception cref="InvalidLengthException">The Value field is too long</exception>
        public string Value
        {
            get { return (this._value); }
            set
            {
                if (value.Length > VALUE_LENGTH)
                {
                    throw (new InvalidLengthException("The Value field is too long"));
                }
                else
                {
                    this._value = value.Trim();
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
        protected PredefinedProductDetail(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Products.PredefinedProduct"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="predefinedProduct"></param>
        /// <param name="attribute"></param>
        public PredefinedProductDetail(IRepository repository, PredefinedProduct predefinedProduct, Attribute attribute) : this(repository)
        {
            this.PredefinedProduct = predefinedProduct;
            this.Attribute = attribute;
        }//end of default constructor


        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected PredefinedProductDetail(int id, IRepository repository) : this(repository)
        {
            IPredefinedProductDetail dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

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
            Repository.DeletePredefinedProductDetail(Id);
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

        /// <summary>
        /// hide the base functionality
        /// </summary>
        new internal void Save()
        {
            base.Save();
        }

        #endregion Public Instance Methods

        #region Public Static Method

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        internal static PredefinedProductDetail GetById(int id, IRepository repository)
        {
            PredefinedProductDetail returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PredefinedProductDetail(id, repository);
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
        internal static List<PredefinedProductDetail> GetAll(int ppi, IRepository repository)
        {
            List<PredefinedProductDetail> returnValue = null;
            returnValue = GetAll(false, ppi, repository);
            return returnValue;
        }

        /// <summary>
        /// Factoy method - Gets objects in a list
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - return both active and inactive objects
        ///     false - return active objects only
        /// </param>
        /// <param name="ppi"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        internal static List<PredefinedProductDetail> GetAll(bool includeDeleted, int ppi, IRepository repository)
        {
            IEnumerable<IPredefinedProductDetail> tempList = null;
            List<PredefinedProductDetail> returnValue = new List<PredefinedProductDetail>();
            PredefinedProductDetail temp = null;
            tempList = repository.GetPredefinedProductDetails(ppi);
            foreach (IPredefinedProductDetail tempItem in tempList)
            {
                if (includeDeleted || tempItem.Deleted == false)
                {
                    temp = new PredefinedProductDetail(repository);
                    temp.CopyPropertiesFromDbObj(tempItem);
                    temp.isNew = false;
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        internal static PredefinedProductDetail GetForAttribute(IRepository repository, int ppi, Attribute attri)
        {
            PredefinedProductDetail returnValue = null;
            IPredefinedProductDetail obj = null;
            if (attri.IsNotEmpty() && ppi.IsNotEmpty())
            {
                obj = repository.GetPredefinedProductDetailForAttribute(ppi, attri.Id);
                if (obj.IsNotEmpty())
                {
                    returnValue = new PredefinedProductDetail(repository);
                    returnValue.CopyPropertiesFromDbObj(obj);
                    returnValue.isNew = false;
                }
            }//end of  if
            return (returnValue);
        }//end of method

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
            Attribute = null;
            Value = string.Empty;
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
            if (Value.IsEmpty())
            {
                throw (new RequiredFieldException("Value is Mandatory"));
            }//end of if
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IPredefinedProductDetail dbObj = Repository.CreatePredefinedProductDetail();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPredefinedProductDetail(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPredefinedProductDetail dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePredefinedProductDetail(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPredefinedProductDetail GetDbRecord(int id)
        {
            return Repository.GetPredefinedProductDetail(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPredefinedProductDetail dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Deleted = this.Deleted;
                dbObj.Value = this._value;
                dbObj.PredefinedProductObjid = this.PredefinedProduct.Id;
                dbObj.AttributeObjid = this.Attribute.Id;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPredefinedProductDetail dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Deleted = dbObj.Deleted;
                this._value = dbObj.Value;
                this.PredefinedProduct = PredefinedProduct.GetById(dbObj.PredefinedProductObjid, this.Repository);
                this.Attribute = Attribute.GetById(dbObj.AttributeObjid, this.Repository);
            }
        }

        #endregion

        #endregion Methods

    }
}
