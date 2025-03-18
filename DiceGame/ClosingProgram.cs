namespace DiceGame;

public static class ClosingProgram
{
    private const string ERROR_INPUT_MESSAGE =
        "Invalid input, you should provide >=3 dice configurations with the same int face's value";
    
    public static void CloseProgram()
    {
        Console.WriteLine(ERROR_INPUT_MESSAGE);
        Environment.Exit(0);
    }
}