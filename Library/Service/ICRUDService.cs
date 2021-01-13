using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service
{
    public interface ICRUDService<T>
    {
        T Create(T p);

        T GetById(int id);
    }
}
