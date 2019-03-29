using System.Collections.Generic;

namespace Core
{
    public interface ITripRepository
    {
        void Add(Trip Trip);
        void Update(Trip Trip);
        Trip Remove(string key);
        Trip Get(string id);
        IEnumerable<Trip> GetAll();
    }
}
