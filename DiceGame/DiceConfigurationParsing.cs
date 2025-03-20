namespace DiceGame;

public class DiceConfigurationParsing
{
    public static List<List<int>> ParseInput(string[] diceConfiguration)
    {
        CheckingInputData.CheckStartInputsCount(diceConfiguration);
        
        List<List<int>> resultDiceConfiguration = [];
        
        foreach (var dice in diceConfiguration)
        {
            string[] diceString = dice.Split(",");

            List<int> resultDice = CheckingInputData.CheckStartInputValues(diceString);
            
            resultDiceConfiguration.Add(resultDice);
        }

        return resultDiceConfiguration;
    }
}