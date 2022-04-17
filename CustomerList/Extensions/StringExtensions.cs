namespace CustomerList.Extensions;

public static class StringExtensions
{
    public static string RemoveNonNumericCharacters(this string input)
    {
        return new string(
            input
                .Where(char.IsDigit)
                .ToArray()
        );
    }
}