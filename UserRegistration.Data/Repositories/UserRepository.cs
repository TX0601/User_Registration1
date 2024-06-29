using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Data.Models;

namespace UserRegistration.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddUser(userRegistration user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("spAddUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@StateId", user.StateId);
                command.Parameters.AddWithValue("@CityId", user.CityId);
                connection.Open();
                command.ExecuteNonQuery();
            }
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

        public void UpdateUser(userRegistration user)
        {
            throw new NotImplementedException();
        }
    }
}

