// ***********************************************************************
// Assembly         : OrderInvoice_BL
// Author           : Bill Barge
// Created          : 02-25-2017
//
// Last Modified By : Bill Barge
// Last Modified On : 02-25-2017
// ***********************************************************************
// <copyright file="Role.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Application
{
    /// <summary>
    /// Class Role.
    /// Use in application security
    /// It is up to the developer to ensure there is only one role defined in the system
    /// </summary>
    /// <seealso cref="OrderInvoice_BL.BussinessObject" />
    public class Role: BussinessObject
    {

        #region Constants
        /// <summary>
        /// The maximum name length
        /// </summary>
        public const int MaxNameLength = 255;
        #endregion

        #region Local Vars

        #endregion

        #region Properties

        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <exception cref="InvalidLengthException">The name field is too long</exception>
        public string Name
        {
            get { return (_name.Trim()); }

            set
            {
                if (value.Length > MaxNameLength)
                {
                    throw (new InvalidLengthException("The name field is too long"));
                }
                else
                {
                    _name = value.Trim();
                }//end of if-else
            }//end of set
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="repository">The repository.</param>
        internal Role(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        protected Role(int id, IRepository repository) : this(repository)
        {
            IRoles dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }//end of constructor

        #endregion

        #region Methods

        #region Public Methods

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
            Repository.DeleteRole(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// Gets the Role by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Role.</returns>
        public static Role GetById(int id, IRepository repository)
        {
            Role returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Role(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }//end of  if
            return (returnValue);
        }//end of method

        /// <summary>
        /// Gets all Roles.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>List&lt;Role&gt;.</returns>
        public static List<Role> GetAll(IRepository repository)
        {
            IEnumerable<IRoles> tempList = null;
            List<Role> returnValue = new List<Role>();
            tempList = repository.GetRoles();
            foreach (IRoles tempObj in tempList)
            {
                var temp = new Role(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository">The repository.</param>
        /// <returns>Role.</returns>
        public static Role Create(string name, IRepository repository)
        {
            Role returnValue = new Role(repository);
            returnValue.Name = name;
            returnValue.Save();
            return returnValue;
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
            Name = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        /// <exception cref="RequiredFieldException">Name is Mandatory</exception>
        override protected void Validate()
        {
            if (Name.IsEmpty())
            {
                throw (new RequiredFieldException("Name is Mandatory"));
            }//end of if
        }//end of method

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IRoles dbObj = Repository.CreateRole();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertRole(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IRoles dbObj = GetDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateRole(dbObj);
        }
        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IRoles.</returns>
        private IRoles GetDbRecord(int id)
        {
            return Repository.GetRole(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IRoles dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.RoleName = this.Name;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IRoles dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Name = dbObj.RoleName;
            }
        }


        #endregion

        #endregion

    }
}
