namespace Example.Core.Models
{
    public class ResponseModel : IResponseModel
    {
        public ResponseBody Data { get; set; }
        public string[] Errors { get; set; }
    }
}
