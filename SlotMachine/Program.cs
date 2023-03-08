using SlotMachine;

decimal depositAmount = 0;
decimal stake = 1;
decimal totalBalance = 1;
decimal startedStake = 0;
bool isStakeChanged = false;

while (depositAmount < stake)
{
    Console.WriteLine("Please deposit money you would like to play with:");
    depositAmount = ValidateInput(depositAmount);

    Console.WriteLine("Enter stake amount:");
    stake = ValidateInput(stake);

    Console.WriteLine();
    if(depositAmount < stake)
        Console.WriteLine("Stake amount has to be less than or equal to the deposit!");

    startedStake = stake; // used after stake is automatically reduced by the system
}

while (totalBalance > 0)
{
    var calc = new Calculations();
    var symbols = new List<Symbol>();
        
    var calcSumCoeff = calc.CalculateCoefficient(symbols); 

    var winAmount = calcSumCoeff * stake;
    totalBalance = depositAmount - stake + winAmount;
    Console.WriteLine();

    Console.WriteLine($"You have won: {winAmount}");
    // totalBalamce > 0 ? func(totalBalamce, stake) : GameEnded();
    if (totalBalance > 0)
    {
        Console.WriteLine($"Current balance is: {totalBalance}");

        depositAmount = totalBalance;

        //stake = CheckStakeValue(stake, totalBalance, startedStake, isStakeChanged);

        if (stake > totalBalance)
        {
            Console.WriteLine($"Stake is greater than {totalBalance}. The system will set the stake = {totalBalance} ");
            stake = totalBalance;
            isStakeChanged = true;
        }
        if (isStakeChanged && stake <= totalBalance && totalBalance >= startedStake)
        {
            stake = startedStake;
            Console.WriteLine($"Now stake is again {stake}");
            isStakeChanged = false;
        }

        Console.WriteLine("Press any key to start a new spin!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Try again! Your total balance hit 0.");
        break;
    }
}

decimal ValidateInput(decimal validNum)
{
    validNum = 0;

    bool isInputValid = false;

    while (!isInputValid)
    {
        string inputText = Console.ReadLine();

        bool isFirstNumberValid = decimal.TryParse(inputText, out validNum);

        if (isFirstNumberValid && validNum > 0)
        {
            isInputValid = true;            
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter valid number, bigger than 0.");
        }        
    }

    return validNum;
}


//static float CheckStakeValue(float stake, float totalBalance, float startedStake, bool isStakeChanged)
//{
//    if (stake > totalBalance)
//    {
//        Console.WriteLine($"Stake is greater than {totalBalance}. The system will set the stake = {totalBalance} ");
//        stake = totalBalance;
//        isStakeChanged = true;
//    }
//    if (isStakeChanged && stake <= totalBalance && totalBalance >= startedStake)
//    {
//        stake = startedStake;
//        Console.WriteLine($"Now stake is again {stake}");
//        isStakeChanged = false;
//    }

//    return stake;
//}