namespace DiceGame;

abstract class Program
{
    public static List<List<int>> dices = [];
    private static void Main(string[] args)
    {
        dices = DiceConfigurationParsing.ParseInput(args);

        List<int> playerChoice = [];

        List<int> computerChoice = [];

        if (PlayingLogic.ChooseWhoStart(dices))
        {
            playerChoice = PlayingLogic.PlayerChooseDice(dices);
            
            dices.Remove(playerChoice);
                
            computerChoice = PlayingLogic.ComputerChooseDice(dices);
            
            dices.Remove(computerChoice);
        }
        else
        {
            computerChoice = PlayingLogic.ComputerChooseDice(dices);
            
            dices.Remove(computerChoice);
            
            playerChoice = PlayingLogic.PlayerChooseDice(dices);
            
            dices.Remove(playerChoice);
        }
        
        
        int playerResult = PlayingLogic.RollTheDice(playerChoice, dices);
        
        int computerResult = PlayingLogic.RollTheDice(computerChoice, dices);
            
        Console.WriteLine(PlayingLogic.IdentifyWinner(playerResult, computerResult));
    }
}