namespace DiceGame;

public static class CheckingInputData
{
    public static bool CheckInputsCount(string[] diceConfiguration)
    {
        if (diceConfiguration.Length <= 3) ClosingProgram.CloseProgram();
        
        return true;
    }

    public static List<int> CheckInputValues(string[] dice)
    {
        List<int> resultValues = [];
        foreach (var value in dice)
        {
            if(int.TryParse(value, out int intValue)) resultValues.Add(intValue);
            else
            {
                ClosingProgram.CloseProgram();
            }
        }
        return resultValues;
    }
}