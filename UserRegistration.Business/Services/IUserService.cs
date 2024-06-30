using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Data.Models;

namespace UserRegistration.Business.Services
{
    public interface IUserService
    {
        IEnumerable<userRegistration> GetAllUsers();
        userRegistration GetUserById(int id);
        void RegisterUser(userRegistration user);
        void UpdateUser(userRegistration user);
        void DeleteUser(int id);
        IEnumerable<State> GetStates();
        IEnumerable<City> GetCitiesByStateId(int stateId);
    }
}
