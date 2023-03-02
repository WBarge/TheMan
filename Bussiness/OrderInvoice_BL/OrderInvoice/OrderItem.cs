using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.OrderInvoice
{
    public class OrderItem : BussinessObject
    {

        #region Constants

        #endregion

        #region Local Vars

        #endregion

        #region Properties

        public int OrderInvoiceId { get; set; }
        //this line item is a predefined product
        public int? PredefinedProductId { get; set; }
        //this line item is custom product
        //with custom options (see CustomItemOption)
        public int? ProductId { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OrderItem(IRepository repository) : base(repository)
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
        protected OrderItem(int id, IRepository repository) : this(repository)
        {
            IOrderItem dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Instance Methods

        #region OrderItem Manipulation

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
            Repository.DeleteOrderItem(Id);
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
        public static OrderItem GetById(int id, IRepository repository)
        {
            OrderItem returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new OrderItem(id, repository);
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
        public static List<OrderItem> GetAll(IRepository repository)
        {
            IEnumerable<IOrderItem> tempList = null;
            List<OrderItem> returnValue = new List<OrderItem>();
            OrderItem temp = null;
            tempList = repository.GetOrderItems();
            foreach (IOrderItem tempItem in tempList)
            {
                temp = new OrderItem(repository);
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
            OrderInvoiceId = 0;
            PredefinedProductId = null;
            ProductId = null;
            Price = decimal.Zero;
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
            IOrderItem dbObj = Repository.CreateOrderItem();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertOrderItem(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IOrderItem dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateOrderItem(dbObj);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected IOrderItem GetDbRecord(int id)
        {
            IOrderItem returnValue = Repository.GetOrderItem(id);
            return returnValue;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IOrderItem dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.OrderInvoiceObjid = this.OrderInvoiceId;
                dbObj.PredefinedProductObjid = this.PredefinedProductId;
                dbObj.ProductObjid = this.ProductId;
                dbObj.Price = this.Price;
                dbObj.Note = this.Note;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IOrderItem dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.OrderInvoiceId = dbObj.OrderInvoiceObjid;
                this.PredefinedProductId = dbObj.PredefinedProductObjid;
                this.ProductId = dbObj.ProductObjid;
                this.Price = dbObj.Price;
                this.Note = dbObj.Note;
            }
        }


        #endregion

        #endregion

    }
}
