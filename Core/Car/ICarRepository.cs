using System.Collections.Generic;

namespace Core
{
    public interface ICarRepository
    {
        void Add(Car Car);
        void Update(Car Car);
        Car Remove(string key);
        Car Get(string id);
        IEnumerable<Car> GetAll();
    }
}
