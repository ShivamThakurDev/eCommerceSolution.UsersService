using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            //Generate a new unique user Id for the user
            user.UserID = Guid.NewGuid();
            //SQL Query to insert the user into the database
            string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"PersonName\",\"Gender\",\"Password\") VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
                
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
