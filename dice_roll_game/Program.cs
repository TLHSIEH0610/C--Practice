var mainClass = new MainClass();
mainClass.playGame();

public class MainClass
{

    private int _tries = 3;
    private int diceNum = new Random().Next(1, 6);
    public void playGame()
    {
        do
        {
            Console.WriteLine("Doce rolled. Guess what number is shows in 3 tries.");
            //if number is invalid, show “Incorrect input”  “Enter number:”
            string input = Console.ReadLine();
            int gussNumber;
            if (!InputValidator(input, out gussNumber))
            {
                Console.WriteLine("Incorrect input");
                continue;
            }
            //check guess
            bool isSuccessful = GussResult(gussNumber);
            if (isSuccessful)
            {
                break;
            }
            else
            {
                _tries--;
                if (_tries == 0)
                {
                    Console.WriteLine("You Lose");
                }
            }


        } while (_tries > 0);
    }

    private bool InputValidator(string input, out int gussNumber)
    {
        bool isValid = int.TryParse(input, out gussNumber) && input != "";
        return isValid;
    }

    private bool GussResult(int gussNumber)
    {
        if (diceNum == gussNumber)
        {
            Console.WriteLine("You Win");
            return true;
        }
        Console.WriteLine("Wrong number");
        return false;
    }
}