using CarRentalSystem.Context;
using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Dapper;

namespace CarRentalSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddCustomer(CustomerModel customerModel)
        {
            int result = 0;
            var query = @"insert into customer(custname,custaddress,mobile) 
                        values(@custname,@custaddress,@mobile)
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, customerModel);
                return result;  
            }
        }
        public async Task<IEnumerable<CustomerModel>> Customerdetails()
        {
            var query = @"select * from customer";
            using (var con = _context.CreateConnection())
            {
                var custmodels = await con.QueryAsync<CustomerModel>(query);
                return custmodels.ToList();
            }
        }

        public async Task<int> DeleteCustomer(int id)
        {
            int result = 0;
            var query = @"delete from customer where id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var query = @"select * from customer where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var carModels = await connection.QueryAsync<CustomerModel>(query, new { id = id });
                return carModels.FirstOrDefault();
            }
        }

        public async Task<int> UpdateCustomer(CustomerModel customerModel)
        {
            int result = 0;
            var query = @"update customer set custname=@custname,
                        custaddress=@custaddress,mobile=@mobile where id=@id";
            using (var con = _context.CreateConnection())
            {
                result = await con.QuerySingleAsync<int>(query, customerModel);
                return result;
            }
        }
    }
}
