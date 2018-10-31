using CoreWithAungular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Repository.UserRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get all users from the database
        /// </summary>
        /// <returns>users from the database</returns>
        IList<UserDetails> GetAllUsers();

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">Id of the user to be searched</param>
        /// <returns>User details</returns>
        Task<UserDetails> GetUserDetail(long id);

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>Object of type user</returns>
        UserDetails GetUserByUserName(string userName);

        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="user">User to be added</param>
        /// <returns>Added user</returns>
        Task<UserDetails> AddUser(UserDetails user);

        /// <summary>
        /// Update user in the database
        /// </summary>
        /// <param name="userDetails">user details</param>
        /// <returns>Updated user</returns>
        Task<UserDetails> UpdateUser(UserDetails userDetails);

        /// <summary>
        /// Delete a user from the database
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        void DeleteUser(long id);

    }
}
