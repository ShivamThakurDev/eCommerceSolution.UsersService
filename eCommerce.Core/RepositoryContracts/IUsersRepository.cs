using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContracts
{/// <summary>
/// Contract to be implemented by the UserRepository
/// class that contains data access logic of Users data
/// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add a user to the data store and return the added user
        /// </summary>
        Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
        /// <summary>
        /// Method to retrieve a user from the data store by email and password
        /// </summary>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
