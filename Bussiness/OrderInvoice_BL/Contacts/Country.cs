using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class Country : BussinessObject
    {

        #region Constants
        public const int MaxNameLength = 50;
        public const int MaxAbrvLength = 5;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The email address
        /// </summary>
        internal string NameAsString { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public CountryName Name
        {
            get
            {
                return ((CountryName)NameAsString.ToEnum(CountryName.None));
            }
            set
            {
                NameAsString = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the abbreviation of the country.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public CountryAbbreviation Abbreviation
        {
            get
            {
                return ((CountryAbbreviation)AbbreviationAsString.ToEnum(CountryAbbreviation.None));
            }
            set
            {
                AbbreviationAsString = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the abbreviation as string.
        /// </summary>
        /// <value>
        /// The abbreviation as string.
        /// </value>
        internal string AbbreviationAsString { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal Country(IRepository repository) : base(repository)
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
        protected Country(int id, IRepository repository) : this(repository)
        {
            ICountry dbObj = GetDbRecord(id);
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
            Repository.DeleteCountry(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static Country GetById(int id, IRepository repository)
        {
            Country returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Country(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Creates the specified Country Object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Country.</returns>
        public static Country Create(CountryName name, IRepository repository)
        {
            Country returnValue = new Country(repository);
            returnValue.Name = name;
            returnValue.Abbreviation = name.ToCountry_Abbreviation();
            returnValue.Save();
            return returnValue;
        }

        /// <summary>
        /// Gets or creates the specified Country Object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Country.</returns>
        public static Country GetOrCreateCountry(CountryName name, IRepository repository)
        {
            var returnValue = GetAll(repository).FirstOrDefault(c => c.Name == name) ?? Create(name, repository);
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets all active objects in a list
        /// </summary>
        /// <returns></returns>
        public static List<Country> GetAll(IRepository repository)
        {
            IEnumerable<ICountry> tempList = null;
            List<Country> returnValue = new List<Country>();
            tempList = repository.GetCountries();
            foreach (ICountry tempObj in tempList)
            {
                var temp = new Country(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
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
            NameAsString = string.Empty;
            AbbreviationAsString = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        override protected void Validate()
        {
            if (NameAsString.IsEmpty() || NameAsString == CountryName.None.ToString())
            {
                throw (new RequiredFieldException("Name is Mandatory"));
            }//end of if
            if (AbbreviationAsString.IsEmpty() || AbbreviationAsString == CountryAbbreviation.None.ToString())
            {
                throw (new RequiredFieldException("Abbreviation is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            ICountry dbObj = Repository.CreateCountry();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertCountry(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ICountry dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateCountry(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private ICountry GetDbRecord(int id)
        {
            return Repository.GetCountry(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ICountry dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Name = this.NameAsString;
                dbObj.Abrv = this.AbbreviationAsString;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ICountry dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.NameAsString = dbObj.Name;
                this.AbbreviationAsString = dbObj.Abrv;
            }
        }

        #endregion

        #endregion

    }
}
