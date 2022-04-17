using CustomerList.Models;
using CustomerList.UserInterfaces;

namespace CustomerList;

public class Application : IApplication
{
    private readonly AppOptions _appOptions;
    private readonly IUserInterface _userInterface;
    private readonly IApplicationSteps _applicationSteps;

    public Application(
        AppOptions appOptions,
        IUserInterface userInterface,
        IApplicationSteps applicationSteps
    )
    {
        _appOptions = appOptions;
        _userInterface = userInterface;
        _applicationSteps = applicationSteps;
    }

    public void Run()
    {
        _userInterface.WriteLine(_appOptions.StartupMessage);

        while (true)
        {
            var customers = _applicationSteps.ProcessCustomers();

            var sortedCustomers = _applicationSteps.SortCustomers(customers);

            _applicationSteps.PrintCustomers(sortedCustomers);

            if (!_applicationSteps.AskToRunAgain())
                break;
        }

        _userInterface.WriteLine(_appOptions.ClosingMessage);
        _userInterface.WaitForKeyPress();
    }

}
