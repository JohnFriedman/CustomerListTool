using CustomerList.Enums;
using CustomerList.Models.Interfaces;

namespace CustomerList.Services.Interfaces;

public interface ICustomerService
{
    ICustomer GetCustomer(IEnumerable<string> parsedLine);

    IEnumerable<ICustomer> GetCustomers(IEnumerable<IEnumerable<string>> parsedLines);

    IEnumerable<ICustomer> GetSortedCustomers(IEnumerable<ICustomer> customers, SortFieldEnum sortFieldEnum);
}