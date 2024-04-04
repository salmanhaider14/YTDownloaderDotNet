
using Microsoft.AspNetCore.Mvc;
using Serilog;
using YTDownloader.Services;

namespace YTDownloader.Controllers;

[Route("api/downloader")]
[ApiController]
public class MainController(IVideoDownloader videoDownloader) : ControllerBase
{
    private readonly IVideoDownloader _videoDownloader  = videoDownloader;
    [HttpPost]
   public async Task<ActionResult<MetaData>> DownloadVideo(string url)
    {
        try
        {
            return await _videoDownloader.DownloadVideo(url);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while downloading the video");
            return StatusCode(500, "An error occurred while downloading the video.");
        }

    }
}
