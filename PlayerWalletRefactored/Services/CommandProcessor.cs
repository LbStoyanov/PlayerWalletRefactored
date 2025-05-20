

namespace PlayerWalletRefactored.Services;

public class CommandProcessor
{
    private readonly WalletService _wallet;
    private readonly GameService _game;

    public CommandProcessor(WalletService wallet, GameService game)
    {
        _wallet = wallet;
        _game = game;
    }

    public string Process(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Invalid input.";

        var parts = input.Split(' ');

        if (parts.Length < 2 || !decimal.TryParse(parts[1], out decimal amount))
            return "Please provide a command followed by a numeric amount.";

        var command = parts[0].ToLower();

        return command switch
        {
            "deposit" => _wallet.Deposit(amount).Message,
            "withdraw" => _wallet.Withdraw(amount).Message,
            "bet" => HandleBet(amount),
            _ => "Unknown command."
        };

    }

    private string HandleBet(decimal amount)
    {
        if (_wallet.Balance < amount)
            return $"Insufficient balance. Your current balance is: ${_wallet.Balance}";

        var gameResult = _game.Play(amount);
        _wallet.ApplyGameResult(amount, gameResult.WinAmount);

        return $"{gameResult.Message} Your balance is now: ${_wallet.Balance}";
    }
}

