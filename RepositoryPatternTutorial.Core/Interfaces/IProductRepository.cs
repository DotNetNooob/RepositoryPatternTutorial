using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTutorial.Core.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product p);
        void Edit(Product p);
        void Remove(int Id);
        IEnumerable GetProducts();
        Product FindById(int Id);

    }
}
