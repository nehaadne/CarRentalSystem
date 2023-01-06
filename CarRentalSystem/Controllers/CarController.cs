using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;
        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCar()
        {
            try
            {
                var carmodel = await carRepository.CarDetails();
                return Ok(carmodel);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await carRepository.GetCarregById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddnewCar(CarModel carmodel)
        {
            var result = await carRepository.AddCarreg(carmodel);
            if (result > 0)
            {
                return StatusCode(200, "Data Added Successfully..!");
            }
            else
                return StatusCode(404, "Something is wrong...!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(CarModel carModel)
        {
            var result = await carRepository.UpdateCarreg(carModel);
            if (result > 0)
            {
                return StatusCode(200, "Data Updated Successfully...!");
            }
            else
                return StatusCode(404, "Record Not Updated");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                var result = await carRepository.DeleteCarreg(id);
                return Ok(result);

            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        
    }
}
