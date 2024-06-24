using System.Net.Http.Json;

public class LinkService(HttpClient http) : ILinkService
{
    public async Task<ShortenedLink[]> GetLinksAsync()
    {
        return await http.GetFromJsonAsync<ShortenedLink[]>("all") ?? [];
    }
}

public interface ILinkService
{
    Task<ShortenedLink[]> GetLinksAsync();
}