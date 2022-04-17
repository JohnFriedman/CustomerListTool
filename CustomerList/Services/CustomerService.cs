using CustomerList.Enums;
using CustomerList.Exceptions;
using CustomerList.Factories.Interfaces;
using CustomerList.Models;
using CustomerList.Models.Interfaces;
using CustomerList.Services.Interfaces;
using CustomerList.Sorters.Interfaces;

namespace CustomerList.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerSorterFactory _customerSorterFactory;

    public CustomerService(ICustomerSorterFactory customerSorterFactory)
    {
        _customerSorterFactory = customerSorterFactory;
    }

    public ICustomer GetCustomer(IEnumerable<string> parsedLine)
    {
        var parsedLineArray = parsedLine.ToArray();

        if (parsedLineArray.Length != 6)
            throw new InvalidInputException("File contains invalid data.");
        
        return new Customer
        {
            FirstName = parsedLineArray[0],
            LastName = parsedLineArray[1],
            Email = parsedLineArray[2],
            VehicleType = parsedLineArray[3],
            VehicleName = parsedLineArray[4],
            VehicleLengthString = parsedLineArray[5]
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