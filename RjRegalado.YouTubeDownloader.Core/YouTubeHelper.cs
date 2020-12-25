using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeExplode;

namespace RjRegalado.YouTubeDownloader.Core
{
    public static class YouTubeHelper
    {
        public static async Task<List<YouTubeLinksObj>> GetDowloadUrlsAsync(string ytLink)
        {
            var result = new List<YouTubeLinksObj>();
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(ytLink);

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(ytLink.Replace("https://www.youtube.com/watch?v=", ""));

            foreach (var item in streamManifest.Streams)
            {

                if (item.ToString().Contains("Muxed"))
                {
                    result.Add(new YouTubeLinksObj()
                    {
                        URL = item.Url,
                        Title = video.Title,
                        Resolution = item.ToString(),
                        Container = item.Container.Name,
                        Type = "Muxed"
                    });
                }

                if (item.ToString().Contains("Audio-only"))
                {
                    result.Add(new YouTubeLinksObj()
                    {
                        URL = item.Url,
                        Title = video.Title,
                        Resolution = item.ToString(),
                        Container = item.Container.Name,
                        Type = "Audio-only"
                    });
                }

                if (item.ToString().Contains("Video-only"))
                {
                    result.Add(new YouTubeLinksObj()
                    {
                        URL = item.Url,
                        Title = video.Title,
                        Resolution = item.ToString(),
                        Container = item.Container.Name,
                        Type = "Video-only"
                    });
                }




            }
            return result;
        }

    }
}
