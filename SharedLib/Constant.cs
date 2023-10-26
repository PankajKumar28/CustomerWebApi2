using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SharedLib
{
    public static class ResponseMessages
    {
        public static string SuccessMessage = "Request is successfully processed";
        public static string ErrorMessage = "Some error occured.Please contact to administrator";
        public static string ValidationFailed = "Your request is not valid";
        public static string NoDataFound = "No Data Found";
        public static string Fetched = "Successfully Fetched Data";
    }
    public enum ApiResultStatusCode
    {
        [Display(Name = "The operation was carried out successfully")]
        Success = 200,

        [Display(Name = "Error on server")]
        ServerError = 500,

        [Display(Name = "Sending parameters are not valid")]
        BadRequest = 400,

        [Display(Name = "Not found")]
        NotFound = 404,

        [Display(Name = "The list is empty")]
        ListEmpty = 304,

        [Display(Name = "Error occur while processing")]
        LogicError = 5,

        [Display(Name = "Identity error")]
        UnAuthorized = 401
    }
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public ApiResultStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToString();
        }
    }
    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }
    }
}