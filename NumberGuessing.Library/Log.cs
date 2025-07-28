namespace NumberGuessing.Library;

public static class Log
{
    public static void PrintWelcome()
    {
        string[] messages = {
            "Welcome to the Number Guessing Game!",
            "I'm thinking of a number between 1 and 100.",
            "You have 5 chances to guess the correct number."
        };
        PrintMessageLine(messages);
    }

    public static void PrintMenu()
    {
        string[] messages = {
            Environment.NewLine,
            "Please select the difficulty level:",
            "1. Easy (10 chances)",
            "2. Medium (5 chances)",
            "3. Hard (3 chances)",
            Environment.NewLine
        };
        PrintMessageLine(messages);
    }

    public static void PrintPendingUserInputGameMode()
    {
        PrintMessage("Enter your choice: ");
    }

    public static void PrintPendingUserInputGuess()
    {
        PrintMessage("Enter your guess: ");
    }

    public static void PrintConfirmGameMode(GameMode mode)
    {
        PrintMessageLine($"Great! You have selecdted the {mode} difficulty level.");
    }

    public static void PrintGameStart()
    {
        PrintMessageLine("Let's start the game!");
    }

    public static void PrintIncorrectGuess(bool greater, int guess)
    {
        PrintMessageLine($"Incorrect! The number is {(greater ? "greater" : "less")} than {guess}");
    }

    public static void PrintWin(int attemptCount)
    {
        PrintMessageLine($"Congratulations! You guessed the correct number in {attemptCount} attempst.");
    }
    public static void PrintLose()
    {
        PrintMessageLine("Uh oh. The game is over.. Maybe try again?");
    }

    private static void PrintMessage(string message)
    {
        Console.Write(message);
    }

    private static void PrintMessageLine(string message)
    {
        Console.WriteLine(message);
    }

    private static void PrintMessageLine(string[] messages)
    {
        foreach (var message in messages)
        {
            PrintMessageLine(message);
        }
    }
}
