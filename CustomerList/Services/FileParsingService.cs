using CustomerList.Services.Interfaces;
using CustomerList.Exceptions;
using CustomerList.Models;

namespace CustomerList.Services;

public class FileParsingService : IFileParsingService
{
    private readonly AppOptions _appOptions;
    private readonly IFileService _fileService;

    public FileParsingService(
        AppOptions appOptions,
        IFileService fileService
    )
    {
        _appOptions = appOptions;
        _fileService = fileService;
    }

    public IEnumerable<IEnumerable<string>> ParseFile(string? filePath)
    {
        if (filePath == null)
            throw new InvalidInputException("No file path provided.");

        var fileName = _fileService.GetFileName(filePath);

        var fileNameSeparatorMappings = _appOptions.SeparatorMappings
            .ToDictionary(sm => sm.FileName, sm => sm.Separator);

        if (!fileNameSeparatorMappings.TryGetValue(fileName, out var separator))
            throw new InvalidInputException("Invalid file name provided.");

        var lines = _fileService.ReadLines(filePath);

        return lines
            .Select(line => line.Split(separator));
    }
}