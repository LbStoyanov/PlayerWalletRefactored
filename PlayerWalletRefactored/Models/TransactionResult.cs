namespace PlayerWallet.Models;

public class TransactionResult
{
    public bool Success { get; }
    public string Message { get; }

    private TransactionResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static TransactionResult CreateSuccess(string message) => new(true, message);
    public static TransactionResult CreateFailure(string message) => new(false, message);
}
