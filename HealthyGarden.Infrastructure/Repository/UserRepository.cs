using System;
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

        public User Insert(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("Name",user.Name, DbType.AnsiString,size:40);
                parameter.Add("Email", user.Email, DbType.AnsiString,size:60);
                parameter.Add("Password", user.Name, DbType.AnsiString, size: 40);
                parameter.Add("NewId",dbType:DbType.Int32, direction:ParameterDirection.Output);
                connection.Execute("p_HG_InsertUser", parameter, commandType: CommandType.StoredProcedure);
                user.Id = parameter.Get<int>("NewId");
                user.Password = null;
                return user;
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
                user.Id = id;
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

        public User Update(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_UpdateUserByID", new { user.Id, user.Name, user.Email, user.Password},
                    commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
