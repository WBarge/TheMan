using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class EmailAddress : BussinessObject
    {

        #region Constants
        public const int ADDRESS_LENGTH = 255;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The email address
        /// </summary>
        private string _address;
        public string Address
        {
            get { return (_address.Trim()); }
            set
            {
                if (value.Length > ADDRESS_LENGTH)
                {
                    throw (new InvalidLengthException("The address field is too long"));
                }
                else
                {
                    _address = value.Trim();
                }//end of if-else
            }//end of set 
        }

        /// <summary>
        /// Is this address the default address
        /// </summary>
        public bool IsDefault { get; internal set; }

        /// <summary>
        /// Is the email address deleted
        /// </summary>
        public bool Deleted { get; internal set; }

        /// <summary>
        /// Gets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        internal int ContactId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EmailAddress(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the email address to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected EmailAddress(int id, IRepository repository) : this(repository)
        {
            IEMailAddresses dbObj = GetDbRecord(id);
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
            Repository.DeleteEmailAddress(Id);
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
        public static EmailAddress GetById(int id, IRepository repository)
        {
            EmailAddress returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new EmailAddress(id, repository);
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
        public static List<EmailAddress> GetAll(IRepository repository)
        {
            List<EmailAddress> returnValue = null;
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
        public static List<EmailAddress> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IEMailAddresses> tempList = null;
            List<EmailAddress> returnValue = new List<EmailAddress>();
            tempList = repository.GetEmailAddresses();
            foreach (IEMailAddresses tempEmail in tempList)
            {
                if (includeDeleted || !tempEmail.Deleted)
                {
                    EmailAddress temp = new EmailAddress(repository);
                    temp.CopyPropertiesFromDbObj(tempEmail);
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
            Address = string.Empty;
            IsDefault = false;
            ContactId = 0;
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
            if (Address.IsEmpty())
            {
                throw (new RequiredFieldException("Address is Mandatory"));
            }//end of if
            if (Address.IsNotValidEmail())
            {
                throw (new DataException("The Email address is not valid"));
            }
            if (ContactId.IsEmpty())
            {
                throw (new RequiredFieldException("Contact ID is Mandatory"));
            }
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IEMailAddresses dbObj = Repository.CreateEmailAddress();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertEmailAddress(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IEMailAddresses dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateEmailAddress(dbObj);
        }
        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IEMailAddresses GetDbRecord(int id)
        {
            return Repository.GetEmailAddress(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IEMailAddresses dbObj)
        {
            if (this.Id.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
            }
            dbObj.ContactObjid = this.ContactId;
            dbObj.Address = this._address;
            dbObj.DefaultAddress = this.IsDefault;
            dbObj.Deleted = this.Deleted;
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IEMailAddresses dbObj)
        {
            this.Id = dbObj.Objid;
            this.ContactId = dbObj.ContactObjid;
            this._address = dbObj.Address;
            this.IsDefault = dbObj.DefaultAddress;
            this.Deleted = dbObj.Deleted;
        }

        #endregion

        #endregion

    }
}
