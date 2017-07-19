namespace Example.Core.Models
{
    public interface IResponseModel
    {
        ResponseBody Data { get; set; }
        string[] Errors { get; set; }
    }
}
