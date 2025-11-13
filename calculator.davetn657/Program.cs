using System.Text.RegularExpressions;
using CalculatorLibrary;

bool endApp = false;
Calculator calculator = new Calculator();
List<Calculation> calculations = new List<Calculation>();
int counter = 0;

Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

while (!endApp)
{
    string? numInput1 = string.Empty;
    string? numInput2 = string.Empty;
    double result = 0;

    Console.Write("Type a number or hist (for past calculations), and then press Enter: ");
    numInput1 = Console.ReadLine();

    double cleanNum1 = 0;
    if(numInput1 == "hist" && calculations.Count > 0)
    {
        numInput1 = GetResultFromHistory();
    }
    else if(numInput1 == "hist" && calculations.Count == 0)
    {
        Console.WriteLine("Couldn't find any past calculations!");
    }

    while (!double.TryParse(numInput1, out cleanNum1))
    {
        Console.Write("This is not a valid input. Please enter a numeric value: ");
        numInput1 = Console.ReadLine();
    }

    Console.Write("Type another number or hist (for past calculations), and them press Enter: ");
    numInput2 = Console.ReadLine();

    double cleanNum2 = 0;

    if (numInput2 == "hist" && calculations.Count > 0)
    {
        numInput2 = GetResultFromHistory();
    }
    else if (numInput1 == "hist" && calculations.Count == 0)
    {
        Console.WriteLine("Couldn't find any past calculations!");
    }

    while (!double.TryParse(numInput2, out cleanNum2))
    {
        Console.Write("This is not a valid input. Please enter a numeric value: ");
        numInput2 = Console.ReadLine();
    }

    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.WriteLine("\tpwr - Power");
    Console.WriteLine("\tsqrt - Square Root (only on 1st number)");
    Console.WriteLine("\tsin - Sine (only on 1st number)");
    Console.WriteLine("\tcos - Cosine (only on 1st number)");
    Console.WriteLine("\ttan - Tangent (only on 1st number)");
    Console.Write("Your option? ");

    string? op = Console.ReadLine();

    if(op == null || ! Regex.IsMatch(op, "[a|s|m|d|pwr|sqrt|sin|cos|tan]"))
    {
        Console.WriteLine("ERROR: Unrecognized input.");
    }
    else
    {
        try
        {
            result = calculator.DoOperation(cleanNum1, cleanNum2, op);
            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error\n");
            }
            else
            {
                Console.WriteLine("Your result: {0:0.##}\n", result);
                calculations.Add(new Calculation(op!, cleanNum1, cleanNum2, result));
                counter++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oh no! An exception occured trying to do the math.\n - Details: " + ex.Message);
        }
    }
    Console.WriteLine("------------------------\n");

    string? input = string.Empty;

    Console.WriteLine("Total operations performed: {0}", counter);
    Console.Write("Press 'n' and Enter to close the app,\nPress 'h' and Enter to display past calculations,\nor press any other key and Enter to continue: ");
    input = Console.ReadLine();
    if (input == "n") endApp = true;
    else if(input == "h") CalculationHistory();

    Console.Write("Press 'n' and Enter to close the app,\nPress 'd' and Enter to delete history,\nor press any other key and Enter to continue:");
    input = Console.ReadLine();
    if (input == "n") endApp = true;
    else if (input == "d") calculations.Clear();
    Console.WriteLine("\n");
}

calculator.Finish();

string GetResultFromHistory()
{
    string? numInput = string.Empty;
    int index = 0;

    CalculationHistory();

    Console.Write("Enter a number to choose which calculation result to use: ");
    numInput = Console.ReadLine();

    while (!Int32.TryParse(numInput, out index))
    {
        Console.Write("This is not a valid input. Please enter a numeric value: ");
        numInput = Console.ReadLine();
    }

    return calculations[index - 1].GetResult();
}

void CalculationHistory()
{
    Console.WriteLine("------------------------");
    Console.WriteLine("Calculation History:");
    int count = 1;
    foreach (var calc in calculations)
    {
        Console.Write($"\t{count}. ");
        calc.Display();
        count++;
    }
    Console.WriteLine("------------------------\n");
}