using CustomerList.Enums;
using CustomerList.Exceptions;
using CustomerList.Factories.Interfaces;
using CustomerList.Models;
using CustomerList.Models.Interfaces;
using CustomerList.Services.Interfaces;

namespace CustomerList.Services;

public class CustomerService : ICustomerService
{
    private readonly AppOptions _appOptions;
    private readonly ICustomerSorterFactory _customerSorterFactory;

    public CustomerService(
        AppOptions appOptions,
        ICustomerSorterFactory customerSorterFactory
    )
    {
        _appOptions = appOptions;
        _customerSorterFactory = customerSorterFactory;
    }

    public ICustomer GetCustomer(IEnumerable<string> parsedLine)
    {
        var parsedLineArray = parsedLine.ToArray();

        if (parsedLineArray.Length != _appOptions.NumberOfFields)
            throw new InvalidInputException("File contains invalid data.");
        
        return new Customer
        {
            FirstName = parsedLineArray[(int)CustomerFieldEnum.FirstName],
            LastName = parsedLineArray[(int)CustomerFieldEnum.LastName],
            Email = parsedLineArray[(int)CustomerFieldEnum.Email],
            VehicleType = parsedLineArray[(int)CustomerFieldEnum.VehicleType],
            VehicleName = parsedLineArray[(int)CustomerFieldEnum.VehicleName],
            VehicleLengthString = parsedLineArray[(int)CustomerFieldEnum.VehicleLengthString]
        };
    }

    public IEnumerable<ICustomer> GetCustomers(IEnumerable<IEnumerable<string>> parsedLines)
    {
        return parsedLines
            .Select(GetCustomer);
    }

    public IEnumerable<ICustomer> GetSortedCustomers(IEnumerable<ICustomer> customers, SortFieldEnum sortFieldEnum)
    {
        var sorter = _customerSorterFactory.GetCustomerSorter(sortFieldEnum);

        return sorter == null
            ? customers
            : sorter.SortCustomers(customers);
    }
}