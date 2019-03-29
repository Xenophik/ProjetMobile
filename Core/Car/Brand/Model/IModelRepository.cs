using System.Collections.Generic;

namespace Core
{
    public interface IModelRepository
    {
        void Add(Model Model);
        void Update(Model Model);
        Model Remove(string key);
        Model Get(string id);
        IEnumerable<Model> GetAll();
    }
}
