using SlotMachine;

float depositAmount = 0;
float stake = 1;
float totalBalance = 1;
float startedStake = 0;
bool isStakeChanged = false;

while (depositAmount < stake)
{
    Console.WriteLine("Please deposit money you would like to play with:");
    depositAmount = float.Parse(Console.ReadLine());
    Console.WriteLine("Enter stake amount:");
    stake = int.Parse(Console.ReadLine());
    Console.WriteLine();
    if(depositAmount < stake)
        Console.WriteLine("Stake amount has to be less than or equal to the deposit!");

    startedStake = stake; // used after stake is automatically reduced by the system
}

while (totalBalance > 0)
{
    var calc = new Calculations();
    var symboltList = new List<Symbol>();
        
    var calcSumCoeff = 0f;
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            var symbol = calc.CalcSymbolsProbability();
            symboltList.Add(symbol);
            Console.Write(symbol.Name);
        }

        var names = symboltList.Select(x => x.Name).ToList();

        calcSumCoeff += calc.SumSymbolsCoefficient(symboltList[0], symboltList[1], symboltList[2], names);

        symboltList.Clear();
        Console.WriteLine();
    }

    var winAmount = calcSumCoeff * stake;
    totalBalance = depositAmount - stake + winAmount;
    Console.WriteLine();
    //Console.WriteLine($"Sumarno koeficienta e {calcSum}");
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