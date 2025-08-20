public class ResponseDataModel<T>
{
    public T? Data { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Status { get; set; }
    public string? ErrorType { get; set; }
    public int StatusCode { get; set; }
}


