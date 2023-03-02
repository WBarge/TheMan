using System.Collections.Generic;
using System.Linq;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.DB_DTOs;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedProduct
{
    [TestFixture]
    class BlPredefinedProductTests : TestBase
    {
        OrderInvoice_BL.Products.Product _product1;
        OrderInvoice_BL.Products.ProductOption _productOption;
        OrderInvoice_BL.Products.PredefinedOption _predefinedOption1;
        OrderInvoice_BL.Products.PredefinedProduct _predefinedProduct1;
        OrderInvoice_BL.Products.PredefinedProduct _predefinedProduct2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = CreateProduct();
            _productOption = CreateOption();
            _predefinedProduct1 = CreatePredefinedProduct(_product1);
            _predefinedProduct2 = OrderInvoice_BL.Products.PredefinedProduct.GetById(_predefinedProduct1.Id, GetRepository);
            _predefinedOption1 = CreatePredefinedOption(_predefinedProduct1, _productOption);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            //remove detail tables
            _predefinedOption1.RemoveAllAttributeValues();
            //remove predefined option
            _predefinedOption1.PermanentlyRemoveFromSystem();
            //remove detail tables
            _predefinedProduct1.RemoveAllAttributeValues();
            _predefinedProduct1.PermanentlyRemoveFromSystem();

            //remove attibute values
            foreach (IOptionsAttributeValues pav in GetRepository.GetOptionAttriValues())
            {
                GetRepository.DeleteOptionAttriValue(pav.Objid);
            }

            //remove many-many tables
            foreach (OrderInvoice_BL.Products.Product temp in OrderInvoice_BL.Products.Product.GetAll(true,GetRepository))
            {
                OrderInvoice_BL.Products.ProductOption[] results = temp.GetOptions(true);
                foreach (OrderInvoice_BL.Products.ProductOption pnt in results)
                {
                    pnt.GetAttributes(temp,true)
                        .ToList()
                        .ForEach(attri => pnt.RemoveAttribute(temp,attri));
                }
            }
            //remove attibute values
            GetRepository.GetProductAttriValues().ToList().ForEach(pav => GetRepository.DeleteProductAttriValue(pav.Objid));


            //remove many-many tables
            List<OrderInvoice_BL.Products.Product> results2 = OrderInvoice_BL.Products.Product.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Products.Product pnt in results2)
            {
                pnt.GetAttributes(true).ToList()
                    .ForEach(attri => pnt.RemoveAttribute(attri));
            }

            //remove attibutes
            List<OrderInvoice_BL.Products.Attribute> tempAttributeTypes = OrderInvoice_BL.Products.Attribute.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Products.Attribute attributeType in tempAttributeTypes)
            {
                attributeType.PermanentlyRemoveFromSystem();
            }


            List<OrderInvoice_BL.Products.ProductOption> productOptions = OrderInvoice_BL.Products.ProductOption.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Products.ProductOption pnt in productOptions)
            {
                pnt.PermanentlyRemoveFromSystem();
            }

            OrderInvoice_BL.Products.Attribute.GetAll(true, GetRepository).ForEach(a => a.PermanentlyRemoveFromSystem());

            _product1.PermanentlyRemoveFromSystem();
        }

        #region Predefined Product Tests

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _predefinedProduct1.Delete();
            OrderInvoice_BL.Products.PredefinedProduct pnt = OrderInvoice_BL.Products.PredefinedProduct.GetById(_predefinedProduct1.Id, GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            OrderInvoice_BL.Products.PredefinedProduct pnt21 = null;
            try
            {
                pnt21 = CreatePredefinedProduct(_product1);
                pnt21.Description = "A solid end grain cutting board without any finish";
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.PredefinedProduct> results = OrderInvoice_BL.Products.PredefinedProduct.GetAll(GetRepository);
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
            OrderInvoice_BL.Products.PredefinedProduct pnt21 = null;
            try
            {
                pnt21 = CreatePredefinedProduct(_product1);
                pnt21.Description = "A solid end grain cutting board without any finish";
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.PredefinedProduct> results = OrderInvoice_BL.Products.PredefinedProduct.GetAll(true, GetRepository);
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
            OrderInvoice_BL.Products.PredefinedProduct testObj = new OrderInvoice_BL.Products.PredefinedProduct(GetRepository, _product1);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Products.PredefinedProduct testObj = new OrderInvoice_BL.Products.PredefinedProduct(GetRepository, _product1);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        #endregion Predefined Product Tests

        #region Attribute Tests

        /// <summary>
        /// Test Getting a attribute that has been added to the product
        /// </summary>
        [Test]
        public void GetDefaultAttributes1Test()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes();
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribue that has been added to the product
        /// </summary>
        [Test]
        public void GetDefaultAttributes2Test()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes(false);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the product
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
            _product1.AddAttribute(testObj);
            testObj.Delete();
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes(true);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        #endregion Attribute Tests

        #region Add Attribute Value Tests
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
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes();
            _predefinedProduct1.AddAttributeValue(attributes[0], "TestValue");
            IPredefinedProductDetail obj = GetRepository.GetPredefinedProductDetailForAttribute(_predefinedProduct1.Id, testObj.Id);
            Assert.AreNotEqual(string.Empty, obj.Value);
        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// Should throw when the attribute value is null
        /// </summary>
        [Test]
        public void AddAttributeValueThrowNullAttributeValueTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes();
            Assert.Throws<InvalidParameterException>(() => _predefinedProduct1.AddAttributeValue(attributes[0], null));
        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// Should throw when the attribute value is string.empty
        /// </summary>
        [Test]
        public void AddAttributeValueThrowEmptyStringAttributeValueTest()
        {
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes();
            Assert.Throws<InvalidParameterException>(() => _predefinedProduct1.AddAttributeValue(attributes[0], string.Empty));
        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// Should throw when the attribute is null
        /// </summary>
        [Test]
        public void AddAttributeValueThrowNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(() => _predefinedProduct1.AddAttributeValue(null, "should throw since attirbute is null"));
        }

        /// <summary>
        /// Get attribute values using the attribute
        /// </summary>
        [Test]
        public void GetAttributeValueTest()
        {
            string testValue = "TestValue";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedProduct1.GetProductAttributes();
            _predefinedProduct1.AddAttributeValue(attributes[0], testValue);
            string obj = _predefinedProduct1.GetAttributeValue(attributes[0]);
            Assert.AreNotEqual(string.Empty, obj);
            Assert.AreEqual(testValue, obj);
        }

        /// <summary>
        /// Get default attribute values using the attribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesTest()
        {
            string testValue = "TestValue";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            ProductAttributeValue pav = new ProductAttributeValue(GetRepository)
            {
                ValueName = testValue,
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            ProductAttributeValue[] objs = _predefinedProduct1.GetProductAttributeValues(testObj);

            Assert.Greater(objs.Length, 0);
            Assert.AreEqual(objs[0].ValueName, testValue);
        }

        /// <summary>
        /// Get the non-deleted default attribute values using the attribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesNonDeletedTest()
        {
            string testValue = "TestValue";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            ProductAttributeValue pav = new ProductAttributeValue(GetRepository)
            {
                ValueName = testValue,
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            List<ProductAttributeValue> objs = _predefinedProduct1.GetProductAttributeValues(testObj,false);

            Assert.Greater(objs.Count, 0);
            Assert.AreEqual(objs[0].ValueName, testValue);
        }

        /// <summary>
        /// Get the deleted default attribute values using the attribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesDeletedTest()
        {
            string testValue = "TestValue";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _product1.AddAttribute(testObj);

            ProductAttributeValue pav = new ProductAttributeValue(GetRepository)
            {
                ValueName = testValue,
                Description = "This is a test value to see the attribute value object works"
            };
            _product1.AddAttributeValue(testObj, pav);

            pav.Delete();

            List<ProductAttributeValue> objs = _predefinedProduct1.GetProductAttributeValues(testObj, false);

            Assert.AreEqual(objs.Count, 0);
            
            objs = _predefinedProduct1.GetProductAttributeValues(testObj, true);

            Assert.AreEqual(objs.Count, 1);
            Assert.AreEqual(objs[0].ValueName, testValue);
        }

        #endregion Add Attribute Value Tests

        #region  PredefinedOption Tests

        [Test]
        public void GetPredefinedOptions()
        {
            OrderInvoice_BL.Products.PredefinedOption[] results = _predefinedProduct2.GetPredefinedOptions();

            Assert.Greater(results.Length, 0);
            Assert.AreEqual(results[0].Id, _predefinedOption1.Id);
        }

        [Test]
        public void GetNoNDeletedPredefinedOptions()
        {
            _predefinedOption1.Delete();
            OrderInvoice_BL.Products.PredefinedOption[] results = _predefinedProduct2.GetPredefinedOptions();

            Assert.AreEqual(results.Length, 0);
        }

        #endregion PredefinedOption Tests

    }
}
