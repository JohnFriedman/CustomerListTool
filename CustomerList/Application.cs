using CustomerList.Models;
using CustomerList.UserInterfaces;

namespace CustomerList;

public class Application
{
    private readonly IUserInterface _userInterface;
    private readonly IApplicationSteps _applicationSteps;

    public Application(
        IUserInterface userInterface,
        IApplicationSteps applicationSteps
    )
    {
        _userInterface = userInterface;
        _applicationSteps = applicationSteps;
    }

    public void Run()
    {
        _userInterface.WriteLine("Welcome to the Outdoor.sy Customer List Tool!");

        while (true)
        {
            var customers = _applicationSteps.ProcessCustomers();

            var sortedCustomers = _applicationSteps.SortCustomers(customers);

            _applicationSteps.PrintCustomers(sortedCustomers);

            if (!_applicationSteps.AskToRunAgain())
                break;
        }

        _userInterface.WriteLine("Thank you for using the Customer List Tool! Please press any key to exit.");
        _userInterface.WaitForKeyPress();
    }

}
