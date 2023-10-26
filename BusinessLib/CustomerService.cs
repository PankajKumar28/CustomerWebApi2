using DataContract;
using DataLib.DBContext;
using DataLib.Entity;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using System.Linq;

namespace BusinessLib
{
    public class CustomerService : ICustomerService
    {
        private readonly DBContextProvider _dbContext;
        public CustomerService(DBContextProvider dbContext)
        {
            _dbContext = dbContext;
        }
        public ApiResult<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            try
            {
                Customers customer = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == customerDto.CustomerId);
                if (customer != null)
                {
                    customer.FullName = customerDto.FullName;
                    customer.DOB = customerDto.DOB;
                    customer.DateModified = DateTime.UtcNow;
                    _dbContext.Entry(customer).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                else
                {
                    customer = new Customers() { CustomerId = new Guid(), FullName = customerDto.FullName, DOB = customerDto.DOB, DateAdded = DateTime.UtcNow };
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                    customerDto.CustomerId = customer.CustomerId;
                }

                return new ApiResult<CustomerDto>(true, ApiResultStatusCode.Success, customerDto, ResponseMessages.SuccessMessage);
            }
            catch (Exception ex)
            {

                return new ApiResult<CustomerDto>(false, ApiResultStatusCode.ServerError, customerDto, ex.Message);
            }
        }
        public ApiResult<CustomerDto> PatchCustomerDOB(Guid Id, DateTime DOB)
        {
            try
            {
                Customers customer = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == Id);
                if (customer != null)
                {
                    customer.DOB = DOB;
                    customer.DateModified = DateTime.UtcNow;
                    _dbContext.Entry(customer).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return new ApiResult<CustomerDto>(true, ApiResultStatusCode.Success, new CustomerDto() { CustomerId = customer.CustomerId, FullName = customer.FullName, DOB = customer.DOB }, ResponseMessages.SuccessMessage);
                }
                else
                {
                    return new ApiResult<CustomerDto>(false, ApiResultStatusCode.Success, null, ResponseMessages.NoDataFound);
                }
            }
            catch (Exception ex)
            {

                return new ApiResult<CustomerDto>(false, ApiResultStatusCode.ServerError, null, ex.Message);
            }
        }

        public ApiResult<CustomerDto> FindCustomerById(Guid Id)
        {
            try
            {
                Customers customer = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == Id);
                if (customer != null)
                {
                    return new ApiResult<CustomerDto>(true, ApiResultStatusCode.Success, new CustomerDto() { CustomerId = customer.CustomerId, FullName = customer.FullName, DOB = customer.DOB }, ResponseMessages.SuccessMessage);
                }
                else
                    return new ApiResult<CustomerDto>(true, ApiResultStatusCode.Success, null, ResponseMessages.NoDataFound);
            }
            catch (Exception ex)
            {
                return new ApiResult<CustomerDto>(false, ApiResultStatusCode.ServerError, null, ex.Message);
            }

        }
        public ApiResult<List<CustomerDto>> FindCustomerByAge(int age)
        {
            try
            {
                List<CustomerDto> lstCustomer = new List<CustomerDto>();

                List<Customers> customerList = _dbContext.Customers.Where(a => DateTime.UtcNow.Year - a.DOB.Year == age).ToList();
                foreach (var item in customerList)
                {
                    CustomerDto cust = new CustomerDto()
                    {
                        CustomerId = item.CustomerId,
                        FullName = item.FullName,
                        DOB = item.DOB
                    };
                    lstCustomer.Add(cust);
                }

                return new ApiResult<List<CustomerDto>>(true, ApiResultStatusCode.Success, lstCustomer, ResponseMessages.Fetched);

            }
            catch (Exception ex)
            {
                return new ApiResult<List<CustomerDto>>(false, ApiResultStatusCode.ServerError, null, ex.Message);
            }

        }
        public ApiResult<List<CustomerDto>> GetCustomers()
        {
            try
            {
                List<CustomerDto> lstCustomer = new List<CustomerDto>();

                List<Customers> customerList = _dbContext.Customers.ToList();
                foreach (var item in customerList)
                {
                    CustomerDto cust = new CustomerDto()
                    {
                        CustomerId = item.CustomerId,
                        FullName = item.FullName,
                        DOB = item.DOB
                    };
                    lstCustomer.Add(cust);
                }

                return new ApiResult<List<CustomerDto>>(true, ApiResultStatusCode.Success, lstCustomer, ResponseMessages.Fetched);

            }
            catch (Exception ex)
            {
                return new ApiResult<List<CustomerDto>>(false, ApiResultStatusCode.ServerError, null, ex.Message);
            }

        }
    }
}