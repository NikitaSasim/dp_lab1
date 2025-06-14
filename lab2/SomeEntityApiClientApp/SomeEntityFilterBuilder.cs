namespace SomeEntityApiClientApp;

public class SomeEntityFilterBuilder
{
    private readonly Dictionary<string, string> _filters = new();

    public SomeEntityFilterBuilder WithStatus(string status)
    {
        _filters["status"] = status;
        return this;
    }

    public SomeEntityFilterBuilder WithName(string name)
    {
        _filters["name"] = name;
        return this;
    }

    public SomeEntityFilterBuilder WithDescriptionContains(string keyword)
    {
        _filters["description"] = keyword;
        return this;
    }

    public string BuildQuery()
    {
        if (_filters.Count == 0) return string.Empty;

        var query = string.Join("&", _filters.Select(kv =>
            $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

        return "?" + query;
    }
}
