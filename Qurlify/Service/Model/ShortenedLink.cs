public class ShortenedLink
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string longUrl { get; set; } = "";
    public string link { get; set; } = "";
    public int HitCounter { get; set; }
    public DateTime DateCreated { get; private set; } = DateTime.Now;
}