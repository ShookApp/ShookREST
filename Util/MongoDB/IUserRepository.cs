using MongoDB.Bson;
using ShookREST.Models;
using System.Collections.Generic;

namespace ShookREST.Util.MongoDB
{
    interface IUserRepository
    {
        IEnumerable<User> AllUsers();

        User GetById(ObjectId id);

        void Add(User user);

        void Update(User user);

        bool Remove(ObjectId id);
    }
}
