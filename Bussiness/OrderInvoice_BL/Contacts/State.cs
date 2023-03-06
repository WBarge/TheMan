using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class State : BussinessObject
    {

        #region Constants
        public const int NAME_LENGTH = 20;
        public const int ABBREVIATION_LENGTH = 2;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The email address
        /// </summary>
        internal string NameAsString { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public UsStateName Name
        {
            get
            {
                return ((UsStateName)NameAsString.ToEnum(UsStateName.None));
            }
            internal set
            {
                NameAsString = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public UsStateAbbreviation Abbreviation
        {
            get
            {
                return ((UsStateAbbreviation)AbbreviationAsString.ToEnum(UsStateAbbreviation.None));
            }
            internal set
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
        internal State(IRepository repository) : base(repository)
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
        /// <param name="repository"></param>
        protected State(int id, IRepository repository) : this(repository)
        {
            IStates dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Permanently the remove from system.
        /// </summary>
        /// <exception cref="DataException">You can not delete a new object</exception>
        public override void PermanentlyRemoveFromSystem()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            Repository.DeleteState(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static State GetById(int id, IRepository repository)
        {
            State returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new State(id, repository);
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
        public static List<State> GetAll(IRepository repository)
        {
            IEnumerable<IStates> tempList = null;
            List<State> returnValue = new List<State>();
            tempList = repository.GetStates();
            foreach (IStates tempObj in tempList)
            {
                State temp = new State(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Creates the specified State Object.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name.</param>
        /// <returns>State.</returns>
        public static State Create(UsStateName name, IRepository repository)
        {
            State returnValue = new State(repository)
            {
                Name = name,
                Abbreviation = name.ToState_Abbreviation()
            };
            returnValue.Save();
            return returnValue;
        }

        /// <summary>
        /// Gets or creates the specified State Object..
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>State.</returns>
        public static State GetOrCreateState(UsStateName name, IRepository repository)
        {
            var returnValue = GetAll(repository).FirstOrDefault(mt => mt.Name == name) ?? Create(name, repository);
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
        /// <exception cref="RequiredFieldException">
        /// Name is Mandatory
        /// or
        /// Abbreviation is Mandatory
        /// </exception>
        protected override void Validate()
        {
            if (NameAsString.IsEmpty() || NameAsString == UsStateName.None.ToString())
            {
                throw (new RequiredFieldException("Name is Mandatory"));
            }//end of if
            if (AbbreviationAsString.IsEmpty() || AbbreviationAsString == UsStateAbbreviation.None.ToString())
            {
                throw (new RequiredFieldException("Abbreviation is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IStates dbObj = Repository.CreateState();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertState(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IStates dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateState(dbObj);
        }
        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IStates GetDbRecord(int id)
        {
            return Repository.GetState(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IStates dbObj)
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
        internal void CopyPropertiesFromDbObj(IStates dbObj)
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
