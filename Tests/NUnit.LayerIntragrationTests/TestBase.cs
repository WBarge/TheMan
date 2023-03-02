// ***********************************************************************
// Assembly         : NUnit.LayerIntragrationTests
// Author           : Bill Barge
// Created          : 11-19-2016
//
// Last Modified By : Bill Barge
// Last Modified On : 11-20-2016
// ***********************************************************************
// <copyright file="TestBase.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using CompositionRoot;
using OrderInvoice_BL.Contacts;
using OrderInvoice_BL.OrderInvoice;
using OrderInvoice_BL.People;
using OrderInvoice_BL.Products;
using OrderInvoice_DL;
using OrderInvoice_DL.Repository;
using OrderInvoice_Interfaces.RepositoryInterfaces;

namespace NUnit.LayerIntragrationTests
{
    /// <summary>
    /// Class TestBase.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// The starting order number
        /// </summary>
        protected const long StartingOrderNumber = 1;
        /// <summary>
        /// The initial password
        /// </summary>
        protected const string InitialPassword = "password";

        /// <summary>
        /// The initial user name
        /// </summary>
        protected const string InitialUserName = "TestUser";

        /// <summary>
        /// The sub total
        /// </summary>
        protected const decimal SubTotal = 100;
        /// <summary>
        /// The tax rate
        /// </summary>
        protected const decimal TaxRate = 0.01M;
        /// <summary>
        /// The tax amount
        /// </summary>
        protected const decimal TaxAmount = SubTotal * TaxRate;
        /// <summary>
        /// The total
        /// </summary>
        protected const decimal Total = SubTotal + TaxAmount;


        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase" /> class.
        /// </summary>
        protected TestBase()
        {
            string connectionString = "data source=THEBEAST;initial catalog=OrderInvoice;persist security info=True;user id=sa;password=buckrogerz;";
            ConnectionFactory cf = new ConnectionFactory(connectionString);
            UnitOfWork uw = new UnitOfWork(cf);
            Repository repo = new Repository(uw);

            GetRepository = repo;
        }

        /// <summary>
        /// Gets the get repository.
        /// </summary>
        /// <value>The get repository.</value>
        protected IRepository GetRepository { get; }

        /// <summary>
        /// Gets the un saved snail mail.
        /// </summary>
        /// <returns>SnailMailAddress.</returns>
        protected SnailMailAddress GetUnSavedSnailMail()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            return sma1;
        }

        /// <summary>
        /// Gets the order invoice.
        /// </summary>
        /// <returns>OrderInvoice.</returns>
        protected OrderInvoice GetOrderInvoice()
        {
            OrderInvoice oi = new OrderInvoice(GetRepository);
            SnailMailAddress sma = GetUnSavedSnailMail();
            oi.OrderInvoiceCustomer = GetTestCustomer();
            oi.OrderInvoiceEmployee = GetTestEmployee();
            oi.OrderInvoiceNumber = StartingOrderNumber;
            oi.ShippingAddressLine1 = oi.InvoiceAddressLine1 = sma.Line1;
            oi.ShippingAddressLine2 = oi.InvoiceAddressLine2 = sma.Line2;
            oi.ShippingCity = oi.InvoiceCity = sma.City;
            oi.ShippingCountryName = oi.InvoiceCountryName = sma.Country.Name.ToString();
            oi.ShippingStateName = oi.InvoiceStateName = sma.State.Name.ToString();
            oi.ShippingZip = oi.InvoiceZip = sma.Zip;
            oi.SubTotal = SubTotal;
            oi.TaxRate = TaxRate;
            oi.TaxAmount = TaxAmount;
            oi.Total = Total;
            oi.Note = "This is a test note.";
            oi.Save();
            return oi;
        }

        /// <summary>
        /// Deletes all order invoices.
        /// </summary>
        protected void DeleteAllOrderInvoices()
        {
            OrderInvoice.GetAll(GetRepository).ForEach(oi => oi.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// Deletes all employees.
        /// </summary>
        protected void DeleteAllEmployees()
        {
            List<Employee> extraRecords = Employee.GetAllEmployees(GetRepository, true, true);
            extraRecords.ForEach(er => {
                User u = User.GetUserById(er.UserId, GetRepository);
                Contact c = Contact.GetById(er.ContactId, GetRepository);
                er.PermanentlyRemoveFromSystem();
                u.PermanentlyRemoveFromSystem();
                c.PermanentlyRemoveFromSystem();
            });
        }

        /// <summary>
        /// Gets the test employee.
        /// </summary>
        /// <returns>Employee.</returns>
        protected Employee GetTestEmployee()
        {
            Employee e = new Employee(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case",
                UserName = "TestEmployee",
                Password = InitialPassword,
                BadgeId = "1234"
            };
            e.Save();
            return e;
        }

        /// <summary>
        /// Deletes all customers.
        /// </summary>
        protected void DeleteAllCustomers()
        {
            List<Customer> extraRecords = Customer.GetAllCustomers(GetRepository, true, true);
            extraRecords.ForEach(er => er.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// Gets the test customer.
        /// </summary>
        /// <returns>Customer.</returns>
        protected Customer GetTestCustomer()
        {
            Customer e = new Customer(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case",
                UserName = "tcase",
                Password = InitialPassword,
                Number = 1234
            };
            e.Save();
            return e;
        }

        /// <summary>
        /// Deletes all users.
        /// </summary>
        protected void DeleteAllUsers()
        {
            List<User> extraRecords = User.GetAllUsers(GetRepository, true, true);
            foreach (User user in extraRecords)
            {
                Contact tempContact = Contact.GetById(user.Id,GetRepository);
                user.PermanentlyRemoveFromSystem();
                tempContact.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Gets the test user.
        /// </summary>
        /// <returns>User.</returns>
        protected User GetTestUser()
        {
            User u = new User(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case",
                UserName = InitialUserName,
                Password = InitialPassword
            };
            u.Save();
            return u;
        }
        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <returns>Product.</returns>
        protected Product CreateProduct()
        {
            Product product1 = new Product(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            product1.Save();
            return product1;
        }
        /// <summary>
        /// Creates the option.
        /// </summary>
        /// <returns>ProductOption.</returns>
        protected ProductOption CreateOption()
        {
            ProductOption po = new ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            po.Save();
            return (po);
        }
        /// <summary>
        /// Creates the predefined product.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>PredefinedProduct.</returns>
        protected PredefinedProduct CreatePredefinedProduct(Product p)
        {
            PredefinedProduct returnValue = new PredefinedProduct(GetRepository, p)
            {
                Price = 9.99M,
                Description = "This is a test predefined product"
            };
            returnValue.Save();
            return returnValue;
        }
        /// <summary>
        /// Creates the predefined option.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="option">The option.</param>
        /// <returns>PredefinedOption.</returns>
        protected PredefinedOption CreatePredefinedOption(PredefinedProduct product, ProductOption option)
        {
            PredefinedOption returnValue = new PredefinedOption(GetRepository, product, option)
            {
                Description = "This is a test predefined option"
            };
            returnValue.Save();
            return returnValue;
        }

        protected PhoneNumberType GetOrCreatePhoneNumberType(PhoneType type)
        {
            var returnValue = PhoneNumberType.GetAll(GetRepository).FirstOrDefault(pt => pt.Type == type);
            if (returnValue == null)
            {
                returnValue = new PhoneNumberType(GetRepository)
                {
                    Type = type
                };
                returnValue.Save();
            }
            return returnValue;
        }

        protected SnailMailType GetOrCreateSnailMailType(MailType type)
        {
            var returnValue = SnailMailType.GetAll(GetRepository).FirstOrDefault(mt => mt.AddressType == type) ??
                              SnailMailType.Create(GetRepository,type);
            return returnValue;
        }

        protected State GetOrCreateState(UsStateName name)
        {
            var returnValue = State.GetAll(GetRepository).FirstOrDefault(mt => mt.Name == name) ?? State.Create(name, GetRepository);
            return returnValue;
        }

        protected Country GetOrCreateCountry(CountryName name)
        {
            var returnValue = Country.GetAll(GetRepository).FirstOrDefault(c => c.Name == name) ?? Country.Create(name, GetRepository);
            return returnValue;
        }
    }
}
