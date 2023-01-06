using CarRentalSystem.Context;
using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalSystem.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DapperContext _context;
        public CarRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddCarreg(CarModel carModel)
        {

            int result = 0;
            var query = @"insert into carreg(carno,company,model,available)
                        values(@carno,@company,@model,@available)
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, carModel);
                return result;
            }
        }

        public async Task<int> UpdateCarreg(CarModel carModel)
        {
            int result = 0;
            var query = @"update carreg set carno=@carno, company=@company,
                        model=@model, available=@available where id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, carModel);
                return result;
            }
        }

        public async Task<IEnumerable<CarModel>> CarDetails()
        {
            var query = "SELECT * FROM carreg";
            using (var connection = _context.CreateConnection())
            {
                var carModel = await connection.QueryAsync<CarModel>(query);
                return carModel.ToList();
            }
        }

        public async Task<int> DeleteCarreg(int id)
        {
            int result = 0;
            var query = @" delete from carreg where id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }

        public async Task<CarModel> GetCarregById(int id)
        {
            var query = @"select * from carreg where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var carModels = await connection.QueryAsync<CarModel>(query, new { id = id });
                return carModels.FirstOrDefault();
            }
        }

    }
}
