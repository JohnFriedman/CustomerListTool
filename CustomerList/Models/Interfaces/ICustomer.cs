namespace CustomerList.Models.Interfaces;

public interface ICustomer
{
    string FirstName { get; set; }

    string LastName { get; set; }

    string FullName { get; }

    string Email { get; set; }

    string VehicleType { get; set; }

    string VehicleName { get; set; }

    string VehicleLengthString { get; set; }

    public int VehicleLength { get; }
}