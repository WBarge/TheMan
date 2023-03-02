using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_BL.OrderInvoice
{
    public class CustomItemOption : BussinessObject
    {

        #region Constants

        #endregion

        #region Local Vars

        #endregion

        #region Properties

        public int OrderItemId { get; set; }
        public int ProductOptionId { get; set; }
        public string Note { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomItemOption(IRepository repository) : base(repository)
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
        protected CustomItemOption(int id, IRepository repository) : this(repository)
        {
            ICustomItemOptions dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Instance Methods

        #region CustomItemOption Manipulation

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
            Repository.DeleteCustomItemOption(Id);
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
        public static CustomItemOption GetById(int id, IRepository repository)
        {
            CustomItemOption returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new CustomItemOption(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static List<CustomItemOption> GetAll(IRepository repository)
        {
            IEnumerable<ICustomItemOptions> tempList = null;
            List<CustomItemOption> returnValue = new List<CustomItemOption>();
            CustomItemOption temp = null;
            tempList = repository.GetCustomItemOptions();
            foreach (ICustomItemOptions tempItem in tempList)
            {
                temp = new CustomItemOption(repository);
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
            OrderItemId = 0;
            ProductOptionId = 0;
            Note = string.Empty;
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
            ICustomItemOptions dbObj = Repository.CreateCustomItemOption();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertCustomItemOption(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ICustomItemOptions dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateCustomItemOption(dbObj);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected ICustomItemOptions GetDbRecord(int id)
        {
            ICustomItemOptions returnValue = Repository.GetCustomItemOption(id);
            return returnValue;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ICustomItemOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.OrderItemObjid = this.OrderItemId;
                dbObj.ProductOptionObjid = this.ProductOptionId;
                dbObj.Note = this.Note;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ICustomItemOptions dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.OrderItemId = dbObj.OrderItemObjid;
                this.ProductOptionId = dbObj.ProductOptionObjid;
                this.Note = dbObj.Note;
            }
        }

        #endregion

        #endregion


    }
}
