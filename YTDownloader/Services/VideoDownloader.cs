using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace YTDownloader.Services;
public interface IVideoDownloader
{
    public Task<ActionResult<MetaData>> DownloadVideo(string url);
}

public class VideoDownloader : IVideoDownloader
{
    public async Task<ActionResult<MetaData>> DownloadVideo(string url)
    {
        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(url);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
        var muxedStreams = streamManifest.GetMuxedStreams();

        if (muxedStreams is not null && muxedStreams.Any())
        {
            var streamOptions = new List<StreamOption>();
            foreach (var option in muxedStreams)
            {

                streamOptions.Add(
                  new StreamOption(option.VideoQuality.ToString(),
                  option.VideoResolution.ToString(),
                  option.Size.ToString(),
                  option.Container.ToString(),
                  option.Url));
            }

            var metaData = new MetaData(video.Title,
                video.Author.ChannelTitle,
                video.Duration,
                video.Thumbnails,
                streamOptions);

            return metaData;
        }
        else
        {
            throw new InvalidOperationException("No video streams available.");
        }
    }
}

public record MetaData(string title,
    string author,
    TimeSpan? duration,
    IReadOnlyList<Thumbnail> thumbnails,
    List<StreamOption> streamOptions);
public record StreamOption(string quality,
    string resolution,
    string size,
    string container,
    string downloadUrl);