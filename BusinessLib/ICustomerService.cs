using DataContract;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib
{
    public interface ICustomerService
    {
        ApiResult<CustomerDto> FindCustomerById(Guid Id);
        ApiResult<List<CustomerDto>> FindCustomerByAge(int age);
        ApiResult<List<CustomerDto>> GetCustomers();
        ApiResult<CustomerDto> AddCustomer(CustomerDto customerDto);
        ApiResult<CustomerDto> PatchCustomerDOB(Guid Id, DateTime DOB);
    }
}
