using System.Linq;
using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Products
{
    /// <summary>
    /// This class is to be used to store products which
    /// have already been made and ready to be sold
    /// Product is where you define the product the company mades
    /// and define custom made products
    /// </summary>
    public class PredefinedProduct : BussinessObject
    {
        #region Constants
        public const int DESCRIPTION_LENGTH = 255;
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        // ReSharper disable once InconsistentNaming
        internal Product Product;
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get { return Product.Id; } }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        private string _description;
        /// <summary>
        /// Gets or sets the description.
        /// Intended use is for a marketing description of the product
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
                if (value.Length > DESCRIPTION_LENGTH)
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
        /// Gets a value indicating whether this <see cref="PredefinedProduct"/> is deleted.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if deleted; otherwise, <see langword="false" />.
        /// </value>
        public bool Deleted { get; internal set; }

        public int Quantity { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        protected PredefinedProduct(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrderInvoice_BL.Products.PredefinedProduct" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="product">The product which has already been made and is ready to be sold.</param>
        public PredefinedProduct(IRepository repository, Product product) : this(repository)
        {
            Product = product;
        }//end of default constructor


        /// <summary>
        /// Constructor used to pre-load the data into the object
        /// </summary>
        /// <param name="id">The id for the object to be loaded</param>
        /// <param name="repository">The repository.</param>
        /// <inheritdoc />
        protected PredefinedProduct(int id, IRepository repository)
            : this(repository)
        {
            IPredefinedProducts dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

        #region PredefinedProduct Manipulation

        /// <inheritdoc />
        /// <summary>
        /// Permanently remove the object from the system.
        /// </summary>
        /// <exception cref="T:Exceptions.DataException">You can not delete a new object</exception>
        public override void PermanentlyRemoveFromSystem()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            List<PredefinedProductDetail> ppds = PredefinedProductDetail.GetAll(true, Id, Repository);
            foreach (PredefinedProductDetail ppd in ppds)
            {
                Repository.DeletePredefinedProductDetail(ppd.Id);
            }
            Repository.DeletePredefinedProduct(Id);
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

        #endregion PredefinedProduct Manipulation

        #region Attribute Manipulation

        /// <summary>
        /// Get all the active attributes for the product
        /// These are the attributes for the base product
        /// </summary>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetProductAttributes()
        {
            Attribute[] returnValues = Product.GetAttributes();
            return (returnValues);
        }//end of method

        /// <summary>
        /// Gets all the attributes for the product
        /// These are the attributes for the base product
        /// </summary>
        /// <param name="includeDeleted">
        ///     true - include deleted attributes
        ///     false - do not include deleted attributes
        /// </param>
        /// <returns>
        /// An array of attribute objects
        /// </returns>
        public Attribute[] GetProductAttributes(bool includeDeleted)
        {
            Attribute[] returnValues = Product.GetAttributes(includeDeleted);
            return (returnValues);
        }//end of method

        #endregion Attribute Manipulation

        #region Attribute Value Manipulation

        /// <summary>
        /// Get the possible values for the attribute
        /// </summary>
        /// <param name="attri">the attribute</param>
        /// <returns></returns>
        public ProductAttributeValue[] GetProductAttributeValues(Attribute attri)
        {
            return GetProductAttributeValues(attri, false).ToArray();
        }

        /// <summary>
        /// Gets the possible values for the attribute
        /// </summary>
        /// <param name="attri">the attribute</param>
        /// <param name="includeDeleted">include deleted items</param>
        /// <returns></returns>
        public List<ProductAttributeValue> GetProductAttributeValues(Attribute attri, bool includeDeleted)
        {
            List<ProductAttributeValue> returnValue = Product.GetAttributeValues(attri, includeDeleted);
            return (returnValue);
        }

        /// <summary>
        /// Adds the attribute value.
        /// </summary>
        /// <param name="attri">The attri.</param>
        /// <param name="attriValue">The value.</param>
        /// <exception cref="InvalidParameterException">The attribute and value are manditory in order to add the attribute value to the predefined product</exception>
        public void AddAttributeValue(Attribute attri, string attriValue)
        {
            if (attri.IsEmpty())
            {
                throw new InvalidParameterException("The attribute is mandatory in order to add the attribute value to the predefined product");
            }
            if (attriValue.IsEmpty())
            {
                throw new InvalidParameterException("The attribute value is mandatory in order to add the attribute value to the predefined product");
            }
            PredefinedProductDetail ppd = PredefinedProductDetail.GetForAttribute(Repository, Id, attri);
            if (ppd.IsEmpty())
            {
                ppd = new PredefinedProductDetail(Repository, this, attri);
            }
            ppd.Value = attriValue;
            ppd.Save();
        }

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <param name="attri">The attri.</param>
        /// <returns></returns>
        /// <exception cref="InvalidParameterException">The attribute in order to get the attribute value for the predefined product</exception>
        public string GetAttributeValue(Attribute attri)
        {
            string returnValue = string.Empty;
            if (attri.IsEmpty())
            {
                throw new InvalidParameterException("The attribute in order to get the attribute value for the predefined product");
            }
            PredefinedProductDetail ppd = PredefinedProductDetail.GetForAttribute(Repository, Id, attri);
            if (ppd.IsNotEmpty())
            {
                returnValue = ppd.Value;
            }
            return returnValue;
        }

        /// <summary>
        /// Removes all attribute values.
        /// </summary>
        public void RemoveAllAttributeValues()
        {
            List<PredefinedProductDetail> ppds = PredefinedProductDetail.GetAll(true, Id, Repository);
            ppds.ForEach(p => Repository.DeletePredefinedProductDetail(p.Id));
            Repository.SaveChanges();
        }

        #endregion Attribute Value Manipulation

        #region Option Manipulation

        public PredefinedOption[] GetPredefinedOptions(bool includeDeleted = false)
        {
            IEnumerable<PredefinedOption> tempList = PredefinedOption.GetAll(includeDeleted, Repository);
            List<PredefinedOption> returnValue = tempList.Where(po => po.PredefinedProductId == Id).ToList();
            return returnValue.ToArray();
        }


        #endregion Option Manipulation

        #endregion Public Instance Methods

        #region Public Static Method

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static PredefinedProduct GetById(int id, IRepository repository)
        {
            PredefinedProduct returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new PredefinedProduct(id, repository);
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
        public static List<PredefinedProduct> GetAll(IRepository repository)
        {
            List<PredefinedProduct> returnValue = GetAll(false, repository);
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="includeDeleted">true - return both active and inactive objects
        /// false - return active objects only</param>
        /// <param name="repository">The repository.</param>
        /// <returns>List&lt;PredefinedProduct&gt;.</returns>
        public static List<PredefinedProduct> GetAll(bool includeDeleted, IRepository repository)
        {
            List<PredefinedProduct> returnValue = new List<PredefinedProduct>();
            IEnumerable<IPredefinedProducts> tempList = repository.GetPredefinedProducts();
            foreach (IPredefinedProducts tempItem in tempList)
            {
                if (includeDeleted || tempItem.Deleted == false)
                {
                    PredefinedProduct temp = new PredefinedProduct(repository);
                    temp.CopyPropertiesFromDbObj(tempItem);
                    temp.isNew = false;
                    returnValue.Add(temp);
                }
            }
            return returnValue;
        }

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected sealed override void CommonInit()
        {
            base.CommonInit();
            Product = null;
            Price = DefaultValues.DefaultDecimal;
            Description = string.Empty;
            Deleted = false;
            Quantity = 1;
        }

        /// <inheritdoc />
        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            if (Price.IsEmpty())
            {
                throw (new RequiredFieldException("Price is Mandatory"));
            }//end of if
            if (ProductId.IsEmpty())
            {
                throw (new ClassDependencyException("The Product has to be saved before the predefined product is saved"));
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IPredefinedProducts dbObj = Repository.CreatePredefinedProduct();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertPredefinedProduct(dbObj);
            Id = dbObj.Objid;
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IPredefinedProducts dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdatePredefinedProduct(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IPredefinedProducts GetDbRecord(int id)
        {
            return Repository.GetPredefinedProduct(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IPredefinedProducts dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (Id.IsNotEmpty())
                {
                    dbObj.Objid = Id;
                }
                dbObj.Deleted = Deleted;
                dbObj.Price = Price;
                dbObj.MarketDescription = Description;
                dbObj.ProductObjid = Product.Id;
                dbObj.Quantity = Quantity;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IPredefinedProducts dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                Id = dbObj.Objid;
                Deleted = dbObj.Deleted;
                Price = dbObj.Price;
                Description = dbObj.MarketDescription;
                Quantity = dbObj.Quantity;
                Product = Product.GetById(dbObj.ProductObjid, Repository);
            }
        }

        #endregion

        #endregion Methods

    }
}
