using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Contacts
{
    public class PhoneNumberType : BussinessObject
    {
        #region Constants
        #endregion Constants

        #region Local Vars

        #endregion Local Vars

        #region Properties

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public PhoneType Type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [deleted].
        /// </summary>
        /// <value>
        /// <see langword="true" /> if [deleted]; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PhoneNumberType(IRepository repository) : base(repository)
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
        /// <param name="repository"></param>
        protected PhoneNumberType(int id, IRepository repository) : this(repository)
        {
            IPhoneNumberType dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }

        #endregion Constructors

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
            Repository.DeletePhoneNumberType(Id);
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
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static PhoneNumberType GetById(int id, IRepository repository)
        {
            PhoneNumberType returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PhoneNumberType(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets all active objects in a list
        /// </summary>
        /// <returns></returns>
        public static List<PhoneNumberType> GetAll(IRepository repository)
        {
            List<PhoneNumberType> returnValue = null;
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
        public static List<PhoneNumberType> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IPhoneNumberType> tempList = null;
            List<PhoneNumberType> returnValue = new List<PhoneNumberType>();
            tempList = repository.GetPhoneNumberTypes();
            foreach (IPhoneNumberType tempObj in tempList)
            {
                if (includeDeleted || !tempObj.Deleted)
                {
                    PhoneNumberType temp = new PhoneNumberType(repository);
                    temp.CopyPropertiesFromDbObj(tempObj);
                    temp.isNew = false;
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Gets or create the specified PhoneNumberType Object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>PhoneNumberType.</returns>
        public static PhoneNumberType GetOrCreatePhoneNumberType(PhoneType type, IRepository repository)
        {
            var returnValue = GetAll(repository).FirstOrDefault(pt => pt.Type == type);
            if (returnValue == null)
            {
                returnValue = new PhoneNumberType(repository)
                {
                    Type = type
                };
                returnValue.Save();
            }
            return returnValue;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected override void CommonInit()
        {
            base.CommonInit();
            Deleted = false;
            Type = PhoneType.None;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            if (Type.IsEmpty() || Type == PhoneType.None)
            {
                throw (new RequiredFieldException("Type is Mandatory"));
            }
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IPhoneNumberType dbObj = Repository.CreatePhoneNumberType();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPhoneNumberType(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPhoneNumberType dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePhoneNumberType(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPhoneNumberType GetDbRecord(int id)
        {
            return Repository.GetPhoneNumberType(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPhoneNumberType dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.PhoneNumbertype = this.Type.ToString();
                dbObj.Deleted = this.Deleted;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPhoneNumberType dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Type = (PhoneType)dbObj.PhoneNumbertype.ToEnum(PhoneType.None);
                this.Deleted = dbObj.Deleted;
            }
        }

        #endregion

        #endregion Methods

    }//end of PhoneNumberType
}
