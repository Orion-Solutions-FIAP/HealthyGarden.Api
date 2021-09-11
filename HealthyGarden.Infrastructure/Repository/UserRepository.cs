using System.Data;
using System.Data.SqlClient;
using Dapper;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace HealthyGarden.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IOptions<ConnectionStringConfig> options)
        {
            _connectionString = options.Value.ConnectionSqlServer;
        }

        public User Insert(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("Name",entity.Name, DbType.AnsiString,size:40);
                parameter.Add("Email", entity.Email, DbType.AnsiString,size:60);
                parameter.Add("Password", entity.Password, DbType.AnsiString, size: 40);
                parameter.Add("NewId",dbType:DbType.Int32, direction:ParameterDirection.Output);
                connection.Execute("p_HG_InsertUser", parameter, commandType: CommandType.StoredProcedure);
                entity.Id = parameter.Get<int>("NewId");
                entity.Password = null;
                return entity;
            }
        }

        public User GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var user = connection.QueryFirstOrDefault<User>("p_HG_GetUserByID", new { Id = id }, commandType: CommandType.StoredProcedure);
                if (user == null) return null;
                user.Password = null;
                return user;
            }
        }

        public int GetNumberOfUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<int>("SELECT dbo.Fn_HG_ContaLinhas('user')", commandType: CommandType.Text);
            }
        }

        public User Update(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_UpdateUserByID", new { entity.Id, entity.Name, entity.Email, entity.Password},
                    commandType: CommandType.StoredProcedure);
                entity.Password = null;
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_DeleteUserByID", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
