using GerenciamentoVultorian.Domain.Enums;

namespace GerenciamentoVultorian.CQS.ViewModels.Result;

public class ResultViewModel<T>
{
    public T Result { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public StatusCodeEnum StatusCode { get; set; }

    public ResultViewModel(T result, StatusCodeEnum statusCode, bool success = true)
    {
        Result = result;
        Success = success;
        StatusCode = statusCode;
    }

    public ResultViewModel<T> AddMessage(string message)
    {
        Message = message;

        return this;
    }
}