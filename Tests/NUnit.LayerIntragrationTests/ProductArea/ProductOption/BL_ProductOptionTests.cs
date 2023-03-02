using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.DB_DTOs;

namespace NUnit.LayerIntragrationTests.ProductArea.ProductOption
{
    [TestFixture]
    class BlProductOptionTests : TestBase
    {
        OrderInvoice_BL.Products.ProductOption _productOption1;
        OrderInvoice_BL.Products.Product _product;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product = CreateProduct();
            _productOption1 = CreateOption();
            _product.AddOption(_productOption1);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            foreach (IOptionPrice op in GetRepository.GetOptionPrices())
            {
                GetRepository.DeleteOptionPrice(op.Objid);
            }

            foreach (IOptionsAttributeValues pav in GetRepository.GetOptionAttriValues())
            {
                GetRepository.DeleteOptionAttriValue(pav.Objid);
            }

            foreach (OrderInvoice_BL.Products.Product prod in OrderInvoice_BL.Products.Product.GetAll(true,GetRepository))
            {
                foreach (OrderInvoice_BL.Products.ProductOption pnt in prod.GetOptions(true))
                {
                    pnt.GetAttributes(prod,true).ToList().ForEach(attri => pnt.RemoveAttribute(prod,attri));
                }
            }
            var tempAttributeTypes = OrderInvoice_BL.Products.Attribute.GetAll(true,GetRepository);
            foreach (OrderInvoice_BL.Products.Attribute attributeType in tempAttributeTypes)
            {
                attributeType.PermanentlyRemoveFromSystem();
            }
            foreach (OrderInvoice_BL.Products.Product product in OrderInvoice_BL.Products.Product.GetAll(true,GetRepository))
            { 
                foreach (OrderInvoice_BL.Products.ProductOption pnt in product.GetOptions(true))
                {
                    product.RemoveOption(pnt);
                    pnt.PermanentlyRemoveFromSystem();
                }
                product.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _productOption1.Delete();

            OrderInvoice_BL.Products.ProductOption pnt = OrderInvoice_BL.Products.ProductOption.GetById(_productOption1.Id,GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            OrderInvoice_BL.Products.ProductOption pnt21 = null;
            try
            {
                pnt21 = new OrderInvoice_BL.Products.ProductOption(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.ProductOption> results = OrderInvoice_BL.Products.ProductOption.GetAll(GetRepository);
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
            OrderInvoice_BL.Products.ProductOption pnt21 = null;
            try
            {
                pnt21 = new OrderInvoice_BL.Products.ProductOption(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.ProductOption> results = OrderInvoice_BL.Products.ProductOption.GetAll(true, GetRepository);
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
            OrderInvoice_BL.Products.ProductOption testObj = new OrderInvoice_BL.Products.ProductOption(GetRepository);
            Assert.Throws<DataException>(() => testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Products.ProductOption testObj = new OrderInvoice_BL.Products.ProductOption(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        #region Attribute to Product Option Tests

        /// <summary>
        /// you can not add an null object to the add attribute
        /// i.e. you can not pass null to the add attribute
        /// </summary>
        [Test]
        public void AddNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(() => _productOption1.AddAttribute(_product, null));
        }

        /// <summary>
        /// you can not add a attribute that has not been set up
        /// correct.  I.E. not all mandatory fields on the attribute have been set
        /// </summary>
        [Test]
        public void AddNewlyCreatedAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _productOption1.AddAttribute(_product, testObj));
        }

        /// <summary>
        /// The attribute does not need to be saved to the db
        /// before be added to the option
        /// </summary>
        [Test]
        public void AddWithoutSavingAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            _productOption1.AddAttribute(_product, testObj);
            List<OrderInvoice_BL.Products.Attribute> attributes = OrderInvoice_BL.Products.Attribute.GetAll(GetRepository);
            Assert.AreEqual(attributes.Count, 1);
        }

        /// <summary>
        /// Add a attribute to the option
        /// </summary>
        [Test]
        public void AddAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);
            List<OrderInvoice_BL.Products.Attribute> attributes = OrderInvoice_BL.Products.Attribute.GetAll(GetRepository);
            Assert.AreEqual(attributes.Count, 1);
            OrderInvoice_BL.Products.Attribute[] attris = _productOption1.GetAttributes(_product);
            Assert.AreEqual(attris.Length, 1);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the option
        /// </summary>
        [Test]
        public void GetAttribute1Test()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _productOption1.GetAttributes(_product);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribue that has been added to the option
        /// </summary>
        [Test]
        public void GetAttribute2Test()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _productOption1.GetAttributes(_product, false);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the option
        /// </summary>
        [Test]
        public void GetDeletedAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);
            testObj.Delete();
            OrderInvoice_BL.Products.Attribute[] attributes = _productOption1.GetAttributes(_product, true);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// you can not remove a null attribute from a option
        /// </summary>
        [Test]
        public void RemoveNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(()=> _productOption1.RemoveAttribute(_product, null));
        }

        /// <summary>
        /// The attribute has to be saved before it can be removed
        /// </summary>
        [Test]
        public void RemoveUnsavedAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            Assert.Throws<ClassDependencyException>(() => _productOption1.RemoveAttribute(_product, testObj));
            OrderInvoice_BL.Products.Attribute[] attributes = _productOption1.GetAttributes(_product);
            Assert.AreEqual(0, attributes.Length);
        }

        /// <summary>
        /// The remove attribute can not remove a attribute
        /// that was not added to the option
        /// </summary>
        [Test]
        public void RemoveAttributeThatHasNotBeenAddedTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            bool wasPhoneNumberRemoved = _productOption1.RemoveAttribute(_product, testObj);
            Assert.IsFalse(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// You can not remove a attribute from a option
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemoveAttributeOnNewCreatedProductTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();

            OrderInvoice_BL.Products.Product testContact = new OrderInvoice_BL.Products.Product(GetRepository)
            {
                Name = "Test",
                Description = "Case2"
            };
            Assert.Throws<RequiredFieldException>(()=> testContact.RemoveAttribute(testObj));
        }

        #endregion Attribute to Product Option Tests

        #region Attribute Value to Product Options Tests
        /// <summary>
        /// Add a attribute value to the product
        /// </summary>
        [Test]
        public void AddAttributeValueTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);

            Assert.AreEqual(1, GetRepository.GetOptionAttriValues().ToList().Count);

        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// </summary>
        [Test]
        public void AddAttributeValueByIdTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj.Id, pav);

            Assert.AreEqual(1, GetRepository.GetOptionAttriValues().ToList().Count);

        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);

            OptionAttributeValue[] attributeValues = _productOption1.GetAttributeValues(_product, testObj.Id);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdNonDeletedTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);

            OptionAttributeValue[] attributeValues = _productOption1.GetAttributeValues(_product, testObj.Id, false);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByIdDeletedTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);
            pav.Delete();


            OptionAttributeValue[] attributeValues = _productOption1.GetAttributeValues(_product, testObj.Id, false);
            Assert.AreEqual(0, attributeValues.Length);
            attributeValues = _productOption1.GetAttributeValues(_product, testObj.Id, true);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);

            OptionAttributeValue[] attributeValues = _productOption1.GetAttributeValues(_product, testObj);
            Assert.AreEqual(1, attributeValues.Length);
        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeNonDeletedTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);

            List<OptionAttributeValue> attributeValues = _productOption1.GetAttributeValues(_product, testObj, false);
            Assert.AreEqual(1, attributeValues.Count);
        }

        /// <summary>
        /// Get attribute values using the Id of the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueByAttributeDeletedTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);
            pav.Delete();


            List<OptionAttributeValue> attributeValues = _productOption1.GetAttributeValues(_product, testObj, false);
            Assert.AreEqual(0, attributeValues.Count);
            attributeValues = _productOption1.GetAttributeValues(_product, testObj, true);
            Assert.AreEqual(1, attributeValues.Count);
        }

        /// <summary>
        /// delete attribute values
        /// </summary>
        [Test]
        public void DeleteAttributeValueTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption1.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = "Test value",
                Description = "This is a test value to see the attribute value object works"
            };
            _productOption1.AddAttributeValue(_product, testObj, pav);
            pav.PermanentlyRemoveFromSystem();


            List<OptionAttributeValue> attributeValues = _productOption1.GetAttributeValues(_product, testObj, true);
            Assert.AreEqual(0, attributeValues.Count);
        }

        #endregion Attribute Value to Product Options Tests

        #region Product Option Price to Product Options Tests

        /// <summary>
        /// Add a price to the option
        /// </summary>
        [Test]
        public void AddOptionPriceTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(5);
            _productOption1.AddOptionPrice(testObj);

            Assert.AreEqual(1, GetRepository.GetOptionPrices().ToList().Count);
        }

        /// <summary>
        /// you can not add an null object to the add price
        /// i.e. you can not pass null to the add price
        /// </summary>
        [Test]
        public void AddNullOptionPriceTest()
        {
            Assert.Throws<InvalidParameterException>(()=> _productOption1.AddOptionPrice(null));
        }

        /// <summary>
        /// you can not add a price that has not been set up
        /// correct.  I.E. not all maditory fields on the option price have been set
        /// </summary>
        [Test]
        public void AddNewlyCreatedOptionPriceTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _productOption1.AddOptionPrice(testObj));
        }

        /// <summary>
        /// Permantly remove the price from the system
        /// </summary>
        [Test]
        public void PermantlyDeleteOptionPriceTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(5);
            _productOption1.AddOptionPrice(testObj);

            testObj.PermanentlyRemoveFromSystem();
            Assert.AreEqual(0, GetRepository.GetOptionPrices().ToList().Count);
        }

        /// <summary>
        /// Mark the price as deleted
        /// </summary>
        [Test]
        public void DeleteOptionPriceTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(5);
            _productOption1.AddOptionPrice(testObj);

            testObj.Delete();
            Assert.AreEqual(1, GetRepository.GetOptionPrices().ToList().Count);
        }

        /// <summary>
        /// Get a price
        /// </summary>
        [Test]
        public void GetOptionPriceTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(5);
            _productOption1.AddOptionPrice(testObj);

            OptionPrice[] results = _productOption1.GetPrice();
            Assert.AreEqual(1, results.Length);
        }

        /// <summary>
        /// an option can only have one price for a given date
        /// test to see an exception is thrown when the rule
        /// is validated
        /// </summary>
        [Test]
        public void OneOptionPriceAtATimeTest()
        {
            OptionPrice testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(5);
            _productOption1.AddOptionPrice(testObj);

            testObj = new OptionPrice(GetRepository);
            testObj.SetPrice(6);
            Assert.Throws<DataException>(()=> _productOption1.AddOptionPrice(testObj));

        }

        #endregion Product Option Price to Product Options Tests
    }
}
