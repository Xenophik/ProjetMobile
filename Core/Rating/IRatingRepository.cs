using System.Collections.Generic;

namespace Core
{
    public interface IRatingRepository
    {
        void Add(Rating Rating);
        void Update(Rating Rating);
        Rating Remove(string key);
        Rating Get(string id);
        IEnumerable<Rating> GetAll();
    }
}
