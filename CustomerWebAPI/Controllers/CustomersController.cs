using BusinessLib;
using DataContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedLib;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ApiResult<List<CustomerDto>> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomersController>/3fa85f64-5717-4562-b3fc-2c963f66afa6
        [HttpGet("{guid}")]
        public ApiResult<CustomerDto> Get(Guid guid)
        {
            return _customerService.FindCustomerById(guid);
        }
        // GET api/<CustomersController>/5
        [HttpGet("age")]
        public ApiResult<List<CustomerDto>> GetCustomerByAge(int age)
        {
            return _customerService.FindCustomerByAge(age);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ApiResult<CustomerDto> Post([FromBody] CustomerDto data)
        {
            return _customerService.AddCustomer(data);
        }

        [HttpPatch]
        public ApiResult<CustomerDto> Patch(Guid guid, [FromBody] DateTime DOB)
        {
            return _customerService.PatchCustomerDOB(guid, DOB);
        }

        // PUT api/<CustomersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
