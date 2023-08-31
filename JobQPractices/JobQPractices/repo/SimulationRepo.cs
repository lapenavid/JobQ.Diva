using Dapper;
using JobQPractices.Data.ApsimData;
using JobQPractices.Interface;
using JobQPractices.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobQPractices.repo
{
    public class SimulationRepo : ISimulationRepo
    {
        private readonly DapperContext _dapperContext;
        public SimulationRepo(DapperContext dapperContext) {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<jobDetails>> GetSimulationName()
        {
            var query = "SELECT * FROM JobDetails";
            using (var connection = _dapperContext.CreateConnection())
            {
                var details = await connection.QueryAsync<jobDetails>(query);
                return details.ToList();
            }
        }
    }

}

