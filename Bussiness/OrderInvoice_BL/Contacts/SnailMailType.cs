using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class SnailMailType : BussinessObject
    {

        #region Constants
        public const int MaxAddresstypeLength = 50;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the address type as string.
        /// </summary>
        /// <value>
        /// The address type as string.
        /// </value>
        internal string AddressTypeAsString { get; set; }
        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        /// <value>
        /// The type of the address.
        /// </value>
        public MailType AddressType
        {
            get
            {
                return ((MailType)AddressTypeAsString.ToEnum(MailType.None));
            }
            set
            {
                AddressTypeAsString = value.ToString();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal SnailMailType(IRepository repository) : base(repository)
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
        protected SnailMailType(int id, IRepository repository) : this(repository)
        {
            ISnailMailType dbObj = GetDbRecord(id);
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
            Repository.DeleteSnailMailType(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static SnailMailType GetById(int id, IRepository repository)
        {
            SnailMailType returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new SnailMailType(id, repository);
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
        public static List<SnailMailType> GetAll(IRepository repository)
        {
            IEnumerable<ISnailMailType> tempList = null;
            List<SnailMailType> returnValue = new List<SnailMailType>();
            SnailMailType temp = null;
            tempList = repository.GetSnailMailTypes();
            foreach (ISnailMailType tempItem in tempList)
            {
                temp = new SnailMailType(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Creates the specified SnailMailType Object.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="type">The type.</param>
        /// <returns>SnailMailType.</returns>
        public static SnailMailType Create(IRepository repository, MailType type)
        {
            SnailMailType returnValue = new SnailMailType(repository);
            returnValue.AddressType = type;
            returnValue.Save();
            return returnValue;
        }

        /// <summary>
        /// Gets or create the specified SnailMailType Object.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="type">The type.</param>
        /// <returns>SnailMailType.</returns>
        public static SnailMailType GetOrCreateSnailMailType(IRepository repository, MailType type)
        {
            var returnValue = GetAll(repository).FirstOrDefault(mt => mt.AddressType == type) ??
                              Create(repository, type);
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
            AddressTypeAsString = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        override protected void Validate()
        {
            if (AddressTypeAsString.IsEmpty() || AddressTypeAsString == MailType.None.ToString())
            {
                throw (new RequiredFieldException("AddressType is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            ISnailMailType dbObj = Repository.CreateSnailMailType();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertSnailMailType(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ISnailMailType dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateSnailMailType(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private ISnailMailType GetDbRecord(int id)
        {
            return Repository.GetSnailMailType(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ISnailMailType dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.AddressType = this.AddressTypeAsString;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ISnailMailType dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.AddressTypeAsString = dbObj.AddressType;
            }
        }


        #endregion

        #endregion

    }
}
