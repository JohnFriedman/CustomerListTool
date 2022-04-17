using CustomerList.Models.Interfaces;

namespace CustomerList;

public interface IApplicationSteps
{
    IEnumerable<ICustomer> ProcessCustomers();

    IEnumerable<ICustomer> SortCustomers(IEnumerable<ICustomer> customers);

    void PrintCustomers(IEnumerable<ICustomer> customers);

    bool AskToRunAgain();
}