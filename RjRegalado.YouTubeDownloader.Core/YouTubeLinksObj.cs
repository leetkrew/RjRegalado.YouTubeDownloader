namespace RjRegalado.YouTubeDownloader.Core
{
    public class YouTubeLinksObj
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Resolution { get; set; }
        public string Container { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return Resolution;
        }

    }
}
