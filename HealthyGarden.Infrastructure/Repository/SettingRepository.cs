using System.Data;
using System.Data.SqlClient;
using Dapper;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace HealthyGarden.Infrastructure.Repository
{
    public class SettingRepository : ISettingRepository
    {
        private readonly string _connectionString;

        public SettingRepository(IOptions<ConnectionStringConfig> options)
        {
            _connectionString = options.Value.ConnectionSqlServer;
        }

        public Setting Insert(Setting entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_InsertSettings", new
                {
                    entity.GardenId,
                    entity.IsAutomatic,
                    entity.MinimumMoisture,
                    entity.MaximumMoisture,
                    entity.MinimumTemperature,
                    entity.MaximumTemperature
                }, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public Setting GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Setting>("p_HG_GetSettingsByID", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public Setting Update(Setting entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_UpdateSettingsByID", new
                {
                    entity.GardenId,
                    entity.IsAutomatic,
                    entity.MinimumMoisture,
                    entity.MaximumMoisture,
                    entity.MinimumTemperature,
                    entity.MaximumTemperature
                }, commandType: CommandType.StoredProcedure);

                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("p_HG_DeleteSettingsByID", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
