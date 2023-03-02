using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    /// <summary>
    /// Summary description for SnailMailAddress.
    /// </summary>
    public class SnailMailAddress : BussinessObject
    {
        #region Constants
        public const int MaxLine1Length = 40;
        public const int MaxLine2Length = 40;
        public const int MaxCityLength = 40;
        public const int MaxZipLength = 12;
        #endregion

        #region Local Vars
        #endregion

        #region Properties

        private string _line1;
        /// <summary>
        /// Gets or sets the line1.
        /// </summary>
        /// <value>
        /// The line1.
        /// </value>
        /// <exception cref="InvalidLengthException">The Line1 field is too long</exception>
        public string Line1
        {
            get { return (_line1.Trim()); }
            set
            {
                if (value.Length > MaxLine1Length)
                {
                    throw (new InvalidLengthException("The Line1 field is too long"));
                }
                else
                {
                    _line1 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property
        private string _line2;
        /// <summary>
        /// Gets or sets the line2.
        /// </summary>
        /// <value>
        /// The line2.
        /// </value>
        /// <exception cref="InvalidLengthException">The Line2 field is too long</exception>
        public string Line2
        {
            get { return (_line2.Trim()); }
            set
            {
                if (value.Length > MaxLine2Length)
                {
                    throw (new InvalidLengthException("The Line2 field is too long"));
                }
                else
                {
                    _line2 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property
        private string _city;
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <exception cref="InvalidLengthException">The City field is too long</exception>
        public string City
        {
            get { return (_city.Trim()); }
            set
            {
                if (value.Length > MaxCityLength)
                {
                    throw (new InvalidLengthException("The City field is too long"));
                }
                else
                {
                    _city = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property
        private string _zip;
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>
        /// The zip.
        /// </value>
        /// <exception cref="InvalidLengthException">The Zip field is too long</exception>
        public string Zip
        {
            get { return (_zip.Trim()); }
            set
            {
                if (value.Length > MaxZipLength)
                {
                    throw (new InvalidLengthException("The Zip field is too long"));
                }
                else
                {
                    _zip = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property
         /// <summary>
         /// Gets the snail mail type.
         /// </summary>
         /// <value>
         /// The type.
         /// </value>
        public SnailMailType Type { get; set; }
        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>
        /// The country abbreviation.
        /// </value>
        public Country Country { get; set; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state abbreviation.
        /// </value>
        public State State { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [deleted].
        /// </summary>
        /// <value>
        /// <see langword="true" /> if [deleted]; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Contructor
        /// </summary>
        public SnailMailAddress(IRepository repository)
            : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Constructor used to preload the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the phone number to be loaded
        /// </param>
        protected SnailMailAddress(int id, IRepository repository) : this(repository)
        {
            ISnailMailAddresses dbObj = GetDbRecord(id);
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
            Repository.DeleteSnailMailAddress(Id);
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
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static SnailMailAddress GetById(int id, IRepository repository)
        {
            SnailMailAddress returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new SnailMailAddress(id, repository);
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
        public static List<SnailMailAddress> GetAll(IRepository repository)
        {
            List<SnailMailAddress> returnValue = null;
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
        public static List<SnailMailAddress> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<ISnailMailAddresses> tempList = null;
            List<SnailMailAddress> returnValue = new List<SnailMailAddress>();
            SnailMailAddress temp = null;
            tempList = repository.GetSnailMailAddresses();
            foreach (ISnailMailAddresses tempObj in tempList)
            {
                if (includeDeleted || !tempObj.Deleted)
                {
                    temp = new SnailMailAddress(repository);
                    temp.CopyPropertiesFromDbObj(tempObj);
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
            _line1 = string.Empty;
            _line2 = string.Empty;
            _city = string.Empty;
            _zip = string.Empty;
            Type = null;
            Country = null;
            State = null;
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
            if (_line1.IsEmpty())
            {
                throw (new RequiredFieldException("Line1 is Mandatory"));
            }//end of if
            if (_city.IsEmpty())
            {
                throw (new RequiredFieldException("City is Mandatory"));
            }//end of if
            if (_zip.IsEmpty())
            {
                throw (new RequiredFieldException("ZIp is Mandatory"));
            }
            if (Type == null)
            {
                throw (new RequiredFieldException("Type is Mandatory"));
            }
            if (Country == null)
            {
                throw (new RequiredFieldException("Country is Mandatory"));
            }
            if (State == null)
            {
                throw (new RequiredFieldException("State is Mandatory"));
            }
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            ISnailMailAddresses dbObj = Repository.CreateSnailMailAddress();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertSnailMailAddress(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ISnailMailAddresses dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateSnailMailAddress(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private ISnailMailAddresses GetDbRecord(int id)
        {
            return Repository.GetSnailMailAddress(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ISnailMailAddresses dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Line1 = this._line1;
                dbObj.Line2 = this._line2;
                dbObj.City = this._city;
                dbObj.StateObjId = this.State.Id;
                dbObj.CountryObjid = this.Country.Id;
                dbObj.Zip = this._zip;
                dbObj.SnailMailTypeObjid = this.Type.Id;
                dbObj.Deleted = this.Deleted;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ISnailMailAddresses dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this._line1 = dbObj.Line1;
                this._line2 = dbObj.Line2;
                this._city = dbObj.City;
                this.State = State.GetById(dbObj.StateObjId, this.Repository);
                this.Country = Country.GetById(dbObj.CountryObjid, this.Repository);
                this._zip = dbObj.Zip;
                this.Type = SnailMailType.GetById(dbObj.SnailMailTypeObjid, this.Repository);
                this.Deleted = dbObj.Deleted;
            }
        }

        #endregion

        #endregion

    }
}
