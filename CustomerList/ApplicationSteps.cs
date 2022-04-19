using CustomerList.Enums;
using CustomerList.Exceptions;
using CustomerList.Models.Interfaces;
using CustomerList.Services.Interfaces;
using CustomerList.UserInterfaces;
using System.Text;
using CustomerList.Models;

namespace CustomerList;

public class ApplicationSteps : IApplicationSteps
{
    private readonly AppOptions _appOptions;
    private readonly IUserInterface _userInterface;
    private readonly IFileParsingService _fileParsingService;
    private readonly ICustomerService _customerService;

    public ApplicationSteps(
        AppOptions appOptions,
        IUserInterface userInterface,
        IFileParsingService fileParsingService,
        ICustomerService customerService
    )
    {
        _appOptions = appOptions;
        _userInterface = userInterface;
        _fileParsingService = fileParsingService;
        _customerService = customerService;
    }

    public IEnumerable<ICustomer> ProcessCustomers()
    {
        IEnumerable<ICustomer>? customers = null;

        do
        {
            _userInterface.WriteLine("Please specify the file path for your Customer List (commas.txt or pipes.txt):");
            try
            {
                var fullFileLocation = _userInterface.ReadLine();

                var parsedData = _fileParsingService.ParseFile(fullFileLocation);

                customers = _customerService.GetCustomers(parsedData);
            }
            catch (InvalidInputException ex)
            {
                _userInterface.WriteLine(ex.Message);
            }
        } while (customers == null);

        return customers;
    }

    public IEnumerable<ICustomer> SortCustomers(IEnumerable<ICustomer> customers)
    {
        SortFieldEnum? sortFieldEnum = null;

        do
        {
            _userInterface.WriteLine("Please select the field you would like to sort customers by: ");
            try
            {
                _userInterface.WriteLine("0) No Field (keep order from file)");
                _userInterface.WriteLine("1) Full Name");
                _userInterface.WriteLine("2) Vehicle Type");

                var sortFieldInput = _userInterface.ReadLine();

                switch (sortFieldInput?.ToLower())
                {
                    case "0":
                        sortFieldEnum = SortFieldEnum.NoField;
                        break;
                    case "1":
                        sortFieldEnum = SortFieldEnum.FullName;
                        break;
                    case "2":
                        sortFieldEnum = SortFieldEnum.VehicleType;
                        break;
                    default:
                        throw new InvalidInputException("Invalid response.");
                }
            }
            catch (InvalidInputException ex)
            {
                _userInterface.WriteLine(ex.Message);
            }
        } while (sortFieldEnum == null);

        return _customerService.GetSortedCustomers(customers, sortFieldEnum.Value); ;
    }

    public void PrintCustomers(IEnumerable<ICustomer> customers)
    {
        foreach (var customer in customers)
        {
            var outputFileSeparator = _appOptions.OutputFileSeparator;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(customer.FullName);
            stringBuilder.Append(outputFileSeparator);
            stringBuilder.Append(customer.Email);
            stringBuilder.Append(outputFileSeparator);
            stringBuilder.Append(customer.VehicleType);
            stringBuilder.Append(outputFileSeparator);
            stringBuilder.Append(customer.VehicleName);
            stringBuilder.Append(outputFileSeparator);
            stringBuilder.Append(customer.VehicleLengthString);

            _userInterface.WriteLine(stringBuilder.ToString());
        }
    }

    public bool AskToRunAgain()
    {
        _userInterface.WriteLine("Would you like to print out another Customer List?: ");
        _userInterface.WriteLine("Y) Yes");
        _userInterface.WriteLine("N) No");

        bool? runAgain = null;

        do
        {
            var runAgainInput = _userInterface.ReadLine();
            switch (runAgainInput?.ToLower())
            {
                case "y":
                case "yes":
                    runAgain = true;
                    break;
                case "n":
                case "no":
                    runAgain = false;
                    break;
                default:
                    _userInterface.WriteLine("Invalid response. Please specify Yes (Y) or No (N)");
                    break;
            }
        } while (runAgain == null);

        return runAgain.Value;
    }
}