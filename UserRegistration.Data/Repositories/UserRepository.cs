using Dapper;
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

        public IEnumerable<userRegistration> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<userRegistration>("sp_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public userRegistration GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<userRegistration>("sp_GetUserById", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertUser(userRegistration user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_InsertUser", new { user.Name, user.Email, user.Phone, user.Address, user.StateId, user.CityId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUser(userRegistration user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_UpdateUser", new { user.Id, user.Name, user.Email, user.Phone, user.Address, user.StateId, user.CityId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_DeleteUser", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<State> GetStates()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<State>("sp_GetStates", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<City> GetCitiesByStateId(int stateId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<City>("sp_GetCitiesByStateId", new { StateId = stateId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}

