using CarRentalSystem.Context;
using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Dapper;

namespace CarRentalSystem.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DapperContext _context;
        public RentalRepository(DapperContext context)
        {
            _context= context;
        }

        public async Task<int> AddCarreg(RentalModel rentalModel)
        {
            int result = 0;
            var query = @"insert into rental(carid,custid,fee,sdate,edate) values(@carid,@custid,@fee,@sdate,@edate)";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.QueryFirstOrDefaultAsync<int>(query, rentalModel);
                return result;
            }
        }

        public async Task<RentalModel> GetCarregById(int id)
        {
            var query = @"select c.carno,r.custid,r.fee,r.sdate,r.edate,c.available
                        from carreg c
                        LEFT JOIN  Rental r
                        on  c.id=r.carid
                        where c.id=@id";
            using (var connection = _context.CreateConnection())
            {
               var carrental = await connection.QuerySingleAsync<RentalModel>(query, new { id=id});
                return carrental;
            }
        }
    }
}
