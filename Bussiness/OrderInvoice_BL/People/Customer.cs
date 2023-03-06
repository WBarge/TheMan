// ***********************************************************************
// Assembly         : OrderInvoice_BL
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="Customer.cs" company="OrderInvoice_BL">
//     Copyright (c) N/A. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Exceptions;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using Utilites;

namespace OrderInvoice_BL.People
{
    /// <summary>
    /// Class Customer.
    /// Implements the <see cref="OrderInvoice_BL.People.User" />
    /// </summary>
    /// <seealso cref="OrderInvoice_BL.People.User" />
    public class Customer : User
    {

        #region Constants
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get => Id;
            internal set => Id = value;
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [shipping is same as billing].
        /// </summary>
        /// <value><c>true</c> if [shipping is same as billing]; otherwise, <c>false</c>.</value>
        public bool ShippingIsSameAsBilling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><see langword="true" /> if this instance is new; otherwise, <see langword="false" />.</value>
        internal bool IsNewCustomer { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Customer(IRepository repository) : base(repository)
        {
            CommonInit();
            SetNewFlags(true);
        }//end of constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        protected Customer(int id, IRepository repository) : this(repository)
        {
            BuildObjectFromDb(id);
        }

        #endregion Constructors

        #region Methods

        #region Public Instance Methods

        /// <summary>
        /// Permanently remove the object from the system.
        /// </summary>
        /// <exception cref="Exceptions.DataException">You can not delete a new object</exception>
        public override void PermanentlyRemoveFromSystem()
        {
            if (isNew)
            {
                throw (new DataException("You can not delete a new object"));
            }
            Repository.DeleteCustomer(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public override void Save()
        {
            this.Save(true);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="persist">if set to <c>true</c> [persist].</param>
        internal new void Save(bool persist)
        {
            base.Save(false);
            Validate();
            if (IsNewCustomer)
            {
                Insert();
            }
            else
            {
                Update();
            }
            SetNewFlags(false);
            if (persist)
            {
                this.Repository.SaveChanges();
            }
        }

        #region Address Methods

        /// <summary>
        /// Gets the shipping address.
        /// This will return the billing address
        /// if the customer is marked as the
        /// shipping address is the same as
        /// the billing address
        /// </summary>
        /// <returns>SnailMailAddress.</returns>
        public SnailMailAddress GetShippingAddress()
        {
            SnailMailAddress returnValue = null;
            if (ShippingIsSameAsBilling)
            {
                returnValue = GetBillingAddress();
            }
            else
            {
                returnValue = GetAddressByType(MailType.Shipping);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the billing address.
        /// </summary>
        /// <returns>SnailMailAddress.</returns>
        public SnailMailAddress GetBillingAddress()
        {
            return GetAddressByType(MailType.Billing);
        }


        #endregion Address Methods

        #endregion Public Instance Methods

        #region Internal Instance Methods

        #endregion Internal Instance Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Customer.</returns>
        public static Customer GetCustomerById(int id, IRepository repository)
        {
            Customer returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Customer(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }
            return returnValue;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="includedInActive">if set to <see langword="true" /> [included in active].</param>
        /// <param name="includedDeleted">if set to <see langword="true" /> [included deleted].</param>
        /// <returns>List&lt;Customer&gt;.</returns>
        public static List<Customer> GetAllCustomers(IRepository repository, bool includedInActive = false, bool includedDeleted = false)
        {
            List<Customer> returnValue = new List<Customer>();
            foreach (ICustomers dbCustomerObj in repository.GetCustomers())
            {
                Customer tempObj = new Customer(repository);
                IUsers dbUserObj = tempObj.GetUserDbRecord(dbCustomerObj.Objid);

                if (!includedInActive && !dbUserObj.Active) continue;

                IContacts dbContactObj = tempObj.GetContactDbRecord(dbUserObj.Objid);

                if (!includedDeleted && dbContactObj.Deleted) continue;

                CopyProperties(dbCustomerObj, dbUserObj, dbContactObj, tempObj);
                tempObj.SetNewFlags(false);
                returnValue.Add(tempObj);
            }
            return returnValue;
        }

        #endregion Public Static Methods

        #region Protected Methods

        /// <summary>
        /// init all local vars to default values - should be called by all constructors
        /// </summary>
        protected override void CommonInit()
        {
            base.CommonInit();
            Number = 0;
            SetNewFlags(true);
        }//end of CommonInit

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            ICustomers dbObj = Repository.CreateCustomer();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertCustomer(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            ICustomers dbObj = GetCustomerDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateCustomer(dbObj);
        }

        #endregion Protected Methods

        #region Private Instance Methods

        /// <summary>
        /// Builds the object from database.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <exception cref="Exceptions.ZeroResultsException">There is not a customer for the given Id</exception>
        private void BuildObjectFromDb(int employeeId)
        {
            ICustomers customer = GetCustomerDbRecord(employeeId);
            if (customer.IsEmpty())
            {
                throw new ZeroResultsException("There is not a customer for the given Id");
            }
            IUsers user = GetUserDbRecord(employeeId);
            IContacts contact = GetContactDbRecord(employeeId);
            CopyProperties(customer, user, contact, this);
            SetNewFlags(false);
        }

        /// <summary>
        /// Gets the customer database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomers.</returns>
        private ICustomers GetCustomerDbRecord(int id)
        {
            return Repository.GetCustomer(id);
        }

        /// <summary>
        /// Gets the user database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IUsers.</returns>
        private IUsers GetUserDbRecord(int id)
        {
            return Repository.GetUser(id);
        }

        /// <summary>
        /// Gets the contact database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IContacts.</returns>
        private IContacts GetContactDbRecord(int id)
        {
            return Repository.GetContact(id);
        }

        /// <summary>
        /// Sets the new flags.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        private void SetNewFlags(bool flag)
        {
            IsNew = flag;
            IsNewCustomer = flag;
            IsNewUser = flag;
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(ICustomers dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
                dbObj.Number = Number;
                dbObj.ShippingIsSameAsBilling = ShippingIsSameAsBilling;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(ICustomers dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    this.Id = dbObj.Objid;
                }
                this.Number = dbObj.Number;
                this.ShippingIsSameAsBilling = dbObj.ShippingIsSameAsBilling;
            }
        }

        /// <summary>
        /// Gets address for the given mail type
        /// </summary>
        /// <param name="typeToFind">The type of address to find.</param>
        /// <returns>SnailMailAddress.</returns>
        private SnailMailAddress GetAddressByType(MailType typeToFind)
        {
            SnailMailAddress returnValue = null;
            IEnumerable<SnailMailAddress> addresses = GetAllAddresses();
            foreach (SnailMailAddress address in addresses)
            {
                if (address.Type.AddressType == typeToFind)
                {
                    returnValue = address;
                    break;
                }
            }
            return returnValue;
        }

        #endregion Private Instance Methods

        #region Private Static Methods

        /// <summary>
        /// Copies the properties.
        /// </summary>
        /// <param name="dbCustomer">The database customer.</param>
        /// <param name="dbUser">The database user.</param>
        /// <param name="dbContact">The database contact.</param>
        /// <param name="customer">The customer.</param>
        private static void CopyProperties(ICustomers dbCustomer, IUsers dbUser, IContacts dbContact, Customer customer)
        {
            customer.CopyPropertiesFromDbObj(dbCustomer);
            // ReSharper disable once RedundantCast
            ((User)customer).CopyPropertiesFromDbObj(dbUser);
            // ReSharper disable once RedundantCast
            ((Contact)customer).CopyPropertiesFromDbObj(dbContact);
        }

        #endregion Private Static Methods

        #endregion Methods

    }
}
