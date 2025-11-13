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
        Console.WriteLine($"{number1} {operation} {number2} = {result}");
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
            case "rt":
                return operation = "√";
            case "pwr":
                return operation = "^";
            default:
                return operation = op;
        }
    }
}