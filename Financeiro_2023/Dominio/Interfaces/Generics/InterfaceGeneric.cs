﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Generics
{
    //internal interface InterfaceGeneric
    public interface InterfaceGeneric<T> where T : class  // onde o T é qualquer classe
    {
        Task Add(T objeto);
        Task Update(T objeto);
        Task Delete(T objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
