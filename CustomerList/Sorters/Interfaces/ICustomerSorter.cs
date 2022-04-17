using CustomerList.Models.Interfaces;

namespace CustomerList.Sorters.Interfaces;

public interface ICustomerSorter
{
    IEnumerable<ICustomer> SortCustomers(IEnumerable<ICustomer> customer);
}