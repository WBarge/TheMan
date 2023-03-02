using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.RepositoryInterfaces;


namespace OrderInvoice_DL.Repository
{
    /// <summary>
    /// This part of the class holds all pieces that are common
    /// e.g. the constructors and local variables like the context object
    /// </summary>
    public partial class Repository : IRepository
    {
        #region Local Vars

        protected IUnitOfWork Context;

        #endregion Local Vars

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Product.Repository"/> class.
        /// </summary>
        /// <param name="connectionStr">The connection string.</param>
        public Repository(IUnitOfWork unitOfWork)
        {
            Context = unitOfWork;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
        #endregion Constructors
    }
}
