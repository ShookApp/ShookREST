using MongoDB.Bson;
using System.Collections.Generic;

using ShookModel.Models;

namespace ShookREST.Util.MongoDB
{
    interface IUserRepository
    {
        IEnumerable<User> AllUsers();

        User GetById(ObjectId id);

        User GetByUsernameAndPassword(string username, string password);

        void Add(User user);

        void Update(User user);

        bool Remove(ObjectId id);
    }
}
