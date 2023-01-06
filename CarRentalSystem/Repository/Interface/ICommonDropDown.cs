using CarRentalSystem.Model;

namespace CarRentalSystem.Repository.Interface
{
    public interface ICommonDropDown
    {
        public Task<List<CommonDropDown>> GetAllCarnoById(int id);

    }
}
