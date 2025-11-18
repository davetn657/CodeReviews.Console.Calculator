using System.Text.RegularExpressions;

internal class Calculation
{
    string operation;
    string number1;
    string number2;
    string result;

    public Calculation(string operation, double number1, double number2, double result)
    {
        this.operation = ConvertOperation(operation);
        this.number1 = number1.ToString();
        this.number2 = number2.ToString();
        this.result = result.ToString();
    }

    public void Display()
    {
        if (Regex.IsMatch(this.operation, "√|10x|sin|cos|tan"))
        {
            Console.WriteLine($"{operation}({number1}) = {result}");
        }
        else
        {
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
        }
    }

    public string GetResult()
    {
        return result;
    }

    private string ConvertOperation(string op)
    {
        switch (op)
        {
            case "a":
                return operation = "+";
            case "s":
                return operation = "-";
            case "m":
                return operation = "*";
            case "d":
                return operation = "/";
            case "sqrt":
                return operation = "√";
            case "pwr":
                return operation = "^";
            case "x":
                return operation = "10x";
            default:
                return operation = op;
        }
    }
}