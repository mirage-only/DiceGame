namespace DiceGame;

public class InputMethods
{
    public static string ThePlayerGuessesTheNumber()
    {
        Console.WriteLine("\n Try to guess my selection:" +
                          "\n 0-0 \n 1-1  \n x-exit \n ?-help");
        
        string? input = Console.ReadLine();
        
        string correctInput = CheckingInputData.CheckMenuChooseToValidate(input);
        
        return correctInput;
    }

    public static string TheEnterHisDice(List<List<int>> dices)
    {
        Console.WriteLine("Make choose of dice:");

        for (int i = 0; i < dices.Count; i++)
        {
            Console.WriteLine(i + ": " + string.Join(", ", dices[i]));
        } 
        
        Console.WriteLine("x-exit \n?-help");
        
        string? input = Console.ReadLine();
        
        string? correctInput = CheckingInputData.CheckDiceChooseToValidate(input, dices);
        
        return correctInput;
    }

    public static string EnterValueToDice()
    {
        Console.WriteLine("\n Add your number modulo 6:" +
                          " \n 0-0 \n 1-1 \n 2-2 \n 3-3 \n 4-4 \n 5-5 \n x-exit \n ?-help");

        string? userInput = Console.ReadLine();
        
        string? correctInput = CheckingInputData.CheckPlayersChoice(userInput);
        
        return correctInput;
    }
}