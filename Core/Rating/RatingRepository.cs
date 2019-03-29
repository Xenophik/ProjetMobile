using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class RatingRepository : IRatingRepository
    {
        private static ConcurrentDictionary<string, Rating> Ratings =
            new ConcurrentDictionary<string, Rating>();

        public RatingRepository()
        {
            Add(new Rating { Id = Guid.NewGuid().ToString(), Text = "Rating 1", Description = "This is an Rating description." });
            Add(new Rating { Id = Guid.NewGuid().ToString(), Text = "Rating 2", Description = "This is an Rating description." });
            Add(new Rating { Id = Guid.NewGuid().ToString(), Text = "Rating 3", Description = "This is an Rating description." });
        }

        public Rating Get(string id)
        {
            return Ratings[id];
        }

        public IEnumerable<Rating> GetAll()
        {
            return Ratings.Values;
        }

        public void Add(Rating Rating)
        {
            Rating.Id = Guid.NewGuid().ToString();
            Ratings[Rating.Id] = Rating;
        }

        public Rating Find(string id)
        {
            Rating Rating;
            Ratings.TryGetValue(id, out Rating);

            return Rating;
        }

        public Rating Remove(string id)
        {
            Rating Rating;
            Ratings.TryRemove(id, out Rating);

            return Rating;
        }

        public void Update(Rating Rating)
        {
            Ratings[Rating.Id] = Rating;
        }
    }
}
