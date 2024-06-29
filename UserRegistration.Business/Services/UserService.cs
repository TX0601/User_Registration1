using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Data.Models;
using UserRegistration.Data.Repositories;

namespace UserRegistration.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<userRegistration> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetCitiesByStateId(int stateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetStates()
        {
            throw new NotImplementedException();
        }

        public userRegistration GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(userRegistration user)
        {
            // Business logic for user registration can go here
            _userRepository.AddUser(user);
        }

        public void UpdateUser(userRegistration user)
        {
            throw new NotImplementedException();
        }

        // // Implement other methods similarly
    }
}
