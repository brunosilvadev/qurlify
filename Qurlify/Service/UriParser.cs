public static class LinkParser
{
    public static Dictionary<string, string> ParseQueryString(string uri)
    {
        var query = new Uri(uri).Query;
        return query.TrimStart('?')
                    .Split('&', StringSplitOptions.RemoveEmptyEntries)
                    .Select(part => part.Split('='))
                    .ToDictionary(
                        split => Uri.UnescapeDataString(split[0]),
                        split => split.Length > 1 ? Uri.UnescapeDataString(split[1]) : string.Empty);
    }
}