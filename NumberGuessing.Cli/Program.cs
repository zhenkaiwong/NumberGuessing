using NumberGuessing.Library;

Log.PrintWelcome();
Log.PrintMenu();
Log.PrintPendingUserInputGameMode();
string? input = Console.ReadLine();
int mode = 0;
if (string.IsNullOrEmpty(input) || !int.TryParse(input, out mode) || mode < 1 || mode > 3)
{
    Console.WriteLine($"\"{input}\" is not a correct game mode to choose");
    return;
}

Log.PrintConfirmGameMode((GameMode)mode);
Log.PrintGameStart();

Game game = new Game((GameMode)mode);
int attemptCount = 0;
while (game.ChancesLeft > 0)
{
    Log.PrintPendingUserInputGuess();
    string? rawGuess = Console.ReadLine();
    if (string.IsNullOrEmpty(rawGuess) || !int.TryParse(rawGuess, out int guess) || guess < 1 || guess > 100)
    {
        Console.WriteLine($"Your guess \"{rawGuess}\" doesn't seems to fall into the range of 1 to 100");
        continue;
    }
    GameState state = game.Play(guess);
    attemptCount++;
    if (state == GameState.Win)
    {
        Log.PrintWin(attemptCount);
        return;
    }

    if (state == GameState.End)
    {
        Log.PrintLose();
        return;
    }

    if (state == GameState.Nah)
    {
        Log.PrintIncorrectGuess(game.ShouldBeGreater, guess);
    }
}