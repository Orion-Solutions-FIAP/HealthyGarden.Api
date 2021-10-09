using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace HealthyGarden.Infrastructure.Repository
{
    public class HistoricRepository : IHistoricRepository
    {
        private readonly string _connectionString;

        public HistoricRepository(IOptions<ConnectionStringConfig> options)
        {
            _connectionString = options.Value.ConnectionSqlServer;
        }

        public Historic Insert(Historic entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameter = new DynamicParameters();
                parameter.Add("GardenId", entity.GardenId, DbType.Int32);
                parameter.Add("IrrigationDate", entity.IrrigationDate, DbType.DateTime);
                parameter.Add("Moisture", entity.Moisture, DbType.Int16);
                parameter.Add("Temperature", entity.Temperature, DbType.Int16);
                connection.Execute("p_HG_InsertHistoric", parameter, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public Historic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Historic Update(Historic entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Historic> GetByGardenId(int gardenId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Historic>("p_HG_GetHistoricByIdGarden", new { GardenId = gardenId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
