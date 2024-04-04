# YTDownloader API
====================

Overview
--------

YTDownloader is a simple ASP.NET Core Web API that allows users to retrieve metadata and stream options for YouTube videos.

Features
--------

-   Provides metadata for the video i.e title, author, duration, thumbnails.
-   Provides variety for streaming options including download urls along with other details such as VideoQuality, VideoResolutions etc.

Technologies Used
-----------------

-   ASP.NET Core: Framework for building cross-platform web applications and services.
-   YoutubeExplode : Abstraction layer over YouTube's internal API
-   Swagger: Used for API documentation and interactive testing.

Getting Started
---------------

To get started with the DotNet Ecommerce API, follow these steps:

1.  Clone the Repository: Clone the repository to your local machine.
2.  Start the API: Run the application and navigate to `/swagger` site to explore the available endpoints.

The API will start listening on `https://localhost:7285` by default.

API Endpoints
-------------
The API exposes the following endpoint:

- `POST /api/downloader`

 Send a POST request to `/api/downloader` with a `url` query param containing the YouTube video URL.

 Example Response
-------------
```json
{
  "title": "Video Title",
  "author": "Channel Name",
  "duration": "00:10:25",
  "thumbnails": [
    {
      "url": "https://example.com/thumbnail.jpg",
      "resolution": {
        "width": 1920,
        "height": 1080
      }
    }
  ],
  "streamOptions": [
    {
      "quality": "1080p",
      "resolution": "1920x1080",
      "size": "50 MB",
      "container": "mp4",
      "downloadUrl": "https://example.com/video.mp4"
    },
    {
      "quality": "720p",
      "resolution": "1280x720",
      "size": "30 MB",
      "container": "mp4",
      "downloadUrl": "https://example.com/video.mp4"
    }
  ]
}
```

Contributors
------------

-   M Salman Haider
