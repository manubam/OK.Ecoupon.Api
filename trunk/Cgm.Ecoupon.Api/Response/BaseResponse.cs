namespace Cgm.Ecoupon.Api.Response
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Code = (int)
            ErrorType.Ok;
        }
        public string Message { get; set; }
        public int Code { get; set; }

    }
}