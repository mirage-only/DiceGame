namespace DiceGame;

public static class CheckingInputData
{
    public static bool CheckStartInputsCount(string[] diceConfiguration)
    {
        if (diceConfiguration.Length < 3) ClosingProgram.CloseProgramWithErrors();
        
        return true;
    }

    public static List<int> CheckStartInputValues(string[] dice)
    {
        List<int> resultValues = [];
        
        foreach (var value in dice)
        {
            if(int.TryParse(value, out int intValue) && dice.Length == 6) resultValues.Add(intValue);
            else
            {
                ClosingProgram.CloseProgramWithErrors();
            }
        }
        
        if(Array.Exists(resultValues.ToArray(), value => value <= 0)) ClosingProgram.CloseProgramWithErrors();
        
        return resultValues;
    }

    public static string CheckMenuChooseToValidate(string inputLine)
    {
        List<string> choices = ["0", "1", "x", "?"];

        while (!choices.Contains(inputLine))
        {
            Console.WriteLine("Incorrect input, try again...");

            inputLine = Console.ReadLine();
        }

        return inputLine;
    }
    
    public static string? CheckDiceChooseToValidate(string? inputLine, List<List<int>> dices)
    {
        List<string?> choices = ["x", "?"];

        for (int i = 0; i < dices.Count; i++)
        {
            choices.Add(i.ToString());    
        }
        
        while (!choices.Contains(inputLine))
        {
            Console.WriteLine("Incorrect input, try again...");

            inputLine = Console.ReadLine();
        }

        return inputLine;
    }
    
    public static string? CheckPlayersChoice(string? inputLine)
    {
        List<string?> choices = ["0", "1","2", "3", "4", "5", "x", "?"];
        
        while (!choices.Contains(inputLine))
        {
            Console.WriteLine("Incorrect input, try again...");

            inputLine = Console.ReadLine();
        }

        return inputLine;
    }
}