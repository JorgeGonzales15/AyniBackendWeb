namespace AyniBackendWeb.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    protected BaseResponse(string message, T resource)
    {
        Message = message;
        Resource = resource;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }

}