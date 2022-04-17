using CustomerList.Extensions;
using CustomerList.Models.Interfaces;

namespace CustomerList.Models;

public class Customer : ICustomer
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; }

    public string VehicleType { get; set; }

    public string VehicleName { get; set; }

    public string VehicleLengthString { get; set; }

    public int VehicleLength
    {
        get
        {
            var vehicleLengthNumericCharacters = VehicleLengthString.RemoveNonNumericCharacters();

            return int.Parse(vehicleLengthNumericCharacters);
        }
    }
}