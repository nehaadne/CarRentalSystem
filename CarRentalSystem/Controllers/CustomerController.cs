using CarRentalSystem.Model;
using CarRentalSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerModel customerModel)
        {
            try
            {
                var result = await customerRepository.AddCustomer(customerModel);
                return StatusCode(200, "Data Added Successfully...!");


            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerModel customerModel)
        {
            try
            {
                var result = await customerRepository.UpdateCustomer(customerModel);
                return StatusCode(200, "data Updated successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var result = await customerRepository.Customerdetails();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                var result = await customerRepository.DeleteCustomer(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await customerRepository.GetCustomerById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }

}
