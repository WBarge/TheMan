using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class OptionAttributeValue : BussinessObject
    {

        #region Constants
        public const int MaxValueNameLength = 150;
        public const int MaxDescriptionLength = 255;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        private string _value;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <exception cref="InvalidLengthException">The Description field is too long</exception>
        public string Value
        {
            get { return (_description); }
            set
            {
                if (value.Length > MaxValueNameLength)
                {
                    throw (new InvalidLengthException("The Description field is too long"));
                }
                else
                {
                    this._value = value.Trim();
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
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is default; otherwise, <see langword="false" />.
        /// </value>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="OptionAttributeValue"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }
        /// <summary>
        /// Gets or sets the option attribute identifier.
        /// </summary>
        /// <value>
        /// The option attribute identifier.
        /// </value>
        internal int OptionAttributeId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionAttributeValue(IRepository repository) : base(repository)
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
        protected OptionAttributeValue(int id, IRepository repository) : this(repository)
        {
            IOptionsAttributeValues dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Methods

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
            Repository.DeleteOptionAttriValue(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// hide the base functionality
        /// </summary>
        new internal void Save()
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
        /// <returns></returns>
        public static OptionAttributeValue GetById(int id, IRepository repository)
        {
            OptionAttributeValue returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new OptionAttributeValue(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
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
            this._value = string.Empty;
            Description = string.Empty;
            IsDefault = false;
            this.Deleted = false;
            this.OptionAttributeId = 0;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        override protected void Validate()
        {
            if (Description.IsEmpty())
            {
                throw (new RequiredFieldException("Description is Mandatory"));
            }//end of if
        }//end of method


        protected override void Insert()
        {
            IOptionsAttributeValues dbObj = Repository.CreateOptionAttriValue();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertOptionAttriValue(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IOptionsAttributeValues dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateOptionAttriValue(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IOptionsAttributeValues GetDbRecord(int id)
        {
            return Repository.GetOptionAttriValue(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IOptionsAttributeValues dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Value = this._value;
                dbObj.Description = this._description;
                dbObj.DefaultValue = this.IsDefault;
                dbObj.Deleted = this.Deleted;
                dbObj.OptionsAttributesObjid = this.OptionAttributeId;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IOptionsAttributeValues dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this._value = dbObj.Value;
                this._description = dbObj.Description;
                this.IsDefault = dbObj.DefaultValue;
                this.Deleted = dbObj.Deleted;
                this.OptionAttributeId = dbObj.OptionsAttributesObjid;
            }
        }

        #endregion
        #endregion

    }
}
