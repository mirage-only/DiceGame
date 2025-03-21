namespace DiceGame;

public class PlayingLogic
{
    public static bool ChooseWhoStart(List<List<int>> dices)
    {
        string secretKey = HashOperations.GenerateSecretKey();
        
        int randomNumber = NumberGenerator.GenerateNumber(0, 2);
        
        string hmac = HashOperations.GenerateHMAC(randomNumber, secretKey);
        
        Console.WriteLine($"I chosen. HMAC: {hmac}");
        
        string correctInput = InputMethods.ThePlayerGuessesTheNumber();

        
        while (!int.TryParse(correctInput, out _))
        {
            if (correctInput == "x") ClosingProgram.CloseProgram();
            else if (correctInput == "?")
            {
                HelpTable.DisplayHelpTable(dices);
                
                correctInput = InputMethods.ThePlayerGuessesTheNumber();
            }
        }

        Console.WriteLine($"Your selection: {correctInput}" +
                          $"\nMy selection: {randomNumber} (Secret Key: {secretKey})");
        
        return String.Equals(correctInput, randomNumber.ToString());
    }
    
    public static List<int> ComputerChooseDice(List<List<int>> dices)
    {
        int randomDice = NumberGenerator.GenerateNumber(0, dices.Count);

        Console.WriteLine("My selection: [" + string.Join(", ", dices[randomDice]) + " ]");
        
        List<int> computerChoice = dices[randomDice];
        
        return computerChoice;
    }
    
    public static List<int> PlayerChooseDice(List<List<int>> dices)
    {
        string correctInput = InputMethods.TheEnterHisDice(dices);

        while (!int.TryParse(correctInput, out _))
        {
            if (correctInput == "x") ClosingProgram.CloseProgram();
            else if (correctInput == "?")
            {
                HelpTable.DisplayHelpTable(dices);
                
                correctInput = InputMethods.TheEnterHisDice(dices);
            }
        }

        Console.WriteLine($"Your selection is {correctInput}." +
                          $"You choose the [{string.Join(", ", dices[int.Parse(correctInput)])}] dice");
        
        List<int> playersChoice = dices[int.Parse(correctInput)];
        
        return playersChoice;
    }
    
    public static int RollTheDice(List<int> rollingDice, List<List<int>> dices)
    {
        int computerRandomValue = NumberGenerator.GenerateNumber(0, 5);

        string secretKey = HashOperations.GenerateSecretKey();
        
        string hmac = HashOperations.GenerateHMAC(computerRandomValue, secretKey);

        Console.WriteLine($"I selected random value, HMAC = {hmac}");
        
        string correctInput = InputMethods.EnterValueToDice();

        while (!int.TryParse(correctInput, out _))
        {
            if (correctInput == "x")
            {
                ClosingProgram.CloseProgram();
            }
            else if (correctInput == "?")
            {
                HelpTable.DisplayHelpTable(dices);
                
                correctInput = InputMethods.EnterValueToDice();
            }
        }

        int userValue = int.Parse(correctInput);
        
        Console.WriteLine($"Your selection: {userValue} \n My selection: {computerRandomValue} (KEY = {secretKey})");
        
        int resultDiceNumber = (computerRandomValue + userValue) % 6;
        Console.WriteLine("The fair number generation result is " +
                          $"{computerRandomValue} + {userValue} = {resultDiceNumber} (mod 6)." +
                          $"Roll result: {rollingDice[resultDiceNumber]}");
        
        return rollingDice[resultDiceNumber];
        
    }
    
    public static string IdentifyWinner(int playerResult, int computerResult)
    {
        string winner;

        if (playerResult > computerResult)
        {
            winner = $"{playerResult} > {computerResult}! You win!";
        }
        else if (playerResult < computerResult)
        {
            winner = $"{playerResult} < {computerResult}! Computer win!"; 
        }
        else
        {
            winner = $"{playerResult} = {computerResult}! Draw!";
        }
        
        return winner;
    }
}