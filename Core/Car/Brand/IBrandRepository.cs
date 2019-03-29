using System.Collections.Generic;

namespace Core
{
    public interface IBrandRepository
    {
        void Add(Brand Brand);
        void Update(Brand Brand);
        Brand Remove(string key);
        Brand Get(string id);
        IEnumerable<Brand> GetAll();
    }
}
