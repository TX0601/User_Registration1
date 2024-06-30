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

        public IEnumerable<userRegistration> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public userRegistration GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void RegisterUser(userRegistration user)
        {
            _userRepository.InsertUser(user);
        }

        public void UpdateUser(userRegistration user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<State> GetStates()
        {
            return _userRepository.GetStates();
        }

        public IEnumerable<City> GetCitiesByStateId(int stateId)
        {
            return _userRepository.GetCitiesByStateId(stateId);
        }
    }
}
