using CustomerList.Exceptions;
using CustomerList.Services.Interfaces;

namespace CustomerList.Services;

public class FileService : IFileService
{
    public string GetFileName(string filePath)
    {
        return Path.GetFileName(filePath);
    }

    public IEnumerable<string> ReadLines(string filePath)
    {
        try
        {
            return File.ReadLines(filePath);
        }
        catch (Exception)
        {
            throw new InvalidInputException("Invalid file provided.");
        }
    }
}