using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces
{

	public interface IUnitOfWork
	{
		IGenericRepository<IApplicationConfiguration> ApplicationConfiguration { get; }
		IGenericRepository<IAttributes> Attributes { get; }
		IGenericRepository<IContacts> Contacts { get; }
		IGenericRepository<ICountry> Country { get; }
		IGenericRepository<ICustomers> Customers { get; }
		IGenericRepository<ICustomItemAttributes> CustomItemAttributes { get; }
		IGenericRepository<ICustomItemOptionAttributes> CustomItemOptionAttributes { get; }
		IGenericRepository<ICustomItemOptions> CustomItemOptions { get; }
		IGenericRepository<IEMailAddresses> EMailAddresses { get; }
		IGenericRepository<IEmployees> Employees { get; }
		IGenericRepository<IMtmOptionAttributes> MtmOptionAttributes { get; }
		IGenericRepository<IMtmOptions> MtmOptions { get; }
		IGenericRepository<IMtmPhone> MtmPhone { get; }
		IGenericRepository<IMtmProductAttributes> MtmProductAttributes { get; }
		IGenericRepository<IMtmSnailMail> MtmSnailMail { get; }
		IGenericRepository<IMtmUserRoles> MtmUserRoles { get; }
		IGenericRepository<IOptionPrice> OptionPrice { get; }
		IGenericRepository<IOptionsAttributeValues> OptionsAttributeValues { get; }
		IGenericRepository<IOrderInvoice> OrderInvoice { get; }
		IGenericRepository<IOrderItem> OrderItem { get; }
		IGenericRepository<IPhoneNumbers> PhoneNumbers { get; }
		IGenericRepository<IPhoneNumberType> PhoneNumberType { get; }
		IGenericRepository<IPredefinedOptionDetail> PredefinedOptionDetail { get; }
		IGenericRepository<IPredefinedOptions> PredefinedOptions { get; }
		IGenericRepository<IPredefinedProductDetail> PredefinedProductDetail { get; }
		IGenericRepository<IPredefinedProducts> PredefinedProducts { get; }
		IGenericRepository<IProductAttributeValues> ProductAttributeValues { get; }
		IGenericRepository<IProductOptions> ProductOptions { get; }
		IGenericRepository<IProductPrice> ProductPrice { get; }
		IGenericRepository<IProducts> Products { get; }
		IGenericRepository<IRoles> Roles { get; }
		IGenericRepository<ISnailMailAddresses> SnailMailAddresses { get; }
		IGenericRepository<ISnailMailType> SnailMailType { get; }
		IGenericRepository<IStates> States { get; }
		IGenericRepository<ISystemKeys> SystemKeys { get; }
		IGenericRepository<IUploadedFiles> UploadedFiles { get; }
		IGenericRepository<IUsers> Users { get; }
		void SaveChanges();
	}
}