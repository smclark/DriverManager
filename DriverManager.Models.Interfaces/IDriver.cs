
using DriverManager.Enums;

namespace DriverManager.Models.Interfaces
{
    public interface IDriver
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string CardNumber { get; set; }
        string Country { get; set; }
        bool Validate();
    }
}
