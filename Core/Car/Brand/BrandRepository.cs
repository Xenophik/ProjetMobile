using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class BrandRepository : IBrandRepository
    {
        private static ConcurrentDictionary<string, Brand> Brands =
            new ConcurrentDictionary<string, Brand>();

        public BrandRepository()
        {
            Add(new Brand { Id = Guid.NewGuid().ToString(), Text = "Brand 1", Description = "This is an Brand description." });
            Add(new Brand { Id = Guid.NewGuid().ToString(), Text = "Brand 2", Description = "This is an Brand description." });
            Add(new Brand { Id = Guid.NewGuid().ToString(), Text = "Brand 3", Description = "This is an Brand description." });
        }

        public Brand Get(string id)
        {
            return Brands[id];
        }

        public IEnumerable<Brand> GetAll()
        {
            return Brands.Values;
        }

        public void Add(Brand Brand)
        {
            Brand.Id = Guid.NewGuid().ToString();
            Brands[Brand.Id] = Brand;
        }

        public Brand Find(string id)
        {
            Brand Brand;
            Brands.TryGetValue(id, out Brand);

            return Brand;
        }

        public Brand Remove(string id)
        {
            Brand Brand;
            Brands.TryRemove(id, out Brand);

            return Brand;
        }

        public void Update(Brand Brand)
        {
            Brands[Brand.Id] = Brand;
        }
    }
}
