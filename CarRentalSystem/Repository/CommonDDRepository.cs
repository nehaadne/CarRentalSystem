using CarRentalSystem.Context;
using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Dapper;

namespace CarRentalSystem.Repository
{
    public class CommonDDRepository : ICommonDropDown
    {
        private readonly DapperContext _context;
        public CommonDDRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<CommonDropDown>> GetAllCarnoById(int id)
        {
            var query = @"select id,carno from carreg where id= @id or id=0";
            using (var conn = _context.CreateConnection())
            {
                var custmodels = await conn.QueryAsync<CommonDropDown>(query, new { id = id });
                return custmodels.ToList();
            }
        }
    }
}
