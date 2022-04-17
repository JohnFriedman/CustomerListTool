using CustomerList.Enums;
using CustomerList.Sorters.Interfaces;

namespace CustomerList.Factories.Interfaces;

public interface ICustomerSorterFactory
{
    ICustomerSorter? GetCustomerSorter(SortFieldEnum sortFieldEnum);
}