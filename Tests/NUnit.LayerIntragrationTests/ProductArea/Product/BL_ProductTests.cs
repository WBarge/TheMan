using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_Interfaces.DB_DTOs;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.Product
{
    [TestFixture]
    class BlProductTests : TestBase
    {
        BL.Product _product1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = new BL.Product(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            _product1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            foreach (IProductPrice op in GetRepository.GetProductPrices())
            {
                GetRepository.DeleteProductPrice(op.Objid);
            }

            GetRepository.GetProductAttriValues().ToList().ForEach(pav => GetRepository.DeleteProductAttriValue(pav.Objid));

            var results = BL.Product.GetAll(true,GetRepository);
            foreach (BL.Product pnt in results)
            {
                pnt.GetOptions(true).ToList().ForEach(po => pnt.RemoveOption(po));
                pnt.GetAttributes(true).ToList().ForEach(attri => pnt.RemoveAttribute(attri));
            }

            BL.ProductOption.GetAll(true, GetRepository).ForEach(o => o.PermanentlyRemoveFromSystem());

            BL.Attribute.GetAll(true, GetRepository).ForEach(a => a.PermanentlyRemoveFromSystem());

            results = BL.Product.GetAll(true, GetRepository);
            foreach (BL.Product pnt in results)
            {
                pnt.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _product1.Delete();

            BL.Product pnt = BL.Product.GetById(_product1.Id, GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            BL.Product pnt21 = null;
            try
            {
                pnt21 = new BL.Product(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<BL.Product> results = BL.Product.GetAll(GetRepository);
                Assert.IsTrue(results.Count == 1);
            }
            catch
            {
                // ignored
            }
            finally
            {
                pnt21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            BL.Product pnt21 = null;
            try
            {
                pnt21 = new BL.Product(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<BL.Product> results = BL.Product.GetAll(true, GetRepository);
                Assert.Greater(results.Count, 1);
            }
            catch
            {
                // ignored
            }
            finally
            {
                pnt21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            BL.Product testObj = new BL.Product(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            BL.Product testObj = new BL.Product(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        #region Add Attribute to Product Tests

        /// <summary>
        /// you can not add an null object to the add attribute
        /// i.e. you can not pass null to the add attribute
        /// </summary>
        [Test]
        public void AddNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(() => _product1.AddAttribute(null));
        }

        /// <summary>
        /// you can not add a attribute that has not been set up
        /// correct.  I.E. not all maditory fields on the attribute have been set
        /// </summary>
        [Test]
        public void AddNewlyCreatedAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _product1.AddAttribute(testObj));
        }

        /// <summary>
        /// The attribute does not need to be saved to the db
        /// before be added to the product
        /// </summary>
        [Test]
        public void AddWithoutSavingAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            _product1.AddAttribute(testObj);
            List<BL.Attribute> attributes = BL.Attribute.GetAll(GetRepository);
            Assert.AreEqual(attributes.Count, 1);
        }

        /// <summary>
        /// Add a attribute to the product
        /// </summary>
        [Test]
        public void AddAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            List<BL.Attribute> attributes = BL.Attribute.GetAll(GetRepository);
            Assert.AreEqual(attributes.Count, 1);
            BL.Attribute[] attris = _product1.GetAttributes();
            Assert.AreEqual(attris.Length, 1);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the product
        /// </summary>
        [Test]
        public void GetAttribute1Test()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            BL.Attribute[] attributes = _product1.GetAttributes();
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribue that has been added to the product
        /// </summary>
        [Test]
        public void GetAttribute2Test()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            BL.Attribute[] attributes = _product1.GetAttributes(false);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the product
        /// </summary>
        [Test]
        public void GetDeletedAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            testObj.Delete();
            BL.Attribute[] attributes = _product1.GetAttributes(true);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// you can not remove a null attribute from a product
        /// </summary>
        [Test]
        public void RemoveNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(() => _product1.RemoveAttribute(null));
        }

        /// <summary>
        /// The attribute has to be saved before it can be removed
        /// </summary>
        [Test]
        public void RemoveUnsavedAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            Assert.Throws<ClassDependencyException>(() => _product1.RemoveAttribute(testObj));
            BL.Attribute[] attributes = _product1.GetAttributes();
            Assert.AreEqual(0, attributes.Length);
        }

        /// <summary>
        /// The remove attribute can not remove a attribute
        /// that was not added to the product
        /// </summary>
        [Test]
        public void RemoveAttributeThatHasNotBeedAddedTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            bool wasPhoneNumberRemoved = _product1.RemoveAttribute(testObj);
            Assert.IsFalse(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// You can not remove a attribute from a product
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemoveAttributeOnNewCreatedProductTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();

            BL.Product testContact = new BL.Product(GetRepository)
            {
                Name = "Test",
                Description = "Case2"
            };
            Assert.Throws<RequiredFieldException>(()=> testContact.RemoveAttribute(testObj));
        }

        #endregion Add Attribute to Product Tests

        #region Add Attribute Value to Product Tests
        /// <summary>
        /// Add a attribute value to the product
        /// </summary>
        [Test]
        public void AddAttributeValueTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            Assert.AreEqual(1, GetRepository.GetProductAttriValues().ToList().Count);

        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// </summary>
        [Test]
        public void AddAttributeValueByIdTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj.Id, pav);

            Assert.AreEqual(1, GetRepository.GetProductAttriValues().ToList().Count);

        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            BL.ProductAttributeValue[] attributeValues = _product1.GetAttributeValues(testObj.Id);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdNonDeletedTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            BL.ProductAttributeValue[] attributeValues = _product1.GetAttributeValues(testObj.Id,false);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdDeletedTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);
            pav.Delete();


            BL.ProductAttributeValue[] attributeValues = _product1.GetAttributeValues(testObj.Id, false);
            Assert.AreEqual(0, attributeValues.Length);
            attributeValues = _product1.GetAttributeValues(testObj.Id, true);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            BL.ProductAttributeValue[] attributeValues = _product1.GetAttributeValues(testObj);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeNonDeletedTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            List<BL.ProductAttributeValue> attributeValues = _product1.GetAttributeValues(testObj, false);
            Assert.AreEqual(1, attributeValues.Count);
        }

        /// <summary>
        /// Get attribute values using the Id of the atttribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeDeletedTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);
            pav.Delete();


            List<BL.ProductAttributeValue> attributeValues = _product1.GetAttributeValues(testObj, false);
            Assert.AreEqual(0, attributeValues.Count);
            attributeValues = _product1.GetAttributeValues(testObj, true);
            Assert.AreEqual(1, attributeValues.Count);
        }

        /// <summary>
        /// delete attribute values
        /// </summary>
        [Test]
        public void DeleteAttributeValueTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            BL.ProductAttributeValue pav = new BL.ProductAttributeValue(GetRepository)
            {
                ValueName = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);
            pav.PermanentlyRemoveFromSystem();


            List<BL.ProductAttributeValue> attributeValues = _product1.GetAttributeValues(testObj,true);
            Assert.AreEqual(0, attributeValues.Count);
        }


        #endregion Add Attribute Value to Product Tests

        #region Add Option to Product Tests

        /// <summary>
        /// you can not add an null object to the add Option
        /// i.e. you can not pass null to the add Option
        /// </summary>
        [Test]
        public void AddNullOptionTest()
        {
            Assert.Throws<InvalidParameterException>(()=> _product1.AddOption(null));
        }

        /// <summary>
        /// you can not add a Option that has not been set up
        /// correct.  I.E. not all maditory fields on the Option have been set
        /// </summary>
        [Test]
        public void AddNewlyCreatedOptionTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _product1.AddOption(testObj));
        }

        /// <summary>
        /// The Option does not need to be saved to the db
        /// before be added to the product
        /// </summary>
        [Test]
        public void AddWithoutSavingOptionTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            _product1.AddOption(testObj);
            List<BL.ProductOption> options = BL.ProductOption.GetAll(GetRepository);
            Assert.AreEqual(options.Count, 1);
        }

        /// <summary>
        /// Add a Option to the product
        /// </summary>
        [Test]
        public void AddOptionTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();
            _product1.AddOption(testObj);
            List<BL.ProductOption> options = BL.ProductOption.GetAll(GetRepository);
            Assert.AreEqual(options.Count, 1);
            BL.ProductOption[] attris = _product1.GetOptions();
            Assert.AreEqual(attris.Length, 1);
        }

        /// <summary>
        /// Test Getting a Option that has been added to the product
        /// </summary>
        [Test]
        public void GetOption1Test()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();
            _product1.AddOption(testObj);
            BL.ProductOption[] options = _product1.GetOptions();
            Assert.AreEqual(1, options.Length);
            Assert.AreEqual(testObj.Id, options[0].Id);
        }

        /// <summary>
        /// Test Getting a attribue that has been added to the product
        /// </summary>
        [Test]
        public void GetOption2Test()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();
            _product1.AddOption(testObj);
            BL.ProductOption[] options = _product1.GetOptions(false);
            Assert.AreEqual(1, options.Length);
            Assert.AreEqual(testObj.Id, options[0].Id);
        }

        /// <summary>
        /// Test Getting a Option that has been added to the product
        /// </summary>
        [Test]
        public void GetDeletedOptionTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();
            _product1.AddOption(testObj);
            testObj.Delete();
            BL.ProductOption[] options = _product1.GetOptions(true);
            Assert.AreEqual(1, options.Length);
            Assert.AreEqual(testObj.Id, options[0].Id);
        }

        /// <summary>
        /// you can not remove a null Option from a product
        /// </summary>
        [Test]
        public void RemoveNullOptionTest()
        {
            Assert.Throws<InvalidParameterException>(() => _product1.RemoveOption(null));
        }

        /// <summary>
        /// The Option has to be saved before it can be removed
        /// </summary>
        [Test]
        public void RemoveUnsavedOptionTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            Assert.Throws<ClassDependencyException>(() => _product1.RemoveOption(testObj));
            BL.ProductOption[] options = _product1.GetOptions();
            Assert.AreEqual(0, options.Length);
        }

        /// <summary>
        /// The remove Option can not remove a Option
        /// that was not added to the product
        /// </summary>
        [Test]
        public void RemoveOptionThatHasNotBeedAddedTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();
            bool wasPhoneNumberRemoved = _product1.RemoveOption(testObj);
            Assert.IsFalse(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// You can not remove a Option from a product
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemoveOptionOnNewCreatedProductTest()
        {
            BL.ProductOption testObj = new BL.ProductOption(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            testObj.Save();

            BL.Product testContact = new BL.Product(GetRepository)
            {
                Name = "Test",
                Description = "Case2"
            };
            Assert.Throws<RequiredFieldException>(()=> testContact.RemoveOption(testObj));
        }

        #endregion Add Option to Product Tests

        #region Product Price to Product Tests

        /// <summary>
        /// Add a price to the option
        /// </summary>
        [Test]
        public void AddPriceTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            _product1.AddPrice(testObj);

            Assert.AreEqual(1, GetRepository.GetProductPrices().ToList().Count);
        }

        /// <summary>
        /// you can not add an null object to the add price
        /// i.e. you can not pass null to the add price
        /// </summary>
        [Test]
        public void AddNullPriceTest()
        {
            Assert.Throws<InvalidParameterException>(() => _product1.AddPrice(null));
        }

        /// <summary>
        /// you can not add a price that has not been set up
        /// correct.  I.E. not all maditory fields on the price have been set
        /// </summary>
        [Test]
        public void AddNewlyCreatedPriceTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _product1.AddPrice(testObj));
        }

        /// <summary>
        /// Permantly remove the price from the system
        /// </summary>
        [Test]
        public void PermantlyDeletePriceTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            _product1.AddPrice(testObj);

            testObj.PermanentlyRemoveFromSystem();
            Assert.AreEqual(0, GetRepository.GetProductPrices().ToList().Count);
        }

        /// <summary>
        /// Mark the price as deleted
        /// </summary>
        [Test]
        public void DeletePriceTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            _product1.AddPrice(testObj);

            testObj.Delete();
            Assert.AreEqual(1, GetRepository.GetProductPrices().ToList().Count);
        }

        /// <summary>
        /// Get a price
        /// </summary>
        [Test]
        public void GetPriceTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            _product1.AddPrice(testObj);

            BL.ProductPrice[] results = _product1.GetPrice();
            Assert.AreEqual(1, results.Length);
        }

        /// <summary>
        /// an product can only have one default price
        /// test to see an expection is thrown when the rule
        /// is valiated
        /// </summary>
        [Test]
        public void OneDefaultPriceAtATimeTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            _product1.AddPrice(testObj);

            testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(6);
            Assert.Throws<DataException>(()=> _product1.AddPrice(testObj));

        }

        /// <summary>
        /// an product can only have one price on a given day
        /// test to see an expection is thrown when the rule
        /// is valiated
        /// </summary>
        [Test]
        public void OnePriceAtATimeTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            testObj.Start = DateTime.Now;
            testObj.End = DateTime.Now;
            _product1.AddPrice(testObj);

            testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(6);
            testObj.Start = DateTime.Now;
            testObj.End = DateTime.Now;
            Assert.Throws<DataException>(() => _product1.AddPrice(testObj));
        }

        /// <summary>
        /// Test to see an product can have multiple prices
        /// with out violating one price for a given date
        /// and your able to get the price on a date
        /// </summary>
        [Test]
        public void TwoPricesTest()
        {
            BL.ProductPrice testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            testObj.Start = DateTime.Now.AddDays(-5);
            testObj.End = DateTime.Now.AddDays(-5);
            _product1.AddPrice(testObj);
            testObj.Delete();

            testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(5);
            testObj.Start = DateTime.Now.AddDays(-5);
            testObj.End = DateTime.Now.AddDays(-5);
            _product1.AddPrice(testObj);

            testObj = new BL.ProductPrice(GetRepository);
            testObj.SetPrice(6);
            testObj.Start = DateTime.Now;
            testObj.End = DateTime.Now;
            _product1.AddPrice(testObj);

            BL.ProductPrice[] results = _product1.GetPrice(false, DateTime.Now);
            Assert.AreEqual(1, results.Length);

            results = _product1.GetPrice();
            Assert.AreEqual(2, results.Length);

            results = _product1.GetPrice(false, DateTime.Now.AddDays(-5));
            Assert.AreEqual(1, results.Length);

            results = _product1.GetPrice(true, DateTime.Now.AddDays(-5));
            Assert.AreEqual(2, results.Length);

            results = _product1.GetPrice(true);
            Assert.AreEqual(3, results.Length);
        }

        #endregion Product Price to Product Tests

    }
}
