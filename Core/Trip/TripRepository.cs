using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class TripRepository : ITripRepository
    {
        private static ConcurrentDictionary<string, Trip> Trips =
            new ConcurrentDictionary<string, Trip>();

        public TripRepository()
        {
            Add(new Trip { Id = Guid.NewGuid().ToString(), Text = "Trip 1", Description = "This is an Trip description." });
            Add(new Trip { Id = Guid.NewGuid().ToString(), Text = "Trip 2", Description = "This is an Trip description." });
            Add(new Trip { Id = Guid.NewGuid().ToString(), Text = "Trip 3", Description = "This is an Trip description." });
        }

        public Trip Get(string id)
        {
            return Trips[id];
        }

        public IEnumerable<Trip> GetAll()
        {
            return Trips.Values;
        }

        public void Add(Trip Trip)
        {
            Trip.Id = Guid.NewGuid().ToString();
            Trips[Trip.Id] = Trip;
        }

        public Trip Find(string id)
        {
            Trip Trip;
            Trips.TryGetValue(id, out Trip);

            return Trip;
        }

        public Trip Remove(string id)
        {
            Trip Trip;
            Trips.TryRemove(id, out Trip);

            return Trip;
        }

        public void Update(Trip Trip)
        {
            Trips[Trip.Id] = Trip;
        }
    }
}
