namespace csvviewer.Interfaces;

public class ResultOrError<T>
{
    public bool Success { get; }
    public T Result { get; }
    public string ErrorMessage { get; }

    public ResultOrError(bool success, T result, string errorMessage)
    {
        Success = success;
        Result = result;
        ErrorMessage = errorMessage;
    }
}