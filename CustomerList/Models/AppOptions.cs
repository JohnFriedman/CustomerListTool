namespace CustomerList.Models;

public class AppOptions
{
    public const string AppOptionsSectionName = "AppOptions";

    public int NumberOfFields { get; set; }

    public string OutputFileSeparator { get; set; }

    public IEnumerable<SeparatorMapping> SeparatorMappings { get; set; }
}