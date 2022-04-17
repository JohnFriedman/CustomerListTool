namespace CustomerList.UserInterfaces;

public interface IUserInterface
{
    void WriteLine(string line);

    string? ReadLine();

    void WaitForKeyPress();
}