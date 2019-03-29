using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class CarRepository : ICarRepository
    {
        private static ConcurrentDictionary<string, Car> Cars =
            new ConcurrentDictionary<string, Car>();

        public CarRepository()
        {
            Add(new Car { Id = Guid.NewGuid().ToString(), Text = "Car 1", Description = "This is an Car description." });
            Add(new Car { Id = Guid.NewGuid().ToString(), Text = "Car 2", Description = "This is an Car description." });
            Add(new Car { Id = Guid.NewGuid().ToString(), Text = "Car 3", Description = "This is an Car description." });
        }

        public Car Get(string id)
        {
            return Cars[id];
        }

        public IEnumerable<Car> GetAll()
        {
            return Cars.Values;
        }

        public void Add(Car Car)
        {
            Car.Id = Guid.NewGuid().ToString();
            Cars[Car.Id] = Car;
        }

        public Car Find(string id)
        {
            Car Car;
            Cars.TryGetValue(id, out Car);

            return Car;
        }

        public Car Remove(string id)
        {
            Car Car;
            Cars.TryRemove(id, out Car);

            return Car;
        }

        public void Update(Car Car)
        {
            Cars[Car.Id] = Car;
        }
    }
}
