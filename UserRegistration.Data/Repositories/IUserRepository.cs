using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Data.Models;

namespace UserRegistration.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<userRegistration> GetAllUsers();
        userRegistration GetUserById(int id);
        void InsertUser(userRegistration user);
        void UpdateUser(userRegistration user);
        void DeleteUser(int id);
        IEnumerable<State> GetStates();
        IEnumerable<City> GetCitiesByStateId(int stateId);
    }

}
