using Exceptions;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using Utilites;

namespace OrderInvoice_BL.Products
{
    public class ProductAttributeValue : BussinessObject
    {

        #region Constants
        public const int MaxValueNameLength = 150;
        public const int MaxDescriptionLength = 255;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        private string _valueName;
        /// <summary>
        /// Gets or sets the name of the value.
        /// </summary>
        /// <value>
        /// The name of the value.
        /// </value>
        /// <exception cref="InvalidLengthException">The valueName field is too long</exception>
        public string ValueName
        {
            get { return (_valueName); }
            set
            {
                if (value.Length > MaxValueNameLength)
                {
                    throw (new InvalidLengthException("The valueName field is too long"));
                }
                _valueName = value.Trim();
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
                _description = value.Trim();
            }//end of set 
        }

        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is default; otherwise, <see langword="false" />.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ProductAttributeValue"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }

        /// <summary>
        /// Gets or sets the product attribute identifier.
        /// </summary>
        /// <value>
        /// The product attribute identifier.
        /// </value>
        internal int ProductAttributeId { get; set; }

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProductAttributeValue(IRepository repository) : base(repository)
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
        protected ProductAttributeValue(int id, IRepository repository) : this(repository)
        {
            IProductAttributeValues dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Methods

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
            Repository.DeleteProductAttriValue(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// hide the base functionality
        /// </summary>
        internal new void Save()
        {
            base.Save();
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
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static ProductAttributeValue GetById(int id, IRepository repository)
        {
            ProductAttributeValue returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new ProductAttributeValue(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

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
            ValueName = string.Empty;
            Description = string.Empty;
            IsDefault = false;
            Deleted = false;
            ProductAttributeId = 0;
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
            if (ValueName.IsEmpty())
            {
                throw (new RequiredFieldException("ValueName is Mandatory"));
            }//end of if
            if (Description.IsEmpty())
            {
                throw (new RequiredFieldException("Description is Mandatory"));
            }//end of if
        }//end of method

        /// <inheritdoc />
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IProductAttributeValues dbObj = Repository.CreateProductAttriValue();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertProductAttriValue(dbObj);
            Id = dbObj.Objid;
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IProductAttributeValues dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateProductAttriValue(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IProductAttributeValues GetDbRecord(int id)
        {
            return Repository.GetProductAttriValue(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IProductAttributeValues dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (Id.IsNotEmpty())
                {
                    dbObj.Objid = Id;
                }
                dbObj.Value = _valueName;
                dbObj.Description = _description;
                dbObj.DefaultValue = IsDefault;
                dbObj.Deleted = Deleted;
                dbObj.ProductAttributesObjid = ProductAttributeId;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IProductAttributeValues dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                Id = dbObj.Objid;
                _valueName = dbObj.Value;
                _description = dbObj.Description;
                IsDefault = dbObj.DefaultValue;
                Deleted = dbObj.Deleted;
                ProductAttributeId = dbObj.ProductAttributesObjid;
            }
        }

        #endregion

        #endregion

    }
}
