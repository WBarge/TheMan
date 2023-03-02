using System.Collections.Generic;
using System.Linq;
using Exceptions;
using OrderInvoice_BL.People;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class Contact : BussinessObject
    {

        #region Constants
        public const int MaxFirstNameLength = 40;
        public const int MaxLastNameLength = 40;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The first name of the contact
        /// </summary>
        protected string firstName;
        public string FirstName
        {
            get { return (firstName.Trim()); }

            set
            {
                if (value.Length > MaxFirstNameLength)
                {
                    throw (new InvalidLengthException("The first name field is too long"));
                }
                firstName = value.Trim();
            }//end of set
        }//end of property

        /// <summary>
        /// The last name of the contact
        /// </summary>
        protected string lastName;
        public string LastName
        {
            get { return (lastName); }
            set
            {
                if (value.Length > MaxLastNameLength)
                {
                    throw (new InvalidLengthException("The last name field is too long"));
                }
                lastName = value.Trim();
            }//end of set
        }//end of property

        /// <summary>
        /// Is this contact deleted
        /// </summary>
        public bool Deleted { get; internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Contact(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        protected Contact(int id, IRepository repository) : this(repository)
        {
            IContacts dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Instance Methods

        #region Contact Manipulation

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
            Repository.DeleteContact(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// Used to delete the Contact
        /// </summary>
        /// <example> This sample shows how to use the Delete method
        /// <code>
        ///		Contact tempObject = Contact.GetByID (someID);
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
            Save();
            Repository.SaveChanges();
        }//end of method

        public override void Save()
        {
            this.Save(true);
        }

        internal void Save(bool persist)
        {
            Validate();
            if (isNew)
            {
                IContacts dbObj = Repository.CreateContact();
                CopyPropertiesToDbObj(dbObj);
                Repository.InsertContact(dbObj);
                this.Id = dbObj.Objid;

            }
            else
            {
                IContacts dbObj = GetDbRecord(Id);
                CopyPropertiesToDbObj(dbObj);
                Repository.UpdateContact(dbObj);

            }
            isNew = false;
            if (persist)
            {
                Repository.SaveChanges();
            }
        }

        #endregion

        #region Phone Number Manipulation

        /// <summary>
        /// Set the phone number to the default phone number for the contact
        /// </summary>
        /// <returns>
        ///		true - it was able to set the phone number as the default number
        ///		false - it was NOT able to set the phone number as the default number 
        /// </returns>
        public bool SetDefaultNumber(PhoneNumber phNum)
        {
            bool returnValue = false;
            if (phNum.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to SetDefaultNumber is null"));
            }//end of if
            if (phNum.Deleted)
            {
                throw (new ClassDependencyException("The Default Phone Number has to be an active phone number"));
            }//end of if
            if (phNum.IsNew)
            {
                throw (new ClassDependencyException("The Phone Number has to be saved before it can be set as the default"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before setting the default phone number"));
            }//end of if
            returnValue = Repository.SetDefaultPhoneNumber(Id, phNum.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Get the default phone number for the contact
        /// </summary>
        /// <returns>
        ///		The default phone number or null when
        ///		there is not a default number
        /// </returns>
        public PhoneNumber GetDefaultNumber()
        {
            PhoneNumber returnValue = null;
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before getting the default phone number"));
            }//end of if
            IPhoneNumbers tempNumber = Repository.GetDefaultPhoneNumber(Id);
            if (tempNumber.IsNotEmpty())
            {
                returnValue = new PhoneNumber(Repository);
                returnValue.CopyPropertiesFromDbObj(tempNumber);
                returnValue.IsNew = false;
            }
            return (returnValue);
        }//end of GetDefaultNumber

        /// <summary>
        /// Does the contact have a default phone number
        /// </summary>
        /// <returns>
        ///		true - The contact has a default phone number
        ///		false - The contact does not have a default phone number
        /// </returns>
        public bool HasDefaultNumber()
        {
            bool returnValue = false;
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before checking for a default phone number"));
            }//end of if
            PhoneNumber tempNumber = GetDefaultNumber();
            returnValue = tempNumber.IsNotEmpty();
            return (returnValue);
        }//end of HasDefaultNumber

        /// <summary>
        /// Get all the phone numbers for the contact
        /// </summary>
        /// <returns>
        /// An array of phone number objects
        /// </returns>
        public PhoneNumber[] GetPhoneNumbers()
        {
            PhoneNumber[] returnValues = null;
            returnValues = GetPhoneNumbers(false);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the active phone numbers for the contact
        /// </summary>
        /// <returns>
        /// An array of phone number objects
        /// </returns>
        public PhoneNumber[] GetPhoneNumbers(bool includeDeleted)
        {
            List<PhoneNumber> returnValues = new List<PhoneNumber>();
            IEnumerable<IPhoneNumbers> results = Repository.GetContactPhoneNumbers(Id, includeDeleted);
            foreach (IPhoneNumbers iph in results)
            {
                PhoneNumber tempNumber = new PhoneNumber(Repository);
                tempNumber.CopyPropertiesFromDbObj(iph);
                tempNumber.IsNew = false;
                returnValues.Add(tempNumber);
            }
            return (returnValues.ToArray());
        }//end of method

        /// <summary>
        /// Adds a phone number to the contact
        /// </summary>
        /// <param name="phToAdd">
        /// The phone number to be added to the contact
        /// </param>
        public void AddPhoneNumber(PhoneNumber phToAdd)
        {
            if (phToAdd.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddPhoneNumber is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any phone numbers can be added to it"));
            }//end of if
            if (phToAdd.IsNew)//the phone number is a new phone number and has not been added to the db yet
            {
                phToAdd.Save();
            }//end of if
            Repository.AddPhoneNumberToContact(Id, phToAdd.Id);
            Repository.SaveChanges();
        }//end of method

        /// <summary>
        /// Remove a phone number from the contact
        /// </summary>
        /// <param name="phToRemove">
        /// The Phone number to be removed
        /// </param>
        public bool RemovePhoneNumber(PhoneNumber phToRemove)
        {
            bool returnValue = false;
            if (phToRemove.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to RemovePhoneNumber is null"));
            }//end of if
            if (phToRemove.IsNew)
            {
                throw (new ClassDependencyException("The phone number to remove has not been added to the system yet"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any phone numbers can be removed to it"));
            }//end of if
            returnValue = Repository.RemovePhoneNumberFromContact(Id, phToRemove.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        #endregion

        #region Email Address Manipulation

        /// <summary>
        /// Set the default email address for the contact
        /// The email address MUST be added to this contact before it can be set as the default email address
        /// </summary>
        /// <param name="emAdd">
        /// The email address to set as the default email address
        /// </param>
        /// <returns>
        /// True - The email address was set as the default email address
        /// False - The email address was NOT set as the default email address
        /// </returns>
        public bool SetDefaultEMailAddress(EmailAddress emAdd)
        {
            bool returnValue = false;

            if (emAdd.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to SetDefaultAddress is null"));
            }//end of if
            if (emAdd.Deleted)
            {
                throw (new ClassDependencyException("The Default Email address has to be an active address"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any default email addresses can be set"));
            }//end of if

            if (emAdd.ContactId != Id)
            {
                throw (new ClassDependencyException("The Email address has to be added to the contact before it can be set as the default email use AddEmailAddress"));
            }
            List<IEMailAddresses> dbEmails = Repository.GetEmailAddresses().Where(e => e.ContactObjid == Id).ToList();
            foreach (IEMailAddresses dbEmail in dbEmails)
            {
                if (dbEmail.Objid == emAdd.Id)
                {
                    dbEmail.DefaultAddress = true;
                    emAdd.IsDefault = true;
                    returnValue = true;
                }
                else
                {
                    dbEmail.DefaultAddress = false;
                }
                Repository.UpdateEmailAddress(dbEmail);
            }
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Does the contact have a default Email Address
        /// </summary>
        /// <returns>
        ///		true - The contact has a default Email Address
        ///		false - The contact does not have a default Email Address
        /// </returns>
        public bool HasDefaultEmailAddress()
        {
            bool returnValue = false;
            EmailAddress defaultEmailAddress = GetDefaultEMailAddress();
            returnValue = defaultEmailAddress.IsNotEmpty();
            return (returnValue);
        }//end of HasDefaultEmailAddress

        /// <summary>
        /// Get all the email addresses for the contact
        /// </summary>
        /// <returns>
        /// An array of email address objects
        /// </returns>
        public EmailAddress[] GetAllEmailAddresses()
        {
            EmailAddress[] returnValues = null;
            returnValues = GetAllEmailAddresses(false);
            return returnValues;
        }//end of method

        /// <summary>
        /// Gets all the active email addresses for the contact
        /// </summary>
        /// <returns>
        /// An array of email address objects.
        /// </returns>
        public EmailAddress[] GetAllEmailAddresses(bool includeDeleted)
        {
            List<EmailAddress> returnValues = new List<EmailAddress>();

            List<IEMailAddresses> dbEmails = Repository.GetEmailAddresses().Where(e => e.ContactObjid == Id).ToList();
            foreach (IEMailAddresses dbEmail in dbEmails)
            {
                EmailAddress tempEmailAddy = new EmailAddress(Repository);
                tempEmailAddy.CopyPropertiesFromDbObj(dbEmail);
                tempEmailAddy.IsNew = false;
                if (includeDeleted)
                {
                    returnValues.Add(tempEmailAddy);
                }
                else if (tempEmailAddy.Deleted == false)
                {
                    returnValues.Add(tempEmailAddy);
                }
            }
            return returnValues.ToArray();
        }//end of method

        /// <summary>
        /// Adds a email address to the contact
        /// </summary>
        /// <param name="addressToAdd">
        /// The email address to be added to the contact
        /// </param>
        public EmailAddress AddEmailAddress(string addressToAdd)
        {
            EmailAddress addyObj = null;
            if (addressToAdd.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddEmailAddress is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any email addresses can be added to it"));
            }//end of if
            addyObj = new EmailAddress(Repository);
            addyObj.Address = addressToAdd;
            addyObj.ContactId = Id;
            if (GetAllEmailAddresses().Length < 1)
            {
                addyObj.IsDefault = true;
            }
            addyObj.Save();
            return (addyObj);
        }//end of method

        /// <summary>
        /// Gets the default email address for the contact
        /// </summary>
        /// <returns>
        /// The default email address
        /// </returns>
        public EmailAddress GetDefaultEMailAddress()
        {
            EmailAddress returnValue = null;
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before getting the default phone number"));
            }//end of if
            IEMailAddresses dbEmail = Repository.GetEmailAddresses().FirstOrDefault(e => e.ContactObjid == Id && e.DefaultAddress);
            if (dbEmail.IsNotEmpty())
            {
                returnValue = new EmailAddress(Repository);
                returnValue.CopyPropertiesFromDbObj(dbEmail);
                returnValue.IsNew = false;
            }
            return (returnValue);
        }//end of method

        /// <summary>
        /// Determines whether the specified email address exists for the contact.
        /// This does exclude deleted email addresses
        /// </summary>
        /// <param name="addressToLookFor">The address to look for.</param>
        /// <returns><c>true</c> if the specified address to look for has email; otherwise, <c>false</c>.</returns>
        /// <exception cref="InvalidParameterException">The addressToLookFor is a required parameter</exception>
        public bool HasEmail(string addressToLookFor)
        {
            if (addressToLookFor.IsEmpty())
            {
                throw new InvalidParameterException("The addressToLookFor is a required parameter");
            }

            string adjustedAddress = addressToLookFor.ToUpper();
            List<IEMailAddresses> dbEmails = Repository.GetEmailAddresses()
                .Where(e => e.Deleted == false && e.ContactObjid == Id && e.Address.ToUpper() == adjustedAddress)
                .ToList();
            return dbEmails.IsNotEmpty();
        }

        /// <summary>
        /// Finds the email address for the contact.
        /// </summary>
        /// <param name="addressToLookFor">The address to look for.</param>
        /// <returns>EmailAddress.</returns>
        /// <exception cref="InvalidParameterException">The addressToLookFor is a required parameter</exception>
        public EmailAddress FindEmail(string addressToLookFor)
        {
            if (addressToLookFor.IsEmpty())
            {
                throw new InvalidParameterException("The addressToLookFor is a required parameter");
            }

            EmailAddress returnValue = null;

            string adjustedAddress = addressToLookFor.ToUpper();
            IEMailAddresses dbEmail = Repository
                .GetEmailAddresses()
                .FirstOrDefault(e => e.Deleted == false && e.ContactObjid == Id && e.Address.ToUpper() == adjustedAddress);

            if (dbEmail.IsNotEmpty())
            {
                returnValue = new EmailAddress(Repository);
                returnValue.CopyPropertiesFromDbObj(dbEmail);
                returnValue.IsNew = false;
            }
            return returnValue;
        }

        #endregion

        #region Snailmail Address Manipulation

        /// <summary>
        /// Set the address to the default address for the contact
        /// </summary>
        /// <returns>
        ///		true - it was able to set the address as the default address
        ///		false - it was NOT able to set the address as the default address 
        /// </returns>
        public bool SetDefaultAddress(SnailMailAddress ad)
        {
            bool returnValue = false;
            if (ad == null)
            {
                throw (new InvalidParameterException("The passed in parameter to SetDefaultAddress is null"));
            }//end of if
            if (ad.Deleted)
            {
                throw (new ClassDependencyException("The Default Address has to be an active address"));
            }//end of if
            if (ad.IsNew)
            {
                throw (new ClassDependencyException("The Default Address has to be an saved before being set as the default address"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before setting the default snail mail address"));
            }//end of if
            returnValue = Repository.SetDefaultSnailMailAddress(Id, ad.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Get the default address for the contact
        /// </summary>
        /// <returns>
        ///		The default address or null when
        ///		there is not a default address
        /// </returns>
        public SnailMailAddress GetDefaultAddress()
        {
            SnailMailAddress returnValue = null;
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before getting the default address"));
            }//end of if
            ISnailMailAddresses tempAddress = Repository.GetDefaultSnailMailAddress(Id);
            if (tempAddress.IsNotEmpty())
            {
                returnValue = new SnailMailAddress(Repository);
                returnValue.CopyPropertiesFromDbObj(tempAddress);
                returnValue.IsNew = false;
            }
            return (returnValue);
        }//end of GetDefaultAddress

        /// <summary>
        /// Does the contact have a default Address
        /// </summary>
        /// <returns>
        ///		true - The contact has a default Address
        ///		false - The contact does not have a default Address
        /// </returns>
        public bool HasDefaultAddress()
        {
            bool returnValue = false;
            SnailMailAddress defaultAddress = GetDefaultAddress();
            returnValue = defaultAddress.IsNotEmpty();
            return (returnValue);
        }//end of HasDefaultAddress

        /// <summary>
        /// Get all the addresses for the contact
        /// </summary>
        /// <returns>
        /// An array of address objects
        /// </returns>
        public SnailMailAddress[] GetAllAddresses()
        {
            SnailMailAddress[] returnValues = null;
            returnValues = GetAllAddresses(false);
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the active address for the contact
        /// </summary>
        /// <returns>
        /// An array of address objects
        /// </returns>
        public SnailMailAddress[] GetAllAddresses(bool includeDeleted)
        {
            List<SnailMailAddress> returnValues = new List<SnailMailAddress>();
            IEnumerable<ISnailMailAddresses> results = Repository.GetContactSnailMailAddresses(Id, includeDeleted);
            foreach (ISnailMailAddresses dbObj in results)
            {
                SnailMailAddress tempAddress = new SnailMailAddress(Repository);
                tempAddress.CopyPropertiesFromDbObj(dbObj);
                tempAddress.IsNew = false;
                returnValues.Add(tempAddress);
            }
            return (returnValues.ToArray());
        }//end of method

        /// <summary>
        /// Adds a address to the contact
        /// </summary>
        /// <param name="adToAdd">
        /// The address to be added to the contact
        /// </param>
        public void AddAddress(SnailMailAddress adToAdd)
        {
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any address can be added to it"));
            }//end of if
            if (adToAdd.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddAddress is null"));
            }//end of if
            if (adToAdd.IsNew)//the phone number is a new phone number and has not been added to the db yet
            {
                adToAdd.Save();
            }//end of if
            Repository.AddSnailMailAddressToContact(Id, adToAdd.Id);
            Repository.SaveChanges();
        }//end of method

        /// <summary>
        /// Remove a address from the contact
        /// </summary>
        /// <param name="adToRemove">
        /// The address to be removed
        /// </param>
        public bool RemoveAddress(SnailMailAddress adToRemove)
        {
            bool returnValue = false;
            if (adToRemove.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to RemoveAddress is null"));
            }//end of if
            if (adToRemove.IsNew)
            {
                throw (new ClassDependencyException("The snail mail address to remove has not been added to the system yet"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The contact needs to be saved before any snail mail addresses can be removed to it"));
            }//end of if
            returnValue = Repository.RemoveSnailMailAddressFromContact(Id, adToRemove.Id);
            Repository.SaveChanges();
            return (returnValue);
        }//end of method

        #endregion

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Used to get a contact based on the id 
        /// </summary>
        /// <param name="id">
        /// a piece of data that Uniquely identifies the data record in the db
        /// </param>
        /// <returns>
        /// A new contact object filled with data based on the id passed in
        /// </returns>
        public static Contact GetById(int id, IRepository repository)
        {
            Contact returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Contact(id, repository);
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
        public static List<Contact> GetAll(IRepository repository)
        {
            List<Contact> returnValue = null;
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
        public static List<Contact> GetAll(bool includeDeleted, IRepository repository,bool excludeUserCreated = true)
        {
            IEnumerable<IContacts> tempList = null;
            List<Contact> returnValue = new List<Contact>();
            tempList = repository.GetContacts();
            foreach (IContacts tempItem in tempList)
            {
                var temp = new Contact(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.isNew = false;
                if (includeDeleted || tempItem.Deleted == false)
                {
                    if (!excludeUserCreated)
                    {
                        returnValue.Add(temp);
                    }
                    else if (temp.firstName != User.NoFirstName && temp.lastName != User.NoLastName)
                    {
                        returnValue.Add(temp);
                    }
                }
            }
            return returnValue;
        }

        #endregion

        #region Internal Methods

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected override void CommonInit()
        {
            base.CommonInit();
            firstName = string.Empty;
            lastName = string.Empty;
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
            if (firstName.IsEmpty())
            {
                throw (new RequiredFieldException("First Name is Mandatory"));
            }//end of if
            if (lastName.IsEmpty())
            {
                throw (new RequiredFieldException("Last Name is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IContacts dbObj = Repository.CreateContact();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertContact(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IContacts dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateContact(dbObj);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected IContacts GetDbRecord(int id)
        {
            return Repository.GetContact(id);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IContacts dbObj)
        {
            if (this.Id.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
            }
            dbObj.FirstName = this.firstName;
            dbObj.LastName = this.lastName;
            dbObj.Deleted = this.Deleted;
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IContacts dbObj)
        {
            this.Id = dbObj.Objid;
            this.firstName = dbObj.FirstName;
            this.lastName = dbObj.LastName;
            this.Deleted = dbObj.Deleted;
        }

        #endregion

        #endregion

    }//end of class
}
