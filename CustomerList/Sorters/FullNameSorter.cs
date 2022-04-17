using CustomerList.Models.Interfaces;
using CustomerList.Sorters.Interfaces;

namespace CustomerList.Sorters;

public class FullNameSorter : ICustomerSorter
{
    public IEnumerable<ICustomer> SortCustomers(IEnumerable<ICustomer> items)
    {
        return items
            .OrderBy(i => i.FullName);
    }
}