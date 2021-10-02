using System.Data;
using System.Data.SqlClient;
using Dapper;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace HealthyGarden.Infrastructure.Repository
{
    public class GardenRepository : IGardenRepository
    {
        private readonly string _connectionString;

        public GardenRepository(IOptions<ConnectionStringConfig> options)
        {
            _connectionString = options.Value.ConnectionSqlServer;
        }

        public Garden Insert(Garden entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("UserId", entity.UserId, DbType.Int32);
                parameter.Add("TemperatureStatus", entity.TemperatureStatus, DbType.Int16);
                parameter.Add("MoistureStatus", entity.MoistureStatus, DbType.Int16);
                parameter.Add("Name", entity.Name, DbType.AnsiString, size: 40);
                parameter.Add("Description", entity.Description, DbType.AnsiString, size: 150);
                parameter.Add("NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("p_HG_InsertGarden", parameter, commandType: CommandType.StoredProcedure);
                entity.Id = parameter.Get<int>("NewId");
                return entity;
            }
        }

        public Garden GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); 
                var garden  = connection.QueryFirstOrDefault<Garden>("p_HG_GetGardenByID", new { Id = id }, commandType: CommandType.StoredProcedure);
                return garden;
            }
        }

        public Garden Update(Garden entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_UpdateGardenByID", new { entity.Id, entity.TemperatureStatus, entity.MoistureStatus, entity.Name, entity.Description }, 
                    commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_DeleteGardenByID", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
