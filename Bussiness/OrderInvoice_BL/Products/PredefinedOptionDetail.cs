using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    internal class PredefinedOptionDetail : BussinessObject
    {
        #region Constants
        public const int MaxValueLength = 150;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        /// <summary>
        /// The predefined option
        /// </summary>
        internal PredefinedOption PredefinedOption;

        /// <summary>
        /// Gets the PredefinedOption identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int PredefinedOptionId { get { return PredefinedOption.Id; } }

        /// <summary>
        /// The attribute
        /// </summary>
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
        /// The attibute value is an instance of the <see cref="OptionAttributeValue"/>
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
                if (value.Length > MaxValueLength)
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
        /// Gets a value indicating whether this <see cref="PredefinedOptionDetail"/> is deleted.
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
        protected PredefinedOptionDetail(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PredefinedOptionDetail"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="predefinedOption">The predefined option.</param>
        /// <param name="attribute">The attribute.</param>
        public PredefinedOptionDetail(IRepository repository, PredefinedOption predefinedOption, Attribute attribute) : this(repository)
        {
            this.PredefinedOption = predefinedOption;
            this.Attribute = attribute;
        }//end of default constructor


        /// <summary>
        /// Constructor used to preload the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        protected PredefinedOptionDetail(int id, IRepository repository)
            : this(repository)
        {
            IPredefinedOptionDetail dbObj = GetDbRecord(id);
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
            Repository.DeletePredefinedOptionDetail(Id);
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
        /// <returns></returns>
        internal static PredefinedOptionDetail GetById(int id, IRepository repository)
        {
            PredefinedOptionDetail returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PredefinedOptionDetail(id, repository);
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
        internal static List<PredefinedOptionDetail> GetAll(int ppi, IRepository repository)
        {
            List<PredefinedOptionDetail> returnValue = null;
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
        /// <returns></returns>
        internal static List<PredefinedOptionDetail> GetAll(bool includeDeleted, int ppi, IRepository repository)
        {
            IEnumerable<IPredefinedOptionDetail> tempList = null;
            List<PredefinedOptionDetail> returnValue = new List<PredefinedOptionDetail>();
            PredefinedOptionDetail temp = null;
            tempList = repository.GetPredefinedOptionDetails(ppi);
            foreach (IPredefinedOptionDetail tempItem in tempList)
            {
                if (includeDeleted || tempItem.Deleted == false)
                {
                    temp = new PredefinedOptionDetail(repository);
                    temp.CopyPropertiesFromDbObj(tempItem);
                    temp.isNew = false;
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        internal static PredefinedOptionDetail GetForAttribute(IRepository repository, int ppi, Attribute attri)
        {
            PredefinedOptionDetail returnValue = null;
            IPredefinedOptionDetail obj = null;
            if (attri.IsNotEmpty() && ppi.IsNotEmpty())
            {
                obj = repository.GetPredefinedOptionDetailForAttribute(ppi, attri.Id);
                if (obj.IsNotEmpty())
                {
                    returnValue = new PredefinedOptionDetail(repository);
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
            PredefinedOption = null;
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
            IPredefinedOptionDetail dbObj = Repository.CreatePredefinedOptionDetail();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPredefinedOptionDetail(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPredefinedOptionDetail dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePredefinedOptionDetail(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPredefinedOptionDetail GetDbRecord(int id)
        {
            return Repository.GetPredefinedOptionDetail(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPredefinedOptionDetail dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Deleted = this.Deleted;
                dbObj.Value = this._value;
                dbObj.PredefinedOptionObjid = this.PredefinedOption.Id;
                dbObj.AttribuiteObjid = this.Attribute.Id;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPredefinedOptionDetail dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Deleted = dbObj.Deleted;
                this._value = dbObj.Value;
                this.PredefinedOption = PredefinedOption.GetById(dbObj.PredefinedOptionObjid, this.Repository);
                this.Attribute = Attribute.GetById(dbObj.AttribuiteObjid, this.Repository);
            }
        }

        #endregion

        #endregion Methods

    }
}
