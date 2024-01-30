namespace JobTracking.Common.ComplexTypes;

public enum ResponseType
{
    Success = 1,
    Error,
    SaveError,
    NotFound,
    TryCatch,
    SameRecord
}
