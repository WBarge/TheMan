using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    /// <summary>
    /// Summary description for PhoneNumber.
    /// </summary>
    public class PhoneNumber : BussinessObject
    {
        #region Constants
        public const int NUMBER_LENGTH = 16;
        public const int COUNTRY_CODE_LENGTH = 5;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The full name of the type
        /// </summary>
        private string _number;
        public string Number
        {
            get { return (_number.Trim()); }
            set
            {
                if (value.Length > NUMBER_LENGTH)
                {
                    throw (new InvalidLengthException("The number field is too long"));
                }
                else
                {
                    _number = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The type of phone number
        /// </summary>
        public PhoneNumberType Type { get; set; }

        /// <summary>
        /// Is the phone number deleted
        /// </summary>
        public bool Deleted { get; internal set; }

        /// <summary>
        /// The country code to dial for the phone number
        /// </summary>
        public string countryCode;
        public string CountryCode
        {
            get { return (countryCode.Trim()); }
            set
            {
                if (value.Length > COUNTRY_CODE_LENGTH)
                {
                    throw (new InvalidLengthException("The country code field is too long"));
                }
                else
                {
                    countryCode = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PhoneNumber(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the phone number to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected PhoneNumber(int id, IRepository repository) : this(repository)
        {
            IPhoneNumbers dbObj = GetDbRecord(id);
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
            Repository.DeletePhoneNumber(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// Used to delete the Phone number data
        /// </summary>
        /// <example> This sample shows how to use the Delete method
        /// <code>
        ///		PhoneNumber tempObject = PhoneNumber.GetByID (someID);
        ///		tempObject.Delete();
        /// </code>
        /// </example>
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
        /// Used to get a PhoneNumber based on the id 
        /// </summary>
        /// <param name="id">
        /// a piece of data that Uniquely identifies the data record in the db
        /// </param>
        /// <param name="repository"></param>
        /// <returns>
        /// A new PhoneNumber object filled with data based on the id passed in
        /// </returns>
        public static PhoneNumber GetById(int id, IRepository repository)
        {
            PhoneNumber returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PhoneNumber(id, repository);
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
        public static List<PhoneNumber> GetAll(IRepository repository)
        {
            List<PhoneNumber> returnValue = null;
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
        /// <param name="repository"></param>
        /// <returns></returns>
        public static List<PhoneNumber> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IPhoneNumbers> tempList = null;
            List<PhoneNumber> returnValue = new List<PhoneNumber>();
            tempList = repository.GetPhoneNumbers();
            foreach (IPhoneNumbers tempPhoneNumber in tempList)
            {
                if (includeDeleted || !tempPhoneNumber.Deleted)
                {
                    PhoneNumber temp = new PhoneNumber(repository);
                    temp.CopyPropertiesFromDbObj(tempPhoneNumber);
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
            _number = string.Empty;
            countryCode = string.Empty;
            Type = null;
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
            if (_number.IsEmpty())
            {
                throw (new RequiredFieldException("Number is Mandatory"));
            }//end of if
            if (countryCode.IsEmpty())
            {
                throw (new RequiredFieldException("Country Code is Mandatory"));
            }//end of if
            if (Type == null)
            {
                throw (new RequiredFieldException("Phone Type is Mandatory"));
            }
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IPhoneNumbers dbObj = Repository.CreatePhoneNumber();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPhoneNumber(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPhoneNumbers dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePhoneNumber(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPhoneNumbers GetDbRecord(int id)
        {
            return Repository.GetPhoneNumber(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPhoneNumbers dbObj)
        {
            if (this.Id.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
            }
            dbObj.Number = this._number;
            dbObj.NumberTypeObjid = this.Type.Id;
            dbObj.CountryCode = this.countryCode;
            dbObj.Deleted = this.Deleted;
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPhoneNumbers dbObj)
        {
            this.Id = dbObj.Objid;
            this._number = dbObj.Number;
            this.Type = PhoneNumberType.GetById(dbObj.NumberTypeObjid, Repository);
            this.countryCode = dbObj.CountryCode;
            this.Deleted = dbObj.Deleted;
        }


        #endregion

        #endregion

    }//end of class
}//end of namespace
