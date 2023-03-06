using System.Collections.Generic;
using Exceptions;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.DB_DTOs;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;

namespace OrderInvoice_BL.People
{
    public class Employee : User
    {

        #region Constants
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        public int UserId { get { return Id; } internal set { Id = value; } }


        public string BadgeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is new; otherwise, <see langword="false" />.
        /// </value>
        internal bool IsNewEmployee { get; set; }

        #endregion Properties

        #region Constructors

        public Employee(IRepository repository) : base(repository)
        {
            CommonInit();
            SetNewFlags(true);
        }//end of constructor

        protected Employee(int id, IRepository repository) : this(repository)
        {
            BuildObjectFromDb(id);
        }

        #endregion Constructors

        #region Methods

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
            Repository.DeleteEmployee(Id);
            Repository.SaveChanges();
        }
        public override void Save()
        {
            this.Save(true);
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        internal new void Save(bool persist)
        {
            Validate();
            base.Save(false);
            if (IsNewEmployee)
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

        #endregion Public Instance Methods

        #region Internal Instance Methods

        #endregion Internal Instance Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static Employee GetEmployeeById(int id, IRepository repository)
        {
            Employee returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new Employee(id, repository);
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
        /// <returns></returns>
        public static List<Employee> GetAllEmployees(IRepository repository, bool includedInActive = false, bool includedDeleted = false)
        {
            List<Employee> returnValue = new List<Employee>();
            foreach (IEmployees dbEmployeeObj in repository.GetEmployees())
            {
                Employee tempObj = new Employee(repository);
                IUsers dbUserObj = tempObj.GetUserDbRecord(dbEmployeeObj.Objid);
                if (includedInActive || dbUserObj.Active)
                {
                    IContacts dbContactObj = tempObj.GetContactDbRecord(dbUserObj.Objid);
                    if (includedDeleted || dbContactObj.Deleted == false)
                    {
                        CopyProperties(dbEmployeeObj, dbUserObj, dbContactObj, tempObj);
                        tempObj.SetNewFlags(false);
                        returnValue.Add(tempObj);
                    }
                }
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
            BadgeId = string.Empty;
            SetNewFlags(true);
        }//end of CommonInit

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IEmployees dbObj = Repository.CreateEmployee();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertEmployee(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IEmployees dbObj = GetEmployeeDbRecord(Id);
            CopyPropertiesToDbObj(dbObj);
            Repository.UpdateEmployee(dbObj);
        }

        #endregion Protected Methods

        #region Private Instance Methods

        /// <summary>
        /// Builds the object from database.
        /// </summary>
        private void BuildObjectFromDb(int employeeId)
        {
            IEmployees employee = GetEmployeeDbRecord(employeeId);
            IUsers user = GetUserDbRecord(employeeId);
            IContacts contact = GetContactDbRecord(employeeId);
            CopyProperties(employee, user, contact, this);
            SetNewFlags(false);
        }

        private IEmployees GetEmployeeDbRecord(int id)
        {
            return Repository.GetEmployee(id);
        }

        /// <summary>
        /// Gets the user database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IUsers GetUserDbRecord(int id)
        {
            return Repository.GetUser(id);
        }

        /// <summary>
        /// Gets the contact database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IContacts GetContactDbRecord(int id)
        {
            return Repository.GetContact(id);
        }

        private void SetNewFlags(bool flag)
        {
            IsNew = flag;
            IsNewEmployee = flag;
            IsNewUser = flag;
        }
        #endregion Private Instance Methods

        #region Private Static Methods

        /// <summary>
        /// Copies the properties.
        /// </summary>
        /// <param name="dbEmployee">The database employee.</param>
        /// <param name="dbUser">The database user.</param>
        /// <param name="dbContact">The database contact.</param>
        /// <param name="employee">The employee.</param>
        private static void CopyProperties(IEmployees dbEmployee, IUsers dbUser, IContacts dbContact, Employee employee)
        {
            employee.CopyPropertiesFromDbObj(dbEmployee);
            // ReSharper disable once RedundantCast
            ((User)employee).CopyPropertiesFromDbObj(dbUser);
            // ReSharper disable once RedundantCast
            ((Contact)employee).CopyPropertiesFromDbObj(dbContact);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IEmployees dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
                dbObj.BadgeId = BadgeId;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IEmployees dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    this.Id = dbObj.Objid;
                }
                this.BadgeId = dbObj.BadgeId;
            }
        }
        #endregion Private Static Methods

        #endregion Methods

    }
}
