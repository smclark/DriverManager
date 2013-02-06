
namespace DriverManager.Models.Interfaces
{
    public interface IAddress
    {
        string StreetName { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PostCode { get; set; }
    }
}
