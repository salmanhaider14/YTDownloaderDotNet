using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YTDownloader.Services;
public interface IVideoDownloader
{
  public  Task<ActionResult<MetaData>> DownloadVideo(string url);
}


public class VideoDownloader : IVideoDownloader
{
    public async Task<ActionResult<MetaData>> DownloadVideo(string url)
    {
        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(url);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
        var muxedStreams = streamManifest.GetMuxedStreams();
       
        if (muxedStreams != null && muxedStreams.Any())
        {
            
            var streamInfo = muxedStreams.GetWithHighestVideoQuality();
            var metaData = new MetaData(video.Title, video.Author.ChannelTitle, video.Duration, streamInfo.Url);
            return metaData;
        }
        else
        {
            throw new InvalidOperationException("No video streams available.");
        }
    }
}
public record MetaData(string title, string author, TimeSpan? duration, string downloadUrl);