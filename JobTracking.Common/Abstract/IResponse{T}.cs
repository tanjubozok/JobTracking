namespace JobTracking.Common.Abstract;

public interface IResponse<T> : IResponse
{
    T Data { get; set; }
}