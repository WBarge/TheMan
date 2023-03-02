using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class Attribute : BussinessObject
    {
        #region Constants
        public const int MaxNameLength = 150;
        public const int MaxDescriptionLength = 255;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        private string _name;
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="InvalidLengthException">The Name field is too long</exception>
        public string Name
        {
            get { return (_name); }
            set
            {
                if (value.Length > MaxNameLength)
                {
                    throw (new InvalidLengthException("The Name field is too long"));
                }
                else
                {
                    _name = value.Trim();
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
        /// Gets a value indicating whether this <see cref="Attribute"/> is deleted.
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
        public Attribute(IRepository repository) : base(repository)
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
        protected Attribute(int id, IRepository repository) : this(repository)
        {
            IAttributes dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Methods

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
            Repository.DeleteAttribute(Id);
            IsNew = true;
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

        #endregion Public Instance Methods

        #region Public Static Methods

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static Attribute GetById(int id, IRepository repository)
        {
            Attribute returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Attribute(id, repository);
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
        public static List<Attribute> GetAll(IRepository repository)
        {
            List<Attribute> returnValue = null;
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
        public static List<Attribute> GetAll(bool includeDeleted, IRepository repository)
        {
            IEnumerable<IAttributes> tempList = null;
            List<Attribute> returnValue = new List<Attribute>();
            Attribute temp = null;
            tempList = repository.GetAttributes();
            foreach (IAttributes tempItem in tempList)
            {
                temp = new Attribute(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.isNew = false;
                if (includeDeleted || tempItem.Deleted == false)
                {
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        #endregion Public Static Methods

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
            Name = string.Empty;
            Description = string.Empty;
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
            if (Name.IsEmpty())
            {
                throw (new RequiredFieldException("Name is Mandatory"));
            }//end of if
            if (Description.IsEmpty())
            {
                throw (new RequiredFieldException("Description is Mandatory"));
            }//end of if			
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IAttributes dbObj = Repository.CreateAttribute();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertAttribute(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IAttributes dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateAttribute(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IAttributes GetDbRecord(int id)
        {
            return Repository.GetAttribute(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IAttributes dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Deleted = Deleted;
                dbObj.Name = Name;
                dbObj.Description = _description;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IAttributes dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Deleted = dbObj.Deleted;
                this._name = dbObj.Name;
                this._description = dbObj.Description;
            }
        }


        #endregion

        #endregion Methods

    }
}
