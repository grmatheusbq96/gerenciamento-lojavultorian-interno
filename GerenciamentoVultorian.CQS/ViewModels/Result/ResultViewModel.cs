namespace GerenciamentoVultorian.CQS.ViewModels.Result;

public class ResultViewModel<T>
{
    public T Result { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public string ExceptionMessage { get; set; }

    public ResultViewModel(T result, bool success = true)
    {
        Result = result;
        Success = success;
    }

    public ResultViewModel<T> AddMessage(string message, string exceptionMessage = "")
    {
        Message = message;
        ExceptionMessage = exceptionMessage;

        return this;
    }
}