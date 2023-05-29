using Microsoft.AspNetCore.Mvc;
using UnitedPayment.DDD.Entities;
using UnitedPayment.DTO.Dto.Customer.RequestModels;
using UnitedPayment.DTO.Dto.Customer.ResponseModels;
using UnitedPayment.DTO.Models.Results;
using UnitedPayment.Integration.NVI.Services.Interfaces;
using UnitedPayment.Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitedPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model)
        {
            var response = new ResponseModel<CustomerResponseModel>();
            var result = await _customerService.AddAsync(model);
            response.Data = result;

            return CreatedAtAction("GetById", new { id = result.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerRequestModel model)
        {
            var response = new ResponseModel<CustomerResponseModel>();
            var result = await _customerService.UpdateAsync<CustomerRequestModel, CustomerResponseModel>(id, model);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseModel<CustomerResponseModel>();
            var result = await _customerService.GetByIdAsync<CustomerResponseModel>(id);
            response.Data = result;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ResponseModel<IEnumerable<CustomerResponseModel>>();
            var result = await _customerService.GetAllAsync<CustomerResponseModel>();
            response.Data = result;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok(new ResponseModel(true));
        }
    }
}
