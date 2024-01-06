
// var mainClass = new Dice();
// mainClass.playGame();

// public class Dice
// {
//     private const int SideCount = 6;
//     private int _tries = 3;
//     private readonly Random _random;

//     public Dice(Random random)
//     {
//         _random = random;
//     }

//     public int Roll() => _random.Next(1, SideCount);
//     public void playGame()
//     {
//         do
//         {
//             Console.WriteLine("Doce rolled. Guess what number is shows in 3 tries.");
//             //if number is invalid, show “Incorrect input”  “Enter number:”
//             string input = Console.ReadLine();
//             int gussNumber;
//             if (!InputValidator(input, out gussNumber))
//             {
//                 Console.WriteLine("Incorrect input");
//                 continue;
//             }
//             //check guess
//             bool isSuccessful = GussResult(gussNumber);
//             if (isSuccessful)
//             {
//                 break;
//             }
//             else
//             {
//                 _tries--;
//                 if (_tries == 0)
//                 {
//                     Console.WriteLine("You Lose");
//                 }
//             }


//         } while (_tries > 0);
//     }

//     private bool InputValidator(string input, out int gussNumber)
//     {
//         bool isValid = int.TryParse(input, out gussNumber) && input != "";
//         return isValid;
//     }

//     private bool GussResult(int gussNumber)
//     {
//         if (diceNum == gussNumber)
//         {
//             Console.WriteLine("You Win");
//             return true;
//         }
//         Console.WriteLine("Wrong number");
//         return false;
//     }
// }

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);
GameResult gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);

public class GuessingGame
{
    private readonly Dice _dice;
    private const int InitialTries = 3;
    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Doce rolled. Guess what number is shows in {InitialTries} tries.");

        var triesLeft = InitialTries;

        while (triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("Enter a number");
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            Console.WriteLine("Wrong number");
            --triesLeft;
        }

        return GameResult.Loss;

    }

    public static void PrintResult(GameResult gameResult)
    {
        string message = gameResult == GameResult.Victory ? "You Win" : "You lose";
        Console.WriteLine(message);
    }
}

public enum GameResult
{
    Victory, Loss
}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}

public class Dice
{
    private readonly Random _random;
    private const int SideCount = 6;
    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() => _random.Next(1, SideCount + 1);

}