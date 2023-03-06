using Exceptions;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;

namespace OrderInvoice_BL
{
    public abstract class BussinessObject
    {
        #region Local Vars
        // ReSharper disable once InconsistentNaming
        protected readonly IRepository Repository;
        // ReSharper disable once InconsistentNaming
        protected bool isNew;
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        #endregion Local Vars

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is new; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNew { get { return (isNew); } set { isNew = value; } }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BussinessObject"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BussinessObject(IRepository repository)
        {
            if (repository.IsEmpty())
            {
                throw new InvalidParameterException("The repository is a mandatory parameter for a business object");
            }
            Repository = repository;
        }

        #endregion Constructors

        #region Methods

        #region public

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public virtual void Save()
        {
            Validate();
            if (isNew)
            {
                Insert();
            }
            else
            {
                Update();
            }
            isNew = false;
            Repository.SaveChanges();

        }

        /// <summary>
        /// Permanently remove the object from the system.
        /// </summary>
        public abstract void PermanentlyRemoveFromSystem();

        #endregion public

        #region Internal


        #endregion Internal

        #region protected

        /// <summary>
        /// Commons the initialize.
        /// </summary>
        protected virtual void CommonInit()
        {
            Id = DefaultValues.DefaultInt;
            isNew = false;
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        protected abstract void Insert();

        /// <summary>
        /// Updates this instance.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// Validates this instance.
        /// </summary>
        protected abstract void Validate();

        #endregion protected

        #endregion
    }
}
