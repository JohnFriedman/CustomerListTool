namespace CustomerList.UserInterfaces;

public class ConsoleUserInterface : IUserInterface
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void WaitForKeyPress()
    {
        Console.ReadKey();
    }
}