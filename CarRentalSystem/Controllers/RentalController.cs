using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository rentalRepository;
        public RentalController(IRentalRepository rentalRepository)
        {
            this.rentalRepository = rentalRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            try
            {
                var result = await rentalRepository.GetCarregById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDetails(RentalModel model)
        {
            try
            {
                var result = await rentalRepository.AddCarreg(model);
                return StatusCode(200, "Data Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
