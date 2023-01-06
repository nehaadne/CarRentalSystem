using CarRentalSystem.Model;

namespace CarRentalSystem.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomer(CustomerModel customerModel);
        Task<int> UpdateCustomer(CustomerModel customerModel);
        Task<int> DeleteCustomer(int id);
        Task<CustomerModel> GetCustomerById(int id);
        Task<IEnumerable<CustomerModel>> Customerdetails();
    }
}
