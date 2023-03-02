using System.Collections.Generic;
using System.Linq;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Products;
using OrderInvoice_Interfaces.DB_DTOs;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedOption
{
    [TestFixture]
    public class BlPredefinedOptionTests : TestBase
    {
        OrderInvoice_BL.Products.Product _product;
        OrderInvoice_BL.Products.ProductOption _productOption;
        OrderInvoice_BL.Products.PredefinedProduct _predefinedProduct;
        OrderInvoice_BL.Products.PredefinedOption _predefinedOption1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>PredefinedOption
        [SetUp]
        public void TestsInit()
        {
            _product = CreateProduct();
            _productOption = CreateOption();
            _product.AddOption(_productOption);
            _predefinedProduct = CreatePredefinedProduct(_product);
            _predefinedOption1 = CreatePredefinedOption(_predefinedProduct, _productOption);
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
            _predefinedProduct.RemoveAllAttributeValues();
            _predefinedProduct.PermanentlyRemoveFromSystem();

            //remove attibute values
            foreach (IOptionsAttributeValues pav in GetRepository.GetOptionAttriValues())
            {
                GetRepository.DeleteOptionAttriValue(pav.Objid);
            }


            //remove attibute values
            GetRepository.GetProductAttriValues().ToList().ForEach(pav => GetRepository.DeleteProductAttriValue(pav.Objid));


            //remove many-many tables
            List<OrderInvoice_BL.Products.Product> results2 = OrderInvoice_BL.Products.Product.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Products.Product pnt in results2)
            {
                OrderInvoice_BL.Products.ProductOption[] productOptions = pnt.GetOptions(true);
                foreach (OrderInvoice_BL.Products.ProductOption productOption in productOptions)
                {
                    productOption.GetAttributes(pnt,true).ToList()
                        .ForEach(attri => productOption.RemoveAttribute(pnt, attri));
                    pnt.RemoveOption(productOption);
                }
                pnt.GetAttributes(true).ToList()
                    .ForEach(attri => pnt.RemoveAttribute(attri));
            }

            //remove attibutes
            List<OrderInvoice_BL.Products.Attribute> tempAttributeTypes = OrderInvoice_BL.Products.Attribute.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Products.Attribute attributeType in tempAttributeTypes)
            {
                attributeType.PermanentlyRemoveFromSystem();
            }

            foreach (OrderInvoice_BL.Products.ProductOption pnt in OrderInvoice_BL.Products.ProductOption.GetAll(true, GetRepository))
            {
                pnt.PermanentlyRemoveFromSystem();
            }


            OrderInvoice_BL.Products.Attribute.GetAll(true, GetRepository).ForEach(a => a.PermanentlyRemoveFromSystem());

            foreach (OrderInvoice_BL.Products.Product product in OrderInvoice_BL.Products.Product.GetAll(true,GetRepository))
            {
                product.PermanentlyRemoveFromSystem();
            }
        }


        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _predefinedOption1.Delete();
            OrderInvoice_BL.Products.PredefinedOption pnt = OrderInvoice_BL.Products.PredefinedOption.GetById(_predefinedOption1.Id, GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            OrderInvoice_BL.Products.PredefinedOption pnt21 = null;
            try
            {
                pnt21 = CreatePredefinedOption(_predefinedProduct, _productOption);
                pnt21.Description = "A solid end grain cutting board without any finish";
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.PredefinedOption> results = OrderInvoice_BL.Products.PredefinedOption.GetAll(GetRepository);
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
            OrderInvoice_BL.Products.PredefinedOption pnt21 = null;
            try
            {
                pnt21 = CreatePredefinedOption(_predefinedProduct, _productOption);
                pnt21.Description = "A solid end grain cutting board without any finish";
                pnt21.Save();
                pnt21.Delete();

                List<OrderInvoice_BL.Products.PredefinedOption> results = OrderInvoice_BL.Products.PredefinedOption.GetAll(true, GetRepository);
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
            OrderInvoice_BL.Products.PredefinedOption testObj = new OrderInvoice_BL.Products.PredefinedOption(GetRepository, _predefinedProduct, _productOption);
            Assert.Throws< DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Products.PredefinedOption testObj = new OrderInvoice_BL.Products.PredefinedOption(GetRepository, _predefinedProduct, _productOption);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

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
            _productOption.AddAttribute(_product,testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct);
            Assert.AreEqual(1, attributes.Length);
            Assert.AreEqual(testObj.Id, attributes[0].Id);
        }

        /// <summary>
        /// Test Getting a attribute that has been added to the product
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
            _productOption.AddAttribute(_product,testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct, false);
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
            _productOption.AddAttribute(_product, testObj);
            testObj.Delete();
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct, true);
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
            _productOption.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct);
            _predefinedOption1.AddAttributeValue(attributes[0], "TestValue");
            IPredefinedOptionDetail obj = GetRepository.GetPredefinedOptionDetailForAttribute(_predefinedOption1.Id, testObj.Id);
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
            _productOption.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct);
            Assert.Throws<InvalidParameterException>(()=> _predefinedOption1.AddAttributeValue(attributes[0], null));
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
            _productOption.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct);
            Assert.Throws<InvalidParameterException>(() => _predefinedOption1.AddAttributeValue(attributes[0], string.Empty));
        }

        /// <summary>
        /// Add a attribute value using the ID of the attribute to the product
        /// Should throw when the attribute is null
        /// </summary>
        [Test]
        public void AddAttributeValueThrowNullAttributeTest()
        {
            Assert.Throws<InvalidParameterException>(() => _predefinedOption1.AddAttributeValue(null, "should throw since attirbute is null"));
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
            _productOption.AddAttribute(_product, testObj);
            OrderInvoice_BL.Products.Attribute[] attributes = _predefinedOption1.GetOptionAttributes(_predefinedProduct);
            _predefinedOption1.AddAttributeValue(attributes[0], testValue);
            string obj = _predefinedOption1.GetAttributeValue(attributes[0]);
            Assert.AreNotEqual(string.Empty, obj);
            Assert.AreEqual(testValue, obj);
        }

        /// <summary>
        /// Get default attribute values using the attribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesTest()
        {
            string testDescription = "This is a test value to see the attribute value object works";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Description = testDescription
            };
            _productOption.AddAttributeValue(_product, testObj, pav);

            OptionAttributeValue[] objs = _predefinedOption1.GetOptionAttributeValues(_predefinedProduct, testObj);

            Assert.Greater(objs.Length, 0);
            Assert.AreEqual(objs[0].Description, testDescription);
        }

        /// <summary>
        /// Get the non-deleted default attribute values using the attribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesNonDeletedTest()
        {

            string testDescription = "This is a test value to see the attribute value object works";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Description = testDescription
            };
            _productOption.AddAttributeValue(_product, testObj, pav);

            List<OptionAttributeValue> objs = _predefinedOption1.GetOptionAttributeValues(_predefinedProduct, testObj, false);

            Assert.Greater(objs.Count, 0);
            Assert.AreEqual(objs[0].Description, testDescription);
        }

        /// <summary>
        /// Get the deleted default attribute values using the atttribute
        /// </summary>
        [Test]
        public void GetDefaultAttributeValuesDeletedTest()
        {
            string testValue = "TestValue";
            string testDescription = "This is a test value to see the attribute value object works";
            OrderInvoice_BL.Products.Attribute testObj = new OrderInvoice_BL.Products.Attribute(GetRepository)
            {
                Name = "1",
                Description = "7145551212"
            };
            testObj.Save();
            _productOption.AddAttribute(_product, testObj);

            OptionAttributeValue pav = new OptionAttributeValue(GetRepository)
            {
                Value = testValue,
                Description = testDescription
            };
            _productOption.AddAttributeValue(_product, testObj, pav);

            pav.Delete();

            List<OptionAttributeValue> objs = _predefinedOption1.GetOptionAttributeValues(_predefinedProduct, testObj, false);

            Assert.AreEqual(objs.Count, 0);

            objs = _predefinedOption1.GetOptionAttributeValues(_predefinedProduct,testObj, true);

            Assert.AreEqual(objs.Count, 1);
            Assert.AreEqual(objs[0].Description, testDescription);
        }

        #endregion Add Attribute Value Tests

    }
}
