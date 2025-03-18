namespace DiceGame;

public static class CheckingInputData
{
    private static bool CheckInputsCount(string[] diceConfiguration)
    {
        if (diceConfiguration.Length <= 3) ClosingProgram.CloseProgram();
        
        return true;
    }

    public static int CheckInputValues(string value)
    {
        if(int.TryParse(value, out int intValue)) return intValue;
        
        ClosingProgram.CloseProgram();
        
        return 0;
    }
    
    
}