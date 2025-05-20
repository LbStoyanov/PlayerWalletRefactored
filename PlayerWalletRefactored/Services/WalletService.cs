using PlayerWallet.Models;


namespace PlayerWalletRefactored.Services;

public class WalletService
{
    public decimal Balance { get; private set; } = 0m;

    public TransactionResult Deposit(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.CreateFailure("Deposit amount must be positive.");

        Balance += amount;
        return TransactionResult.CreateSuccess($"Deposited ${amount}. New balance: ${Balance}");
    }

    public TransactionResult Withdraw(decimal amount)
    {
        if (amount <= 0)
            return TransactionResult.CreateFailure("Withdrawal amount must be positive.");

        if (amount > Balance)
            return TransactionResult.CreateFailure($"Insufficient balance. Current: ${Balance}");

        Balance -= amount;
        return TransactionResult.CreateSuccess($"Withdrew ${amount}. New balance: ${Balance}");
    }

    public void ApplyGameResult(decimal bet, decimal win)
    {
        Balance -= bet;
        Balance += win;
    }
}

