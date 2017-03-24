namespace ShortenerWebApp.Models
{
    public class Link
    {
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }
    }
}