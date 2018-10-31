using CoreWithAungular.Models;
using CoreWithAungular.Repository.UserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithAungular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserDetailsController : ControllerBase
    {
        #region Private Variables and Constructor
        private readonly IUserRepository _userRepository;

        public UserDetailsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Get users from database
        /// </summary>
        /// <returns>All the users</returns>
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        /// <summary>
        /// Get details of user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetUserDetails([FromRoute] long id)
        {
            var user = await _userRepository.GetUserDetail(id);
            if (user == null)
                return NotFound();

            else
                return Ok(user);
        }

        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>added user</returns>
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser([FromBody] UserDetails user)
        {
            if (ModelState.IsValid)
                return Ok(await _userRepository.AddUser(user));

            else
                return BadRequest();
        }

        /// <summary>
        /// Update the user in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDetails"></param>
        /// <returns>updated user</returns>
        [HttpPut("{id}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserDetail(id);
                if (user != null)
                    return Ok(await _userRepository.UpdateUser(userDetails));
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }

        /// <summary>
        /// Delete the user from the database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            var user = await _userRepository.GetUserDetail(id);
            if (user != null)
            {
                _userRepository.DeleteUser(id);
                return Ok();
            }
            else
                return NotFound();
        }

        #endregion

    }
}