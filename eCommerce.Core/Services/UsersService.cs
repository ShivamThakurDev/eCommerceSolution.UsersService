using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository,IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
           ApplicationUser? user =   await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }
            //return new AuthenticationResponse(user.UserID,user.Email, user.PersonName,user.Gender,"token",Sucess: true);
            return _mapper.Map<AuthenticationResponse>(user) with { Sucess= true, Token ="token"};
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            //Create a new ApplicationUser object from the RegisterRequest object
            ApplicationUser user = new ApplicationUser
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString()
            };
            ApplicationUser? registeredUser =  await _usersRepository.AddUserAsync(user);
            if(registeredUser == null)
            {

               return null;
            };
            //Return success response
            //return new AuthenticationResponse(
            //    registeredUser.UserID, 
            //    registeredUser.Email,
            //    registeredUser.PersonName, 
            //    registeredUser.Gender,
            //    "token", Sucess: true);
            return _mapper.Map<AuthenticationResponse>(registeredUser) with { Sucess = true, Token ="token"};
        }
    }
}
