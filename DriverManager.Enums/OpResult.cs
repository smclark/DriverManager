namespace DriverManager.Enums
{
    public enum OpResult
    {
        Success= 0,
        NullParameter = 1,
        InvalidParameters = 2,
        IncompleteObject = 3,
        ObjectExists = 4,
        ObjectNotExists = 5,
        DatabaseConnectionError = 20,
        DatabaseTimeout = 21,
        DatabaeInvalidConnStr = 22,
        ExceptionOccurred = 254,
        GeneralError = 255
        
    }
}
