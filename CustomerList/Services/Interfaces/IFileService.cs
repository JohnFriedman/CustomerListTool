namespace CustomerList.Services.Interfaces;

public interface IFileService
{
    string GetFileName(string filePath);

    IEnumerable<string> ReadLines(string filePath);
}