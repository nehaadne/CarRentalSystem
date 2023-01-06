using CarRentalSystem.Model;

namespace CarRentalSystem.Repository.Interface
{
    public interface IRentalRepository
    {
        Task<int> AddCarreg(RentalModel rentalModel);          

        Task<RentalModel> GetCarregById(int id);


    }
}
