using CarRentalSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonDDController : ControllerBase
    {
        private readonly ICommonDropDown commonDropDown;
        public CommonDDController(ICommonDropDown commonDropDown)
        {
            this.commonDropDown = commonDropDown;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarno(int id)
        {
            try
            {
                var result = await commonDropDown.GetAllCarnoById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}

