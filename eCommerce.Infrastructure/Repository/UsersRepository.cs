using AutoMapper;
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        private readonly IMapper _mapper;
        public UsersRepository(DapperDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            //SQL query to select a user by Email and Password
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var parameters = new { Email = email, Password = password };
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstAsync<ApplicationUser>(query,parameters);
            return user;
        }
    }
}

