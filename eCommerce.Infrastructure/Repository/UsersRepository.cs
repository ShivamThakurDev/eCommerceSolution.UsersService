using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            //Generate a new unique user Id for the user
            user.UserID = Guid.NewGuid();

            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "John Doe",
                Gender = GenderOptions.Male.ToString()
            };
        }
    }
}
