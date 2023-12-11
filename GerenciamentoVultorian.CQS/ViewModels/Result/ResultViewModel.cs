using GerenciamentoVultorian.Domain.Enums;

namespace GerenciamentoVultorian.CQS.ViewModels.Result;

public class ResultViewModel<T>
{
    public T Result { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public StatusCodeEnum StatusCode { get; set; }

    public ResultViewModel(T result, StatusCodeEnum statusCode)
    {
        Result = result;
        Success = result != null;
        StatusCode = statusCode;
    }

    public ResultViewModel<T> AddMessage(string message)
    {
        Message = message;

        return this;
    }
    public ResultViewModel<T> AddMessages(List<string> messages)
    {
        messages.ForEach(m =>
            Message += m
        );

        return this;
    }
}