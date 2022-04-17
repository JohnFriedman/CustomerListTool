namespace CustomerList.Services.Interfaces;

public interface IFileParsingService
{
    IEnumerable<IEnumerable<string>> ParseFile(string? filePath);
}