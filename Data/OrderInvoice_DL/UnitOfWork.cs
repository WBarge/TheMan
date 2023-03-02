using System.Collections.Generic;
using System.Data;
using System.Linq;
using ST = System.Transactions;
using Dapper.Contrib.Extensions;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcreteRepos;

namespace OrderInvoice_DL
{

	/// <summary>
    /// Represents a repository for access to all DB tables.
    /// NOTE: This class is the central db context used	
	///		  to access all repositories
    /// </summary>
	public class UnitOfWork : IUnitOfWork, IPrimaryKeyRetriever
	{
		private readonly IConnectionFactory _connectionFactory;
        private Queue<QueueItem> _queueForAllRepositories;
		
        public UnitOfWork(IConnectionFactory conFactory)
        {
            _connectionFactory = conFactory;
            _queueForAllRepositories = new Queue<QueueItem>();
        }
		public IGenericRepository<IApplicationConfiguration> ApplicationConfiguration
		{
			get
			{
				ApplicationConfigurationRepo returnValue = new ApplicationConfigurationRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IAttributes> Attributes
		{
			get
			{
				AttributesRepo returnValue = new AttributesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IContacts> Contacts
		{
			get
			{
				ContactsRepo returnValue = new ContactsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ICountry> Country
		{
			get
			{
				CountryRepo returnValue = new CountryRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ICustomers> Customers
		{
			get
			{
				CustomersRepo returnValue = new CustomersRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ICustomItemAttributes> CustomItemAttributes
		{
			get
			{
				CustomItemAttributesRepo returnValue = new CustomItemAttributesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ICustomItemOptionAttributes> CustomItemOptionAttributes
		{
			get
			{
				CustomItemOptionAttributesRepo returnValue = new CustomItemOptionAttributesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ICustomItemOptions> CustomItemOptions
		{
			get
			{
				CustomItemOptionsRepo returnValue = new CustomItemOptionsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IEMailAddresses> EMailAddresses
		{
			get
			{
				EMailAddressesRepo returnValue = new EMailAddressesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IEmployees> Employees
		{
			get
			{
				EmployeesRepo returnValue = new EmployeesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmOptionAttributes> MtmOptionAttributes
		{
			get
			{
				MtmOptionAttributesRepo returnValue = new MtmOptionAttributesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmOptions> MtmOptions
		{
			get
			{
				MtmOptionsRepo returnValue = new MtmOptionsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmPhone> MtmPhone
		{
			get
			{
				MtmPhoneRepo returnValue = new MtmPhoneRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmProductAttributes> MtmProductAttributes
		{
			get
			{
				MtmProductAttributesRepo returnValue = new MtmProductAttributesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmSnailMail> MtmSnailMail
		{
			get
			{
				MtmSnailMailRepo returnValue = new MtmSnailMailRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IMtmUserRoles> MtmUserRoles
		{
			get
			{
				MtmUserRolesRepo returnValue = new MtmUserRolesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IOptionPrice> OptionPrice
		{
			get
			{
				OptionPriceRepo returnValue = new OptionPriceRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IOptionsAttributeValues> OptionsAttributeValues
		{
			get
			{
				OptionsAttributeValuesRepo returnValue = new OptionsAttributeValuesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IOrderInvoice> OrderInvoice
		{
			get
			{
				OrderInvoiceRepo returnValue = new OrderInvoiceRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IOrderItem> OrderItem
		{
			get
			{
				OrderItemRepo returnValue = new OrderItemRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPhoneNumbers> PhoneNumbers
		{
			get
			{
				PhoneNumbersRepo returnValue = new PhoneNumbersRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPhoneNumberType> PhoneNumberType
		{
			get
			{
				PhoneNumberTypeRepo returnValue = new PhoneNumberTypeRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPredefinedOptionDetail> PredefinedOptionDetail
		{
			get
			{
				PredefinedOptionDetailRepo returnValue = new PredefinedOptionDetailRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPredefinedOptions> PredefinedOptions
		{
			get
			{
				PredefinedOptionsRepo returnValue = new PredefinedOptionsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPredefinedProductDetail> PredefinedProductDetail
		{
			get
			{
				PredefinedProductDetailRepo returnValue = new PredefinedProductDetailRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IPredefinedProducts> PredefinedProducts
		{
			get
			{
				PredefinedProductsRepo returnValue = new PredefinedProductsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IProductAttributeValues> ProductAttributeValues
		{
			get
			{
				ProductAttributeValuesRepo returnValue = new ProductAttributeValuesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IProductOptions> ProductOptions
		{
			get
			{
				ProductOptionsRepo returnValue = new ProductOptionsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IProductPrice> ProductPrice
		{
			get
			{
				ProductPriceRepo returnValue = new ProductPriceRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IProducts> Products
		{
			get
			{
				ProductsRepo returnValue = new ProductsRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IRoles> Roles
		{
			get
			{
				RolesRepo returnValue = new RolesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ISnailMailAddresses> SnailMailAddresses
		{
			get
			{
				SnailMailAddressesRepo returnValue = new SnailMailAddressesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<ISnailMailType> SnailMailType
		{
			get
			{
				SnailMailTypeRepo returnValue = new SnailMailTypeRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IStates> States
		{
			get
			{
				StatesRepo returnValue = new StatesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
        public IGenericRepository<ISystemKeys> SystemKeys
        {
            get
            {
                SystemKeysRepo returnValue = new SystemKeysRepo(_connectionFactory, _queueForAllRepositories, this);
                return returnValue;
            }
        }
        public IGenericRepository<IUploadedFiles> UploadedFiles
		{
			get
			{
				UploadedFilesRepo returnValue = new UploadedFilesRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}
		public IGenericRepository<IUsers> Users
		{
			get
			{
				UsersRepo returnValue = new UsersRepo(_connectionFactory, _queueForAllRepositories,this);
				return returnValue;
			}
		}


		public void SaveChanges()
        {
            using (var scope = CreateTransactionScope())
            {
                using (IDbConnection connection = _connectionFactory.GetConnection())
                {
                    while (_queueForAllRepositories.Count > 0)
                    {
                        QueueItem itemOfWork = _queueForAllRepositories.Dequeue();
                        dynamic obj = itemOfWork.ItemToWorkOn;
                        switch (itemOfWork.WorkType)
                        {
                            case TypeOfWork.Insert:
                            SqlMapperExtensions.Insert(connection,obj);
                                break;
                            case TypeOfWork.Update:
                            Dapper.SimpleCRUD.Update(connection,obj);
                                break;
                            case TypeOfWork.Delete:
                            Dapper.SimpleCRUD.Delete(connection,obj);
                                break;
                        }//end of switch
                    }//end of while
                }//end of using

                scope.Complete();
            }
        }

        public int GetNextPrimaryKey(object obj)
        {
            int returnValue = 1;
            lock (this)
            {
                Queue<QueueItem> keyQueue = new Queue<QueueItem>();
                SystemKeysRepo rep = new SystemKeysRepo(_connectionFactory, keyQueue, this);
                string tableName = obj.GetType().Name;
                ISystemKeys keyRec = rep.GetAll().FirstOrDefault(x => x.TableName == tableName);
                if (keyRec == null)
                {
                    keyRec = rep.Create();
                    keyRec.TableName = tableName;
                    keyRec.LatestKey = returnValue;
                    rep.Insert(keyRec);
                }
                else
                {
                    returnValue = keyRec.LatestKey;
                    returnValue++;
                    keyRec.LatestKey = returnValue;
                    rep.Update(keyRec);
                }
                //we have to update the database in case another thread is tring to insert a record
                Queue<QueueItem> tempQueue = _queueForAllRepositories;
                _queueForAllRepositories = keyQueue;
                SaveChanges();
                _queueForAllRepositories = tempQueue;
            }
            return returnValue;
        }

        private ST.TransactionScope CreateTransactionScope()
        {
            var options = new ST.TransactionOptions { IsolationLevel = ST.IsolationLevel.ReadCommitted, Timeout = ST.TransactionManager.MaximumTimeout };

            return new ST.TransactionScope(ST.TransactionScopeOption.Required, options);
        }

	}
}