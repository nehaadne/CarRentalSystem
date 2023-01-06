using CarRentalSystem.Model;

namespace CarRentalSystem.Repository.Interface
{
    public interface ICarRepository
    {
         Task<int> AddCarreg(CarModel carModel);
         Task<int> UpdateCarreg(CarModel carModel);
         Task<int> DeleteCarreg(int id);
         Task<CarModel> GetCarregById(int id);
         Task<IEnumerable<CarModel>> CarDetails();





    }
}
