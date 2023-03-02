using System;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class OptionPrice : BussinessObject
    {

        #region Constants
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="OptionPrice"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }
        /// <summary>
        /// Gets or sets the option identifier.
        /// </summary>
        /// <value>
        /// The option identifier.
        /// </value>
        internal int OptionId { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End { get; set; }
        /// <summary>
        /// Gets the flat price.
        /// </summary>
        /// <value>
        /// The flat price.
        /// </value>
        public decimal FlatPrice { get; internal set; }
        /// <summary>
        /// Gets the valid time period.
        /// </summary>
        /// <value>
        /// The valid time period.
        /// </value>
        public DateRange ValidTimePeriod { get { return (new DateRange(Start, End)); } }

        /// <summary>
        /// Gets the default time used as the default start and end.
        /// </summary>
        /// <value>
        /// The default time.
        /// </value>
        internal DateTime DefaultTime
        {
            get { return DateTime.MaxValue; }
        }

        /// <summary>
        /// Gets the default time period.
        /// </summary>
        /// <value>
        /// The default time period.
        /// </value>
        internal DateRange DefaultTimePeriod
        {
            get { return (new DateRange(DefaultTime, DefaultTime)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionPrice(IRepository repository) : base(repository)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">The id for the object to be loaded</param>
        /// <param name="repository">The repository.</param>
        protected OptionPrice(int id, IRepository repository) : this(repository)
        {
            IOptionPrice dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Determines whether is default price].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is default price]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConfiguredAsADefaultPrice()
        {
            return DefaultTimePeriod == ValidTimePeriod;
        }


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
            Repository.DeleteOptionPrice(Id);
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

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static OptionPrice GetById(int id, IRepository repository)
        {
            OptionPrice returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new OptionPrice(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Sets the price of the option
        /// Using this method means the price is a set price aka a flatPrice
        /// </summary>
        /// <param name="price">the price of the option</param>
        public void SetPrice(decimal price)
        {
            FlatPrice = price;
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
            Deleted = false;
            OptionId = 0;
            Start = DefaultTime;
            End = DefaultTime;
            FlatPrice = decimal.Zero;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            if (OptionId.IsEmpty())
            {
                throw (new RequiredFieldException("The optionID is required"));
            }
            if (FlatPrice.IsEmpty())
            {
                throw (new RequiredFieldException("Price must be set"));
            }//end of if
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IOptionPrice dbObj = Repository.CreateOptionPrice();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertOptionPrice(dbObj);
            Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IOptionPrice dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateOptionPrice(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IOptionPrice GetDbRecord(int id)
        {
            return Repository.GetOptionPrice(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IOptionPrice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (Id.IsNotEmpty())
                {
                    dbObj.Objid = Id;
                }
                dbObj.Deleted = Deleted;
                dbObj.OptionObjid = OptionId;
                if (Start != DefaultTime)
                {
                    dbObj.StartDate = Start.ToUniversalTime();
                }
                if (End != DefaultTime)
                {
                    dbObj.EndDate = End.ToUniversalTime();
                }
                dbObj.FlatPrice = FlatPrice;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IOptionPrice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                Id = dbObj.Objid;
                Deleted = dbObj.Deleted;
                OptionId = dbObj.OptionObjid;
                Start = dbObj.StartDate ?? DefaultTime;
                Start = DateTime.SpecifyKind(Start, DateTimeKind.Utc);
                End = dbObj.EndDate ?? DefaultTime;
                End = DateTime.SpecifyKind(End, DateTimeKind.Utc);
                FlatPrice = dbObj.FlatPrice ?? decimal.Zero;
            }
        }

        #endregion

        #endregion

    }
}
