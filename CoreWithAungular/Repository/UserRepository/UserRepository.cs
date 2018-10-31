using CoreWithAungular.Models;
using CoreWithAungular.Repository.DataRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        #region Private Variables and Constructor
        private readonly IDataRepository<UserDetails> _dataRepository;
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(IDataRepository<UserDetails> dataRepository, ApplicationDbContext dbContext)
        {
            _dataRepository = dataRepository;
            _dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get all users from the database
        /// </summary>
        /// <returns>users from the database</returns>
        public IList<UserDetails> GetAllUsers()
        {
            return _dataRepository.GetAll().ToList();
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">Id of the user to be searched</param>
        /// <returns>User details</returns>
        public async Task<UserDetails> GetUserDetail(long id)
        {
            return await _dataRepository.GetByIdAsync(id);
        }


        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>Object of type user</returns>
        public UserDetails GetUserByUserName(string userName)
        {
            return _dbContext.UserDetails.FirstOrDefault(x => x.EmailId == userName);
        }

        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="user">User to be added</param>
        /// <returns>Added user</returns>
        public async Task<UserDetails> AddUser(UserDetails user)
        {
            _dataRepository.InsertAsync(user);
            return user;
        }

        /// <summary>
        /// Update user in the database
        /// </summary>
        /// <param name="userDetails">user details</param>
        /// <returns>Updated user</returns>
        public async Task<UserDetails> UpdateUser(UserDetails userDetails)
        {
            return null;
        }

        /// <summary>
        /// Delete a user from the database
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        public async void DeleteUser(long id)
        {
            _dataRepository.DeleteAsync(id);
        }

        #endregion
    }
}
