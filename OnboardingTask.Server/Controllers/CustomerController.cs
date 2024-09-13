using Microsoft.AspNetCore.Mvc;
using OnboardingTask.Server.Services;
using OnboardingTask.Server.ViewModels;


namespace OnboardingTask.Server.Controllers
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

        [HttpGet]
        [Produces(typeof(IEnumerable<CustomerViewModel>))]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();

            if (customers == null)
            {                                                                                                                                                                                                                                                                                                                                                                             
                return NotFound();
            }

            return Ok(customers);

        }

        [HttpGet("{id}")]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);

            if (customer == null) 
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerViewModel), 200)]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerService.CreateCustomer(request);

            return CreatedAtAction("GetCustomer", new { id = customer.Customer_Id }, customer);
          
        }

        [HttpPut("{id}")]
        [Produces(typeof(CustomerViewModel))]

        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = await _customerService.UpdateCustomer(id, request);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
