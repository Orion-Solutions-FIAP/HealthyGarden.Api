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

                connection.Execute("HG_InsertUser", parameter, commandType: CommandType.StoredProcedure);
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
                var parameter = new DynamicParameters();
                parameter.Add("Id", id);
                parameter.Add("Name", dbType:DbType.AnsiString, direction: ParameterDirection.Output,size:40);
                parameter.Add("Email", dbType: DbType.AnsiString, direction: ParameterDirection.Output, size: 60);
                // return connection.QueryFirstOrDefault<User>("HG_GetUserById", new{Id = id}, commandType: CommandType.StoredProcedure);
                connection.Execute("HG_GetUserById", parameter, commandType: CommandType.StoredProcedure);
                return new User
                {
                    Name = parameter.Get<string>("Name"),
                    Email = parameter.Get<string>("Email")
                };
            }
        }

        public int GetNumberOfUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<int>("SELECT dbo.CONTA_LINHAS('user')", commandType: CommandType.Text);
            }
        }
    }
}
