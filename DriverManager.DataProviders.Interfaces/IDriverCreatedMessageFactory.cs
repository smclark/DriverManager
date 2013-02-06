using DriverManager.Models.Interfaces.Messages;

namespace DriverManager.DataProviders.Interfaces
{
    public interface IDriverCreatedMessageFactory
    {
        IDriverCreatedMessage CreateInstance(string name);
    }
}
