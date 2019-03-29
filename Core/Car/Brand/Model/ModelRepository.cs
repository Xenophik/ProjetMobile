using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Core
{
    public class ModelRepository : IModelRepository
    {
        private static ConcurrentDictionary<string, Model> Models =
            new ConcurrentDictionary<string, Model>();

        public ModelRepository()
        {
            Add(new Model { Id = Guid.NewGuid().ToString(), Text = "Model 1", Description = "This is an Model description." });
            Add(new Model { Id = Guid.NewGuid().ToString(), Text = "Model 2", Description = "This is an Model description." });
            Add(new Model { Id = Guid.NewGuid().ToString(), Text = "Model 3", Description = "This is an Model description." });
        }

        public Model Get(string id)
        {
            return Models[id];
        }

        public IEnumerable<Model> GetAll()
        {
            return Models.Values;
        }

        public void Add(Model Model)
        {
            Model.Id = Guid.NewGuid().ToString();
            Models[Model.Id] = Model;
        }

        public Model Find(string id)
        {
            Model Model;
            Models.TryGetValue(id, out Model);

            return Model;
        }

        public Model Remove(string id)
        {
            Model Model;
            Models.TryRemove(id, out Model);

            return Model;
        }

        public void Update(Model Model)
        {
            Models[Model.Id] = Model;
        }
    }
}
