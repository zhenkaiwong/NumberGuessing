namespace NumberGuessing.Library;

public class Game
{
    public int ChancesLeft { get; private set; }

    public bool ShouldBeGreater { get; private set; }

    private int? Answer { get; set; }

    public Game(GameMode mode)
    {
        switch (mode)
        {
            case GameMode.Easy:
                ChancesLeft = 10;
                break;
            case GameMode.Medium:
                ChancesLeft = 5;
                break;
            case GameMode.Hard:
                ChancesLeft = 3;
                break;
            default:
                throw new InvalidDataException($"Value \"{mode}\" is not a proper game mode");
        }

        Answer = (new Random()).Next(1, 101);
    }

    public GameState Play(int guess)
    {
        ChancesLeft--;
        if (guess == Answer)
        {
            return GameState.Win;
        }
        if (ChancesLeft != 0)
        {
            ShouldBeGreater = guess < Answer;
            return GameState.Nah;
        }
        return GameState.End;
    }
}
