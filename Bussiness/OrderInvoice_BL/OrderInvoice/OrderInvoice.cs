using System.Collections.Generic;
using Exceptions;
using OrderInvoice_BL.People;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_BL.OrderInvoice
{
    public class OrderInvoice : BussinessObject
    {

        #region Constants
        public const int ADDRESS_LINE_LENGTH = 40;
        public const int CITY_LENGTH = 40;
        public const int STATE_NAME_LENGTH = 20;
        public const int COUNTRY_NAME_LENGTH = 50;
        public const int ZIP_LENGTH = 12;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The customer
        /// </summary>
        protected Customer customer;
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public Customer OrderInvoiceCustomer { get { return customer; } set { customer = value; } }
        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get { return customer.IsNotEmpty() ? customer.Id : DefaultValues.DefaultInt; } }

        /// <summary>
        /// The employee
        /// </summary>
        protected Employee employee;
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public Employee OrderInvoiceEmployee { get { return employee; } set { employee = value; } }
        /// <summary>
        /// Gets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get { return employee.IsNotEmpty() ? employee.Id : DefaultValues.DefaultInt; } }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public long OrderInvoiceNumber { get; set; }

        /// <summary>
        /// The shipping address line1
        /// </summary>
        protected string shippingAddressLine1;
        /// <summary>
        /// Gets or sets the shipping address line1.
        /// </summary>
        /// <value>
        /// The shipping address line1.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping address line 1 field is too long</exception>
        public string ShippingAddressLine1
        {
            get { return (shippingAddressLine1.Trim()); }

            set
            {
                if (value.Length > ADDRESS_LINE_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping address line 1 field is too long"));
                }
                else
                {
                    shippingAddressLine1 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The shipping address line2
        /// </summary>
        protected string shippingAddressLine2;
        /// <summary>
        /// Gets or sets the shipping address line2.
        /// </summary>
        /// <value>
        /// The shipping address line2.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping address line 2 field is too long</exception>
        public string ShippingAddressLine2
        {
            get { return (shippingAddressLine2.Trim()); }

            set
            {
                if (value.Length > ADDRESS_LINE_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping address line 2 field is too long"));
                }
                else
                {
                    shippingAddressLine2 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The shipping city
        /// </summary>
        protected string shippingCity;
        /// <summary>
        /// Gets or sets the shipping city.
        /// </summary>
        /// <value>
        /// The shipping city.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping city field is too long</exception>
        public string ShippingCity
        {
            get { return (shippingCity.Trim()); }

            set
            {
                if (value.Length > CITY_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping city field is too long"));
                }
                else
                {
                    shippingCity = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The shipping state name
        /// </summary>
        protected string shippingStateName;
        /// <summary>
        /// Gets or sets the name of the shipping state.
        /// </summary>
        /// <value>
        /// The name of the shipping state.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping state name field is too long</exception>
        public string ShippingStateName
        {
            get { return (shippingStateName.Trim()); }

            set
            {
                if (value.Length > STATE_NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping state name field is too long"));
                }
                else
                {
                    shippingStateName = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The shipping country name
        /// </summary>
        protected string shippingCountryName;
        /// <summary>
        /// Gets or sets the name of the shipping country.
        /// </summary>
        /// <value>
        /// The name of the shipping country.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping country name field is too long</exception>
        public string ShippingCountryName
        {
            get { return (shippingCountryName.Trim()); }

            set
            {
                if (value.Length > COUNTRY_NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping country name field is too long"));
                }
                else
                {
                    shippingCountryName = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The shipping zip
        /// </summary>
        protected string shippingZip;
        /// <summary>
        /// Gets or sets the shipping zip.
        /// </summary>
        /// <value>
        /// The shipping zip.
        /// </value>
        /// <exception cref="InvalidLengthException">The shipping zip field is too long</exception>
        public string ShippingZip
        {
            get { return (shippingZip.Trim()); }

            set
            {
                if (value.Length > ZIP_LENGTH)
                {
                    throw (new InvalidLengthException("The shipping zip field is too long"));
                }
                else
                {
                    shippingZip = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice address line1
        /// </summary>
        protected string invoiceAddressLine1;
        /// <summary>
        /// Gets or sets the invoice address line1.
        /// </summary>
        /// <value>
        /// The invoice address line1.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice address line 1 field is too long</exception>
        public string InvoiceAddressLine1
        {
            get { return (invoiceAddressLine1.Trim()); }

            set
            {
                if (value.Length > ADDRESS_LINE_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice address line 1 field is too long"));
                }
                else
                {
                    invoiceAddressLine1 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice address line2
        /// </summary>
        protected string invoiceAddressLine2;
        /// <summary>
        /// Gets or sets the invoice address line2.
        /// </summary>
        /// <value>
        /// The invoice address line2.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice address line 2 field is too long</exception>
        public string InvoiceAddressLine2
        {
            get { return (invoiceAddressLine2.Trim()); }

            set
            {
                if (value.Length > ADDRESS_LINE_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice address line 2 field is too long"));
                }
                else
                {
                    invoiceAddressLine2 = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice city
        /// </summary>
        protected string invoiceCity;
        /// <summary>
        /// Gets or sets the invoice city.
        /// </summary>
        /// <value>
        /// The invoice city.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice city field is too long</exception>
        public string InvoiceCity
        {
            get { return (invoiceCity.Trim()); }

            set
            {
                if (value.Length > CITY_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice city field is too long"));
                }
                else
                {
                    invoiceCity = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice state name
        /// </summary>
        protected string invoiceStateName;
        /// <summary>
        /// Gets or sets the name of the invoice state.
        /// </summary>
        /// <value>
        /// The name of the invoice state.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice state name field is too long</exception>
        public string InvoiceStateName
        {
            get { return (invoiceStateName.Trim()); }

            set
            {
                if (value.Length > STATE_NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice state name field is too long"));
                }
                else
                {
                    invoiceStateName = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice country name
        /// </summary>
        protected string invoiceCountryName;
        /// <summary>
        /// Gets or sets the name of the invoice country.
        /// </summary>
        /// <value>
        /// The name of the invoice country.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice country name field is too long</exception>
        public string InvoiceCountryName
        {
            get { return (invoiceCountryName.Trim()); }

            set
            {
                if (value.Length > COUNTRY_NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice country name field is too long"));
                }
                else
                {
                    invoiceCountryName = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// The invoice zip
        /// </summary>
        protected string invoiceZip;
        /// <summary>
        /// Gets or sets the invoice zip.
        /// </summary>
        /// <value>
        /// The invoice zip.
        /// </value>
        /// <exception cref="InvalidLengthException">The invoice zip field is too long</exception>
        public string InvoiceZip
        {
            get { return (invoiceZip.Trim()); }

            set
            {
                if (value.Length > ZIP_LENGTH)
                {
                    throw (new InvalidLengthException("The invoice zip field is too long"));
                }
                else
                {
                    invoiceZip = value.Trim();
                }//end of if-else
            }//end of set
        }//end of property

        /// <summary>
        /// Gets or sets the sub total.
        /// </summary>
        /// <value>
        /// The sub total.
        /// </value>
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public decimal Total { get; set; }
        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Contructor
        /// </summary>
        public OrderInvoice(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of constructor

        /// <summary>
        /// Constructor used to preload the data into the object
        /// </summary>
        /// <param name="id">
        /// The id for the object to be loaded
        /// </param>
        /// <param name="repository"></param>
        protected OrderInvoice(int id, IRepository repository) : this(repository)
        {
            IOrderInvoice dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
            if (!isNew)
            {

                // ReSharper disable once PossibleInvalidOperationException
                this.employee = Employee.GetEmployeeById((int)dbObj.EmployeeObjid, repository);
                this.customer = Customer.GetCustomerById(dbObj.CustomerObjid, repository);
            }
            
        }//end of constructor

        #endregion

        #region Methods

        #region Public Instance Methods

        #region OrderInvoice Manipulation

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
            Repository.DeleteOrderInvoice(Id);
        }

        /// <summary>
        /// Copies the invoice address from shipping address.
        /// </summary>
        public void CopyInvoiceAddressFromShippingAddress()
        {
            this.InvoiceAddressLine1 = this.ShippingAddressLine1;
            this.InvoiceAddressLine2 = this.ShippingAddressLine2;
            this.InvoiceCity = this.ShippingCity;
            this.InvoiceCountryName = this.ShippingCountryName;
            this.InvoiceStateName = this.ShippingStateName;
            this.InvoiceZip = this.ShippingZip;
        }

        /// <summary>
        /// Copies the shipping address from invoice address.
        /// </summary>
        public void CopyShippingAddressFromInvoiceAddress()
        {
            this.ShippingAddressLine1 = this.InvoiceAddressLine1;
            this.ShippingAddressLine2 = this.InvoiceAddressLine2;
            this.ShippingCity = this.InvoiceCity;
            this.ShippingCountryName = this.InvoiceCountryName;
            this.ShippingStateName = this.InvoiceStateName;
            this.ShippingZip = this.InvoiceZip;
        }

        #endregion

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Used to get a order/invoice based on the id 
        /// </summary>
        /// <param name="id">
        /// a peice of data that Uniquely identifies the data record in the db
        /// </param>
        /// <param name="repository"></param>
        /// <returns>
        /// A new order/invoice object filled with data based on the id passed in
        /// </returns>
        public static OrderInvoice GetById(int id, IRepository repository)
        {
            OrderInvoice returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new OrderInvoice(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Factoy method - Gets objects in a list
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static List<OrderInvoice> GetAll(IRepository repository)
        {
            IEnumerable<IOrderInvoice> tempList = null;
            List<OrderInvoice> returnValue = new List<OrderInvoice>();
            OrderInvoice temp = null;
            tempList = repository.GetOrderInvoices();
            foreach (IOrderInvoice tempItem in tempList)
            {
                temp = new OrderInvoice(repository);
                temp.CopyPropertiesFromDbObj(tempItem);
                temp.customer = Customer.GetCustomerById(tempItem.CustomerObjid, repository);
                if (tempItem.EmployeeObjid.HasValue)
                {
                    temp.employee = Employee.GetEmployeeById((int)tempItem.EmployeeObjid, repository);
                }
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
            customer = null;
            employee = null;
            OrderInvoiceNumber = long.MinValue;
            shippingAddressLine1 = string.Empty;
            shippingAddressLine2 = string.Empty;
            shippingCity = string.Empty;
            shippingStateName = string.Empty;
            shippingCountryName = string.Empty;
            shippingZip = string.Empty;
            invoiceAddressLine1 = string.Empty;
            invoiceAddressLine2 = string.Empty;
            invoiceCity = string.Empty;
            invoiceStateName = string.Empty;
            invoiceCountryName = string.Empty;
            invoiceZip = string.Empty;
            SubTotal = decimal.Zero;
            TaxRate = decimal.Zero;
            TaxAmount = decimal.Zero;
            Total = decimal.Zero;
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
            if (customer.IsEmpty())
            {
                throw (new RequiredFieldException("Customer is Mandatory"));
            }//end of if
            if (OrderInvoiceNumber.IsEmpty())
            {
                throw (new RequiredFieldException("Order number is Mandatory"));
            }//end of if

            if (shippingAddressLine1.IsEmpty())
            {
                throw (new RequiredFieldException("shipping address line 1 is Mandatory"));
            }//end of if

            if (shippingAddressLine2.IsEmpty())
            {
                throw (new RequiredFieldException("shipping address line 2 is Mandatory"));
            }//end of if

            if (shippingCity.IsEmpty())
            {
                throw (new RequiredFieldException("shipping city is Mandatory"));
            }//end of if

            if (shippingStateName.IsEmpty())
            {
                throw (new RequiredFieldException("shipping state name is Mandatory"));
            }//end of if

            if (shippingCountryName.IsEmpty())
            {
                throw (new RequiredFieldException("shipping country name is Mandatory"));
            }//end of if

            if (shippingZip.IsEmpty())
            {
                throw (new RequiredFieldException("shipping zip is Mandatory"));
            }//end of if

            if (invoiceAddressLine1.IsEmpty())
            {
                throw (new RequiredFieldException("invoice address line 1 is Mandatory"));
            }//end of if

            if (invoiceAddressLine2.IsEmpty())
            {
                throw (new RequiredFieldException("invoice address line 2 is Mandatory"));
            }//end of if

            if (invoiceCity.IsEmpty())
            {
                throw (new RequiredFieldException("invoice city is Mandatory"));
            }//end of if

            if (invoiceStateName.IsEmpty())
            {
                throw (new RequiredFieldException("invoice state name is Mandatory"));
            }//end of if

            if (invoiceCountryName.IsEmpty())
            {
                throw (new RequiredFieldException("invoice country name is Mandatory"));
            }//end of if

            if (invoiceZip.IsEmpty())
            {
                throw (new RequiredFieldException("invoice zip is Mandatory"));
            }//end of if

            if (SubTotal.IsEmpty())
            {
                throw (new RequiredFieldException("subtotal is Mandatory"));
            }//end of if

            if (TaxRate.IsEmpty())
            {
                throw (new RequiredFieldException("tax rate is Mandatory"));
            }//end of if

            if (TaxAmount.IsEmpty())
            {
                throw (new RequiredFieldException("tax amount is Mandatory"));
            }//end of if

            if (Total.IsEmpty())
            {
                throw (new RequiredFieldException("total is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IOrderInvoice dbObj = Repository.CreateOrderInvoice();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertOrderInvoice(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IOrderInvoice dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateOrderInvoice(dbObj);
        }

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected IOrderInvoice GetDbRecord(int id)
        {
            IOrderInvoice returnValue = Repository.GetOrderInvoice(id);
            return returnValue;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IOrderInvoice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.CustomerObjid = this.CustomerId;
                dbObj.EmployeeObjid = this.EmployeeId;
                dbObj.OrderNumber = this.OrderInvoiceNumber;
                dbObj.ShippingAddressLine1 = this.shippingAddressLine1;
                dbObj.ShippingAddressLine2 = this.shippingAddressLine2;
                dbObj.ShippingCity = this.shippingCity;
                dbObj.ShippingStateName = this.shippingStateName;
                dbObj.ShippingCountryName = this.shippingCountryName;
                dbObj.Shippingzip = this.shippingZip;
                dbObj.InvoiceAddressLine1 = this.invoiceAddressLine1;
                dbObj.InvoiceAddressLine2 = this.invoiceAddressLine2;
                dbObj.InvoiceCity = this.invoiceCity;
                dbObj.InvoiceStateName = this.invoiceStateName;
                dbObj.InvoiceCountryName = this.invoiceCountryName;
                dbObj.Invoicezip = this.invoiceZip;
                dbObj.SubTotal = this.SubTotal;
                dbObj.TaxRate = this.TaxRate;
                dbObj.TaxAmount = this.TaxAmount;
                dbObj.Total = this.Total;
                dbObj.Note = this.Note;

            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IOrderInvoice dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.customer = Customer.GetCustomerById(dbObj.CustomerObjid, this.Repository);
                if (dbObj.EmployeeObjid.HasValue)
                {
                    this.employee = Employee.GetEmployeeById(dbObj.EmployeeObjid.Value, this.Repository);
                }
                this.OrderInvoiceNumber = dbObj.OrderNumber;
                this.shippingAddressLine1 = dbObj.ShippingAddressLine1;
                this.shippingAddressLine2 = dbObj.ShippingAddressLine2;
                this.shippingCity = dbObj.ShippingCity;
                this.shippingStateName = dbObj.ShippingStateName;
                this.shippingCountryName = dbObj.ShippingCountryName;
                this.shippingZip = dbObj.Shippingzip;
                this.invoiceAddressLine1 = dbObj.InvoiceAddressLine1;
                this.invoiceAddressLine2 = dbObj.InvoiceAddressLine2;
                this.invoiceCity = dbObj.InvoiceCity;
                this.invoiceStateName = dbObj.InvoiceStateName;
                this.invoiceCountryName = dbObj.InvoiceCountryName;
                this.invoiceZip = dbObj.Invoicezip;
                this.SubTotal = dbObj.SubTotal;
                this.TaxRate = dbObj.TaxRate;
                this.TaxAmount = dbObj.TaxAmount;
                this.Total = dbObj.Total;
                this.Note = dbObj.Note;
            }
        }

        #endregion

        #endregion

    }//end of class
}
