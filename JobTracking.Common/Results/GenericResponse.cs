namespace JobTracking.Common.Results;

public class GenericResponse<T> : Response, IGenericResponse<T>
{
    public GenericResponse(ResponseType responseType)
        : base(responseType)
    {
    }

    public GenericResponse(ResponseType responseType, string message)
        : base(responseType, message)
    {
    }

    public GenericResponse(ResponseType responseType, T data)
        : base(responseType)
    {
        Data = data;
    }

    public GenericResponse(ResponseType responseType, T data, string message)
        : base(responseType, message)
    {
        Data = data;
    }

    public T Data { get; set; }
}