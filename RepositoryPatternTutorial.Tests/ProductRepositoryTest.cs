using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPatternTutorial.Core;
using RepositoryPatternTutorial.Infrastructr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTutorial.Tests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        ProductRepository Repo = new ProductRepository();
        [TestInitialize]
        public void TestSetup()
        {
            ProductInitalizeDB db = new ProductInitalizeDB();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new ProductRepository();
        }

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            var result = (ICollection<Product>)Repo.GetProducts();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(2, numberOfRecords);
        }


        [TestMethod]
        public void IsRepositoryAddsProduct()
        {
            Product productToInsert = new Product
            {
                Id = 3,
                InStock = true,
                Name = "Salt",
                Price = 17

            };
            Repo.Add(productToInsert);
            // If Product inserts successfully, 
            //number of records will increase to 3 
            var result = (ICollection<Product>)Repo.GetProducts();
            var numberOfRecords = result.ToList().Count;


            Assert.AreEqual(3, numberOfRecords);
        }
    }
}
