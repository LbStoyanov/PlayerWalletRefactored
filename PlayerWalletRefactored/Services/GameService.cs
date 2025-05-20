
using PlayerWalletRefactored.Abstractions;
using PlayerWalletRefactored.Infrastructure;
using PlayerWalletRefactored.Models;

namespace PlayerWalletRefactored.Services;

public class GameService
{
    private readonly IRandomProvider _random;

    public GameService(IRandomProvider? randomProvider = null)
    {
        _random = randomProvider ?? new RandomProvider();
    }

    public GameResult Play(decimal betAmount)
    {
        if (betAmount < 1 || betAmount > 10)
            return GameResult.Invalid("Bet must be between $1 and $10.");

        var roll = _random.Next(1, 101);
        decimal winAmount = 0;
        string message;

        if (roll <= 50)
        {
            message = "No luck this time!";
        }
        else if (roll <= 90)
        {
            var multiplier = 0.1m + (decimal)_random.NextDouble() * 1.9m;
            winAmount = Math.Round(betAmount * multiplier, 2);
            message = $"Congrats! You won ${winAmount}.";
        }
        else
        {
            var multiplier = 2.0m + (decimal)_random.NextDouble() * 8.0m;
            winAmount = Math.Round(betAmount * multiplier, 2);
            message = $"JACKPOT! You won ${winAmount}!";
        }

        return GameResult.Valid(winAmount, message);
    }
}

