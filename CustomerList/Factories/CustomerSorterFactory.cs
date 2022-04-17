using CustomerList.Enums;
using CustomerList.Factories.Interfaces;
using CustomerList.Sorters.Interfaces;
using CustomerList.Exceptions;
using CustomerList.Sorters;

namespace CustomerList.Factories;

public class CustomerSorterFactory : ICustomerSorterFactory
{
    public ICustomerSorter? GetCustomerSorter(SortFieldEnum sortFieldEnum)
    {
        return sortFieldEnum switch
        {
            SortFieldEnum.NoField => null,
            SortFieldEnum.FullName => new FullNameSorter(),
            SortFieldEnum.VehicleType => new VehicleTypeSorter(),
            _ => throw new InvalidInputException("Invalid sort field provided.")
        };
    }
}