using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;


namespace OrderInvoice_BL.Application
{
    public class StoredFiles : BussinessObject
    {
        #region Constants

        public const int MaxFileNameLength = 255;


        #endregion Constants

        #region Local Vars

        #endregion Local Vars

        #region Properties
        private string _fileName;
        public string FileName
        {
            get { return (_fileName.Trim()); }

            set
            {
                if (value.Length > MaxFileNameLength)
                {
                    throw (new InvalidLengthException("The file name field is too long"));
                }
                else
                {
                    _fileName = value.Trim();
                }//end of if-else
            }//end of set

        }

        public byte[] FileContents { get; set; }

        public FileLocationType LocationType { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public StoredFiles(IRepository repository) : base(repository)
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
        protected StoredFiles(int id, IRepository repository)
            : this(repository)
        {
            IUploadedFiles dbObj = GetDbRecord(id);
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
            Repository.DeleteUploadedFiles(Id);
            Repository.SaveChanges();
        }

        /// <summary>
        /// factory method to get an instance of this object
        /// by the primary identity
        /// </summary>
        /// <param name="id">the identity of the record to get</param>
        /// <returns></returns>
        public static StoredFiles GetById(int id, IRepository repository)
        {
            StoredFiles returnValue = null;
            if (id.IsNotEmpty())
            {
                returnValue = new StoredFiles(id, repository);
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
        public static List<StoredFiles> GetAll(IRepository repository)
        {
            IEnumerable<IUploadedFiles> tempList = null;
            List<StoredFiles> returnValue = new List<StoredFiles>();
            tempList = repository.GetUploadedFiles();
            foreach (IUploadedFiles tempObj in tempList)
            {
                var temp = new StoredFiles(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the footer files.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>List&lt;StoredFiles&gt;.</returns>
        public static List<StoredFiles> GetFooterFiles(IRepository repository)
        {
            List<StoredFiles> returnValue = new List<StoredFiles>();
            IEnumerable<IUploadedFiles> tempList = null;
            tempList = repository.GetUploadedFiles().Where(f => f.LocationType == FileLocationType.Footer.ToString());
            foreach (IUploadedFiles tempObj in tempList)
            {
                var temp = new StoredFiles(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the banner files.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>List&lt;StoredFiles&gt;.</returns>
        public static List<StoredFiles> GetBannerFiles(IRepository repository)
        {
            List<StoredFiles> returnValue = new List<StoredFiles>();
            IEnumerable<IUploadedFiles> tempList = null;
            tempList = repository.GetUploadedFiles().Where(f => f.LocationType == FileLocationType.Banner.ToString());
            foreach (IUploadedFiles tempObj in tempList)
            {
                var temp = new StoredFiles(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
            }
            return returnValue;
        }

        /// <summary>
        /// Gets the background files.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>List&lt;StoredFiles&gt;.</returns>
        public static List<StoredFiles> GetBackgroundFiles(IRepository repository)
        {
            List<StoredFiles> returnValue = new List<StoredFiles>();
            IEnumerable<IUploadedFiles> tempList = null;
            tempList = repository.GetUploadedFiles().Where(f => f.LocationType == FileLocationType.Background.ToString());
            foreach (IUploadedFiles tempObj in tempList)
            {
                var temp = new StoredFiles(repository);
                temp.CopyPropertiesFromDbObj(tempObj);
                temp.isNew = false;
                returnValue.Add(temp);
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
        protected override void CommonInit()
        {
            base.CommonInit();
            _fileName = string.Empty;
            FileContents = null;
        }

        /// <summary>
        /// data validation-
        /// Insure the data in the local properties
        /// is set correctly
        /// will throw if validation fails
        /// </summary>
        override protected void Validate()
        {
            if (FileName.IsEmpty())
            {
                throw (new RequiredFieldException("File Name is Mandatory"));
            }
            if (FileContents.IsEmpty())
            {
                throw (new RequiredFieldException("File Contents is Mandatory"));
            }
            if (isNew)//this is a create new record only case
            {
                //this assumes that all files will be stored in the same place when pulled back out of the database
                //thus files cannot have the same name reguardless of the where in the system the file is being used
                IUploadedFiles tempList = Repository.GetUploadedFiles().FirstOrDefault(s => s.FileName == this.FileName);
                if (tempList.IsNotEmpty())
                {
                    throw (new DataException(string.Format("There is already a file with the name of {0} in the system", this._fileName)));
                }
            }
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected override void Insert()
        {
            IUploadedFiles dbObj = Repository.CreateUploadedFiles();
            this.CopyPropertiesToDbObj(dbObj);
            Repository.InsertUploadedFiles(dbObj);
            this.Id = dbObj.Objid;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected override void Update()
        {
            IUploadedFiles dbObj = GetDbRecord(Id);
            this.CopyPropertiesToDbObj(dbObj);
            Repository.UpdateUploadedFiles(dbObj);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Gets the database record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private IUploadedFiles GetDbRecord(int id)
        {
            return Repository.GetUploadedFiles(id);
        }

        /// <summary>
        /// Copies the properties to database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesToDbObj(IUploadedFiles dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                if (this.Id.IsNotEmpty())
                {
                    dbObj.Objid = this.Id;
                }
                dbObj.FileName = this.FileName;
                dbObj.FileContents = this.FileContents;
                dbObj.LocationType = this.LocationType.ToString();
            }
        }

        /// <summary>
        /// Copies the properties from database object.
        /// </summary>
        /// <param name="dbObj">The database object.</param>
        internal void CopyPropertiesFromDbObj(IUploadedFiles dbObj)
        {
            if (dbObj.IsNotEmpty())
            {
                this.Id = dbObj.Objid;
                this._fileName = dbObj.FileName;
                this.FileContents = dbObj.FileContents;
                this.LocationType = (FileLocationType)dbObj.LocationType.ToEnum(FileLocationType.None);
            }
        }
        #endregion

        #endregion Methods


    }
}
