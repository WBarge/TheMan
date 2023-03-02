using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.OrderInvoice
{
    public class CustomItemOptionAttribute : BussinessObject
    {

        #region Constants

        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The a piece of data that Uniquely identifies the data record in the db
        /// </summary>
        public int CustomItemOptionId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomItemOptionAttribute(IRepository repository) : base(repository)
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
        protected CustomItemOptionAttribute(int id, IRepository repository) : this(repository)
        {
            ICustomItemOptionAttributes dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Instance Methods

        #region CustomItemOptionAttribute Manipulation

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
            Repository.DeleteCustomItemOptionAttribute(Id);
            Repository.SaveChanges();
        }

        #endregion

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Used to get a order item based on the id 
        /// </summary>
        /// <param name="id">
        /// a piece of data that Uniquely identifies the data record in the db
        /// </param>
        /// <returns>
        /// A new order/invoice object filled with data based on the id passed in
        /// </returns>
        public static CustomItemOptionAttribute GetById(int id, IRepository repository)
        {
            CustomItemOptionAttribute returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new CustomItemOptionAttribute(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Factory method - Gets objects as an array
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static CustomItemOptionAttribute[] GetAllAsArray(IRepository repository)
        {
            CustomItemOptionAttribute[] returnValue = null;
            returnValue = GetAll(repository).ToArray();
            return (returnValue);
        }//end of method

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static List<CustomItemOptionAttribute> GetAll(IRepository repository)
        {
            IEnumerable<ICustomItemOptionAttributes> tempList = null;
            List<CustomItemOptionAttribute> returnValue = new List<CustomItemOptionAttribute>();
            CustomItemOptionAttribute temp = null;
            tempList = repository.GetCustomItemOptionAttributes();
            foreach (ICustomItemOptionAttributes tempItem in tempList)
            {
                temp = new CustomItemOptionAttribute(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.isNew = false;
                returnValue.Add(temp);
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
            Id = 0;
            CustomItemOptionId = 0;
            AttributeId = 0;
            AttributeValue = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        override protected void Validate()
        {
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            ICustomItemOptionAttributes dbObj = Repository.CreateCustomItemOptionAttribute();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertCustomItemOptionAttribute(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ICustomItemOptionAttributes dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateCustomItemOptionAttribute(dbObj);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected ICustomItemOptionAttributes GetDbRecord(int id)
        {
            ICustomItemOptionAttributes returnValue = Repository.GetCustomItemOptionAttribute(id);
            return returnValue;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ICustomItemOptionAttributes dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.CustomItemOptionObjid = this.CustomItemOptionId;
                dbObj.AttributeObjid = AttributeId;
                dbObj.Value = AttributeValue;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ICustomItemOptionAttributes dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.CustomItemOptionId = dbObj.CustomItemOptionObjid;
                this.AttributeId = dbObj.AttributeObjid;
                this.AttributeValue = dbObj.Value;
            }
        }
        #endregion

        #endregion


    }
}
