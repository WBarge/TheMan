using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    public class ProductPrice : BussinessObject
    {

        #region Constants
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="ProductPrice"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        internal int ProductId { get; set; }
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
        /// Gets the formula price.
        /// </summary>
        /// <value>
        /// The formula price.
        /// </value>
        public string FormulaPrice { get; internal set; }
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
        internal DateTime DefaultTime {
            get { return DateTime.MaxValue;}
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
        public ProductPrice(IRepository repository)
            : base(repository)
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
        protected ProductPrice(int id, IRepository repository) : this(repository)
        {
            IProductPrice dbObj = GetDbRecord(id);
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
            Repository.DeleteProductPrice(Id);
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
        public static ProductPrice GetById(int id, IRepository repository)
        {
            ProductPrice returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new ProductPrice(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Sets the price of the product
        /// Using this method means the price is a set price aka a flatPrice
        /// </summary>
        /// <param name="price">the price of the option</param>
        public void SetPrice(decimal price)
        {
            FlatPrice = price;
        }

        /// <summary>
        /// Sets the formula to calculate the price at run time
        /// If the price option is a new price option validation will be ran when saved by the product option object
        /// if the price option is not a new object the formula will be validated with a call to this method
        /// when the formula is validated and validation fails the formula is not saved and will need to be set
        /// </summary>
        /// <param name="formulaPrice">the formula</param>
        /// <param name="errors">any error messages if the formula is validated and fails</param>
        /// <returns>
        ///     true - the formula was set
        ///     false - the formula was not set
        /// </returns>
        public bool SetPrice(string formulaPrice, out List<string> errors)
        {
            errors = new List<string>();
            bool returnValue = false;
            FormulaPrice = formulaPrice;
            if (ProductId.IsNotEmpty())
            {
                returnValue = ValidateFormulaPrice(errors);
                if (!returnValue)
                {
                    FormulaPrice = string.Empty;
                }
            }
            else
            {
                returnValue = true;
            }
            return (returnValue);
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
            ProductId = 0;
            Start = DefaultTime;
            End = DefaultTime;
            FlatPrice = decimal.Zero;
            FormulaPrice = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            List<string> errors = new List<string>();
            if (ProductId.IsEmpty())
            {
                throw (new RequiredFieldException("The productID is required"));
            }
            if (FlatPrice.IsEmpty() && FormulaPrice.IsEmpty())
            {
                throw (new RequiredFieldException("Price or FormulaPrice must be set"));
            }//end of if
            if (FlatPrice.IsEmpty() && !ValidateFormulaPrice(errors))
            {
                string errorMsg = ErrorMessage.BuildErrorMessage("The formula for the price is not valid.  Error(s):", errors);
                throw (new DataException(errorMsg));
            }
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IProductPrice dbObj = Repository.CreateProductPrice();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertProductPrice(dbObj);
            Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IProductPrice dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateProductPrice(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Validate the formula price will check the formula is not empty and the variables in the formula
        /// are attributes of the option.
        /// This Validate method will not check for mathematical error e.g. division by zero
        /// </summary>
        /// <param name="errors">any error messages</param>
        /// <returns>
        ///     false - the formula is not valid
        ///     true - the formula is valid
        /// </returns>
        internal bool ValidateFormulaPrice(List<string> errors)
        {
            bool returnValue = false;
            if (errors.IsEmpty())
            {
                errors = new List<string>();
            }
            if (FormulaPrice.IsNotEmpty())
            {
                MathParser.Parser parser = new MathParser.Parser();
                List<string> variables = parser.GetVariableNames(FormulaPrice);
                Product product = Product.GetById(ProductId, Repository);
                string[] productAttributes = product.GetAttributesAsVariables();
                foreach (string name in variables)
                {
                    string attr = productAttributes.FirstOrDefault(a => a == name);
                    if (attr.IsEmpty())
                    {
                        errors.Add($"The variable {name} is not an attribute of the product {product.Name}");
                    }
                }
                if (errors.IsEmpty())
                {
                    returnValue = true;
                }
            }
            else
            {
                errors.Add("The FormulaPrice is empty");
            }
            return (returnValue);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IProductPrice GetDbRecord(int id)
        {
            return Repository.GetProductPrice(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IProductPrice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (Id.IsNotEmpty())
                {
                    dbObj.Objid = Id;
                }
                dbObj.Deleted = Deleted;
                dbObj.ProductObjid = ProductId;
                if (Start != DefaultTime)
                {
                    dbObj.StartDate = Start.ToUniversalTime();
                }
                if (End != DefaultTime)
                {
                    dbObj.EndDate = End.ToUniversalTime();
                }
                dbObj.FlatPrice = FlatPrice;
                dbObj.FormulaPrice = FormulaPrice;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IProductPrice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                Id = dbObj.Objid;
                Deleted = dbObj.Deleted.HasValue && dbObj.Deleted.Value;
                ProductId = dbObj.ProductObjid;
                Start = dbObj.StartDate ?? DefaultTime;
                Start = DateTime.SpecifyKind(Start, DateTimeKind.Utc);               
                End = dbObj.EndDate ?? DefaultTime;
                End = DateTime.SpecifyKind(End, DateTimeKind.Utc);
                FlatPrice = dbObj.FlatPrice ?? decimal.Zero;
                FormulaPrice = dbObj.FormulaPrice;
            }
        }

        #endregion

        #endregion

    }
}
