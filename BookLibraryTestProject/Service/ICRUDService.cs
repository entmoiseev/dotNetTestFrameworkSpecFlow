
using BookLibraryTestProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service
{
    public interface ICRUDService
    {
        void Create(Product product);

        Product GetById(int id);

        void Update(Product product, Product expectedProduct);

        void Remove(Product product);
    }
}
