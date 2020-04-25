using MongoDB.Bson;
using System.Collections.Generic;

using ShookModel.Models;

namespace ShookREST.Utils.MongoDB
{
    /// <summary>
    /// Handles the database access. 
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Returns all users that are in the database.
        /// </summary>
        /// <returns>All users that are in the database.</returns>
        IEnumerable<User> AllUsers();

        /// <summary>
        /// Returns a user by its id.
        /// </summary>
        /// <param name="id">The id of the user that should be displayed.</param>
        /// <returns>A user by its id.</returns>
        User GetById(ObjectId id);

        /// <summary>
        /// This method is used by the login procedure. The method tries to find a user with a certain username and
        /// password. If there is no user it will return null.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The user with the username and password or null if there is no user with these credentials.</returns>
        User GetByUsernameAndPassword(string username, string password);

        /// <summary>
        /// Adds a user
        /// </summary>
        /// <param name="user">The user to add.</param>
        void Add(User user);

        /// <summary>
        /// Updates an existing user in the database with the new values of the user object.
        /// </summary>
        /// <param name="user">The new values.</param>
        void Update(User user);

        /// <summary>
        /// Removes a user by its id.
        /// </summary>
        /// <param name="id">The id of the user that should be deleted.</param>
        /// <returns>True if the user was removed successfully.</returns>
        bool Remove(ObjectId id);
    }
}
