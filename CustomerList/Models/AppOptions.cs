namespace CustomerList.Models;

public class AppOptions
{
    public const string AppOptionsSectionName = "AppOptions";

    public string StartupMessage { get; set; }

    public string ClosingMessage { get; set; }

    public IEnumerable<SeparatorMapping> SeparatorMappings { get; set; }
}