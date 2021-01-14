using BookLibraryTestProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryTestProject.Service.Implementation
{
    public abstract class AbstractServiceImplementation 
    {
        public abstract void Create(Product p);
        public abstract Product GetById(int id);
        public abstract void Remove(Product product);
        public abstract void Update(Product product, Product expectedProduct);
    }
}
