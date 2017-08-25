using RepositoryPatternTutorial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternTutorial.Core;
using System.Collections;

namespace RepositoryPatternTutorial.Infrastructr
{
    public class ProductRepository : IProductRepository
    {
        ProductContext context = new ProductContext();
        public void Add(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public void Edit(Product p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
        }

        public Product FindById(int Id)
        {
            var result = (from r in context.Products where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable GetProducts()
        {
            return context.Products;
        }

        public void Remove(int Id)
        {
            Product p = context.Products.Where(c => c.Id == Id).First(); context.Products.Remove(p); context.SaveChanges();
        }
    }
}
