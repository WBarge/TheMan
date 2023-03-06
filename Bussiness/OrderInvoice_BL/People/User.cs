using System.Collections.Generic;
using System.Linq;
using Encryption;
using Exceptions;
using OrderInvoice_BL.Application;
using OrderInvoice_BL.Contacts;
using OrderInvoice_Interfaces.DB_DTOs;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;

namespace OrderInvoice_BL.People
{
    public class User : Contact
    {

        #region Constants
        public const int USER_NAME_LENGTH = 255;
        public const int PASSWORD_LENGTH = 255;

        public const string NO_FIRST_NAME = "UserCreatedFirstName";
        public const string NO_LAST_NAME = "UserCreatedLastName";
        #endregion Constants

        #region Local Vars
        #endregion Local Vars

        #region Properties

        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        public int ContactId { get { return Id; } internal set { Id = value; } }

        protected string userName;
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        /// <exception cref="InvalidLengthException">The user name field is too long</exception>
        public string UserName
        {
            get { return (userName); }
            set
            {
                if (value.Length > USER_NAME_LENGTH)
                {
                    throw (new InvalidLengthException("The user name field is too long"));
                }
                else
                {
                    userName = value.Trim();
                }
            }
        }

        internal string password;
        /// <summary>
        /// Gets or sets the password.
        /// when setting the password the business object will encrypt the password
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <exception cref="InvalidLengthException">The password field is too long</exception>
        public string Password
        {
            get { return (password); }
            set
            {
                if (value.IsEmpty())
                {
                    throw (new InvalidParameterException("The password field cannot be empty"));
                }
                else if (value.Length > PASSWORD_LENGTH)
                {
                    throw (new InvalidLengthException("The password field is too long"));
                }
                else
                {
                    var crypto = new Crypto();
                    var valueToStore = crypto.EncryptOneWay(value);
                    password = valueToStore;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is active.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if active; otherwise, <see langword="false" />.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is new; otherwise, <see langword="false" />.
        /// </value>
        internal bool IsNewUser { get; set; }

        #endregion Properties

        #region Constructors

        public User(IRepository repository) : base(repository)
        {
            CommonInit();
            isNew = true;
        }//end of constructor

        protected User(int id, IRepository repository) : this(repository)
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
            Repository.DeleteUser(Id);
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
            base.Save(false);
            Validate();
            if (IsNewUser)
            {
                IUsers dbobj = Repository.CreateUser();
                CopyPropertiesToDbObj(dbobj);
                Repository.InsertUser(dbobj);
            }
            else
            {
                IUsers dbobj = GetUserDbRecord(Id);
                CopyPropertiesToDbObj(dbobj);
                Repository.UpdateUser(dbobj);
            }
            IsNewUser = false;
            if (persist)
            {
                Repository.SaveChanges();
            }
        }


        #region Role Manipulation

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <returns>Role[].</returns>
        public Role[] GetRoles()
        {
            List<Role> returnValues = new List<Role>();
            foreach (IRoles role in Repository.GetUserRoles(this.Id))
            {
                Role tempRole = new Role(this.Repository);
                tempRole.CopyPropertiesFromDbObj(role);
                tempRole.IsNew = false;
                returnValues.Add(tempRole);
            }
            return (returnValues.ToArray());
        }//end of method

        /// <summary>
        /// Replaces the current roles with the role.
        /// </summary>
        /// <param name="role">The new role.</param>
        public void SetRoles(Role role)
        {
            List<Role> userRoles = new List<Role>();
            userRoles.Add(role);
            SetRoles(userRoles);
        }

        /// <summary>
        /// Replaces the current roles with the roles.
        /// </summary>
        /// <param name="userRoles">The new user roles.</param>
        public void SetRoles(IEnumerable<Role> userRoles)
        {
            foreach (Role role in GetRoles())
            {
                RemoveRole(role);
            }
            foreach (Role role in userRoles)
            {
                AddRole(role);
            }
            this.Repository.SaveChanges();
        }

        /// <summary>
        /// Clears the current roles.
        /// </summary>
        public void ClearRoles()
        {
            foreach (Role role in GetRoles())
            {
                RemoveRole(role);
            }
            this.Repository.SaveChanges();
        }

        #endregion


        #endregion Public Instance Methods

        #region Internal Instance Methods

        #endregion Internal Instance Methods

        #region Public Static Methods

        /// <summary>
        /// Creates the user with no contact.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>User.</returns>
        public static User CreateUserWithNoContact(IRepository repository, string userName, string password)
        {
            User u = new User(repository);
            u.FirstName = NO_FIRST_NAME;
            u.LastName = NO_LAST_NAME;
            u.UserName = userName;
            u.Password = password;
            u.Save();
            return u;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static User GetUserById(int id, IRepository repository)
        {
            User returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new User(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }
            return returnValue;
        }

        /// <summary>
        /// Gets all as array.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="includedInActive">if set to <see langword="true" /> [included in active].</param>
        /// <param name="includedDeleted">if set to <see langword="true" /> [included deleted].</param>
        /// <returns></returns>
        public static User[] GetAllUsersAsArray(IRepository repository, bool includedInActive = false, bool includedDeleted = false)
        {
            return GetAllUsers(repository, includedInActive, includedDeleted).ToArray();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="includedInActive">if set to <see langword="true" /> [included in active].</param>
        /// <param name="includedDeleted">if set to <see langword="true" /> [included deleted].</param>
        /// <returns></returns>
        public static List<User> GetAllUsers(IRepository repository, bool includedInActive = false, bool includedDeleted = false)
        {
            List<User> returnValue = new List<User>();
            foreach (IUsers dbUserObj in repository.GetUsers())
            {
                if (includedInActive || dbUserObj.Active)
                {
                    IContacts dbContactObj = repository.GetContact(dbUserObj.Objid);
                    if (dbContactObj.IsNotEmpty() && (includedDeleted || dbContactObj.Deleted == false))
                    {
                        User tempObj = new User(repository);
                        CopyProperties(dbUserObj, dbContactObj, tempObj);
                        tempObj.IsNewUser = false;
                        tempObj.isNew = false;
                        returnValue.Add(tempObj);
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the user using login credentials.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///     Will return a user if the credentials are valid
        ///     
        /// </returns>
        public static User GetUserUsingLogin(IRepository repository, string userName, string password)
        {
            User returnValue = null;

            User userInSystem = GetAllUsers(repository).FirstOrDefault(u => u.UserName == userName);
            if (userInSystem.IsNotEmpty())
            {
                User localUser = new User(repository);
                localUser.UserName = userName;
                localUser.Password = password;
                // ReSharper disable once PossibleNullReferenceException
                if (localUser.Password == userInSystem.Password)
                {
                    returnValue = userInSystem;
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
            userName = string.Empty;
            password = string.Empty;
            Active = true;
            IsNewUser = true;
        }//end of CommonInit

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        /// <exception cref="ClassDependencyException">The user has to be associated with a contact</exception>
        /// <exception cref="RequiredFieldException">
        /// The user name is required
        /// or
        /// The password is required
        /// </exception>
        protected override void Validate()
        {
            base.Validate();
            if (UserName.IsEmpty())
            {
                throw (new RequiredFieldException("The user name is required"));
            }
            if (Password.IsEmpty())
            {
                throw (new RequiredFieldException("The password is required"));
            }
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            foreach (User u in GetAllUsers(this.Repository, true, true))
            {
                if (u.UserName == this.UserName)
                {
                    throw (new DataException("There is already a user with the specified name"));
                }
            }

            IUsers dbObj = Repository.CreateUser();
            CopyPropertiesToDbObj(dbObj);
            Repository.InsertUser(dbObj);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IUsers dbobj = GetUserDbRecord(Id);
            CopyPropertiesToDbObj(dbobj);
            Repository.UpdateUser(dbobj);
        }

        #region Protected Role Manipulation

        /// <summary>
        /// Adds the role to the user.
        /// </summary>
        /// <param name="roleToAdd">The role to add.</param>
        /// <exception cref="InvalidParameterException">The passed in parameter to AddRole is null</exception>
        /// <exception cref="RequiredFieldException">The user needs to be saved before any roles can be added to it</exception>
        protected void AddRole(Role roleToAdd)
        {
            if (roleToAdd.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to AddRole is null"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The user needs to be saved before any roles can be added to it"));
            }//end of if
            if (roleToAdd.IsNew)//the phone number is a new phone number and has not been added to the db yet
            {
                roleToAdd.Save();
            }//end of if
            Repository.AddRoleToUser(Id, roleToAdd.Id);
        }//end of method

        /// <summary>
        /// Removes the role from the user.
        /// </summary>
        /// <param name="roleToRemove">The role to remove.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="InvalidParameterException">The passed in parameter to RemoveRole is null</exception>
        /// <exception cref="ClassDependencyException">The role to remove has not been added to the system yet</exception>
        /// <exception cref="RequiredFieldException">The user needs to be saved before any roles can be removed to it</exception>
        protected bool RemoveRole(Role roleToRemove)
        {
            bool returnValue = false;
            if (roleToRemove.IsEmpty())
            {
                throw (new InvalidParameterException("The passed in parameter to RemoveRole is null"));
            }//end of if
            if (roleToRemove.IsNew)
            {
                throw (new ClassDependencyException("The role to remove has not been added to the system yet"));
            }//end of if
            if (isNew)
            {
                throw (new RequiredFieldException("The user needs to be saved before any roles can be removed to it"));
            }//end of if
            returnValue = Repository.RemoveRoleFromUser(Id, roleToRemove.Id);
            return (returnValue);
        }//end of method

        #endregion

        #endregion Protected Methods

        #region Private Instance Methods

        /// <summary>
        /// Builds the object from database.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        private void BuildObjectFromDb(int userId)
        {
            IUsers user = GetUserDbRecord(userId);
            IContacts contact = GetContactDbRecord(userId);
            CopyProperties(user, contact, this);
            IsNewUser = false;
            isNew = false;
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
            return GetDbRecord(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IUsers dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                dbObj.Objid = this.Id;
                dbObj.Username = this.userName;
                dbObj.Password = this.password;
                dbObj.Active = this.Active;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IUsers dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    this.Id = dbObj.Objid;
                }
                this.userName = dbObj.Username;
                this.password = dbObj.Password;
                this.Active = dbObj.Active;
            }
        }

        #endregion Private Instance Methods

        #region Private Static Methods

        /// <summary>
        /// Copies the properties.
        /// </summary>
        /// <param name="dbUser">The database user.</param>
        /// <param name="dbContact">The database contact.</param>
        /// <param name="user">The user.</param>
        private static void CopyProperties(IUsers dbUser, IContacts dbContact, User user)
        {
            // ReSharper disable once RedundantCast
            ((Contact)user).CopyPropertiesFromDbObj(dbContact);
            user.CopyPropertiesFromDbObj(dbUser);
        }

        #endregion Private Static Methods

        #endregion Methods

    }
}
