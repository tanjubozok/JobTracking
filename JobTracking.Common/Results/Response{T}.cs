namespace JobTracking.Common.Results;

public class Response<T> : Response, IResponse<T>
{
    public Response(ResponseType responseType)
        : base(responseType)
    {
    }

    public Response(ResponseType responseType, string message)
        : base(responseType, message)
    {
    }

    public Response(ResponseType responseType, T data)
        : base(responseType)
    {
        Data = data;
    }

    public Response(ResponseType responseType, T data, string message)
        : base(responseType, message)
    {
        Data = data;
    }

    public T Data { get; set; }
}