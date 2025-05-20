namespace PlayerWalletRefactored.Models;

public class GameResult
{
    public decimal WinAmount { get; }
    public string Message { get; }
    public bool IsValid { get; }

    private GameResult(decimal winAmount, string message, bool isValid)
    {
        WinAmount = winAmount;
        Message = message;
        IsValid = isValid;
    }

    public static GameResult Valid(decimal winAmount, string message) =>
        new(winAmount, message, true);

    public static GameResult Invalid(string message) =>
        new(0m, message, false);
}

