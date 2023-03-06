using System.Collections.Generic;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_BL.Application
{
    public class ApplicationConfiguration : BussinessObject
	{
		#region Constants
		#endregion Constants

		#region Local Vars

		#endregion Local Vars

		#region Properties

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public ApplicationConfigurationType Type { get; set; }

		/// <summary>
		/// Gets or sets the configuration.
		/// should be a xml or json string
		/// which will be hydrated into an object
		/// </summary>
		/// <value>
		/// The configuration string.
		/// </value>
		public string Configuration { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationConfiguration(IRepository repository) : base(repository)
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
        /// <param name="repository"></param>
        protected ApplicationConfiguration(int id, IRepository repository)
            : this(repository)
        {
            IApplicationConfiguration dbObj = GetDbRecord(id);
            isNew = dbObj.IsEmpty();
            CopyPropertiesFromDbObj(dbObj);
        }

        #endregion Constructors

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
            Repository.DeleteApplicationConfiguration(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static ApplicationConfiguration GetById(int id, IRepository repository)
        {
            ApplicationConfiguration returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new ApplicationConfiguration(id, repository);
                if (returnValue.isNew)
                {
                    returnValue = null;
                }

            }
            return returnValue;
        }

        /// <summary>
        /// Factory method - Gets objects in a list
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public static List<ApplicationConfiguration> GetAll(IRepository repository)
        {
            IEnumerable<IApplicationConfiguration> tempList = null;
            List<ApplicationConfiguration> returnValue = new List<ApplicationConfiguration>();
            tempList = repository.GetApplicationConfigurations();
            foreach (IApplicationConfiguration tempObj in tempList)
            {
                var temp = new ApplicationConfiguration(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the application configuration by the type.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static ApplicationConfiguration GetByType(IRepository repository, ApplicationConfigurationType type)
        {
            ApplicationConfiguration returnValue = null;
            foreach (ApplicationConfiguration ac in GetAll(repository))
            {
                if (ac.Type == type)
                {
                    returnValue = ac;
                    break;
                }
            }
            return returnValue;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// init local vars
        /// should be common to all constructors
        /// needs to call the base method first
        /// </summary>
        protected sealed override void CommonInit()
        {
            base.CommonInit();
            Type = ApplicationConfigurationType.None;
            Configuration = string.Empty;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        protected override void Validate()
        {
            if (Type.IsEmpty() || Type == ApplicationConfigurationType.None)
            {
                throw (new RequiredFieldException("Type is Mandatory"));
            }
            if (Configuration.IsEmpty())
            {
                throw (new RequiredFieldException("Configuration is Mandatory"));
            }
            if (isNew)
            {//only one type record is allowed
                ApplicationConfiguration ac = ApplicationConfiguration.GetByType(this.Repository, Type);
                if (ac.IsNotEmpty())
                {
                    throw (new DataException("There is already a configuration for the type"));
                }
            }
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IApplicationConfiguration dbObj = Repository.CreateApplicationConfiguration();
            this.CopyPropertiesToDbObj(dbObj);
            Repository.InsertApplicationConfiguration(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IApplicationConfiguration dbObj = GetDbRecord(Id);
            this.CopyPropertiesToDbObj(dbObj);
            Repository.UpdateApplicationConfiguration(dbObj);
        }

		#endregion Protected Methods

		#region Private Methods

		/// <summary>
		/// Gets the database record.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		private IApplicationConfiguration GetDbRecord(int id)
		{
			return Repository.GetApplicationConfiguration(id);
		}

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IApplicationConfiguration dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.Type = this.Type.ToString();
                dbObj.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IApplicationConfiguration dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this.Type = (ApplicationConfigurationType)dbObj.Type.ToEnum(ApplicationConfigurationType.None);
                this.Configuration = dbObj.Configuration;
            }
        }
		#endregion

		#endregion Methods

	}
}
