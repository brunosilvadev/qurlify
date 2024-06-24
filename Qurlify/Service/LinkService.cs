using System.Net.Http.Json;

public class LinkService(HttpClient http) : ILinkService
{
    public async Task<ShortenedLink[]> GetLinksAsync()
    {
        return await http.GetFromJsonAsync<ShortenedLink[]>("all") ?? [];
    }

    public async Task<string> ShortenLink(string longUrl, string comment)
    {
        var req = new CreateLinkRequest()
        {
            LongUrl = longUrl,
            Comment = comment
        };

        var response = await http.PostAsJsonAsync("c", req);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetLink(string shortUrl)
    {
        var response = await http.GetAsync($"s?url={shortUrl}");
        var link =  await response.Content.ReadFromJsonAsync<ShortenedLink>();
        return link?.longUrl ?? "";
    }
}

public interface ILinkService
{
    Task<ShortenedLink[]> GetLinksAsync();
    Task<string> ShortenLink(string longUrl, string comment);

    Task<string> GetLink(string shortUrl);
}