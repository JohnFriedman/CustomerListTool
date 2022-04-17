using CustomerList.Models.Interfaces;
using CustomerList.Sorters.Interfaces;

namespace CustomerList.Sorters;

public class VehicleTypeSorter : ICustomerSorter
{
    public IEnumerable<ICustomer> SortCustomers(IEnumerable<ICustomer> items)
    {
        return items
            .OrderBy(i => i.VehicleType);
    }
}