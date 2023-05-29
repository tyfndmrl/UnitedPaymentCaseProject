using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitedPayment.Integration.NVI.Services.Interfaces;
using UnitedPayment.Service.Services.Interfaces;

namespace UnitedPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //[HttpPost]
        //public async Task<IActionResult> TransactionPost(TransactionRequestModel model)
        //{
        //    var result = await _TransactionService.AddAsync<TransactionRequestModel, TransactionResponseModel>(model);
        //    return CreatedAtAction("GetById", new { id = result.Id }, result);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, TransactionRequestModel model)
        //{
        //    var result = await _TransactionService.UpdateAsync<TransactionRequestModel, TransactionResponseModel>(id, model);
        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _TransactionService.GetByIdAsync<TransactionResponseModel>(id);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _TransactionService.GetAllAsync<TransactionResponseModel>();
        //    return Ok(result);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionService.DeleteAsync(id);
            return Ok();
        }
    }
}
