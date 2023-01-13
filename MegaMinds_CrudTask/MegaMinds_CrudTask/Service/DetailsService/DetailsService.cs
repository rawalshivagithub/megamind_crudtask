using MegaMinds_CrudTask.DataContext;
using MegaMinds_CrudTask.Models;
using MegaMinds_CrudTask.Service.IDetailsInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MegaMinds_CrudTask.Service.DetailsService
{
    public class DetailsService : IDetailsService
    {
        private readonly DataContextClass _dbContext;

        public DetailsService(DataContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddDetails(Details details)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Name", details.Name));
            parameter.Add(new SqlParameter("@Email", details.Email));
            parameter.Add(new SqlParameter("@PhoneNumber", details.PhoneNumber));
            parameter.Add(new SqlParameter("@Address", details.Address));
            parameter.Add(new SqlParameter("@StateId", details.StateId));
            parameter.Add(new SqlParameter("@CityId", details.CityId));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewDetails @Name, @Email, @PhoneNumber, @Address , @StateId, @CityId", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteDetails(int Id)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteDetailsByID {Id}"));
        }

        public async Task<Details> GetDetailsById(int Id,Details details)
        {

            var param = new SqlParameter("@Id", Id);
            await Task.Run(() => _dbContext.Details.FromSqlRaw(@"exec GetDetailsByID @Id", param).ToListAsync());
            return details;
        }

        public async Task<List<Details>> GetDetailsList()
        {
            return await _dbContext.Details.FromSqlRaw<Details>("GetDetailsList").ToListAsync();
        }

        public async Task<int> UpdateDetails(Details details)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Id", details.Id));
            parameter.Add(new SqlParameter("@Name", details.Name));
            parameter.Add(new SqlParameter("@PhoneNumber", details.PhoneNumber));
            parameter.Add(new SqlParameter("@Address", details.Address));
            parameter.Add(new SqlParameter("@StateId", details.StateId));
            parameter.Add(new SqlParameter("@CityId", details.CityId));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateDetails @Id, @Name, @PhoneNumber, @Address, @StateId, @CityId", parameter.ToArray()));
            return result;
        }
    }
}
