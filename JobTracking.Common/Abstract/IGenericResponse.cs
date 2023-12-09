namespace JobTracking.Common.Abstract;

public interface IGenericResponse<T> : IResponse
{
    T Data { get; set; }
}