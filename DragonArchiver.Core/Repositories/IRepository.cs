using System;
using System.Collections.Generic;

namespace DragonArchiver.Core.Repositories;

public interface IRepository<T>
{
    T Get(Guid id);
    void Insert(T item);
    IEnumerable<T> GetAll();
    void Update(T item);
}