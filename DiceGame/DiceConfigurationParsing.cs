namespace DiceGame;

public class DiceConfigurationParsing
{
    public List<List<int>> ParseInput(string[] diceConfiguration)
    {
        CheckingInputData.CheckInputsCount(diceConfiguration);
        /*int diceCount = diceConfiguration.Length;*/
        
        List<List<int>> resultDiceConfiguration = [];
        
        foreach (var dice in diceConfiguration)
        {
            string[] diceString = dice.Split(",");

            List<int> resultDice = CheckingInputData.CheckInputValues(diceString);
            
            resultDiceConfiguration.Add(resultDice);
        }

        return resultDiceConfiguration;
    }
}