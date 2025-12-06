/*
A proxy is like a middleman or gatekeeper.
You → Manager (proxy) → Actor (real object)

Common purposes:
Access control (check permission)
Lazy loading (load object only when needed)
Caching
Logging
Remote access (call a remote server)
*/


public interface IVideoService
{
    string GetVideo(string videoId);
}

public class VideoService : IVideoService
{
    public string GetVideo(string videoId)
    {
        return $"video for: {videoId}";
    }
}

public class VideoServiceProxy : IVideoService
{
    private IVideoService _videoService;
    private Dictionary<string, string> _cache = new Dictionary<string, string>();

    public string GetVideo(string videoId)
    {
        if (_videoService == null)
        {
            // Lazy loading
            _videoService = new VideoService();
        }
        if (_cache.ContainsKey(videoId))
        {
            // Return cached video
            return _cache[videoId];
        }
        var video = _videoService.GetVideo(videoId);
        _cache[videoId] = video;
        return video;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IVideoService videoService = new VideoServiceProxy();
        Console.WriteLine(videoService.GetVideo("123")); // Loads and caches
        Console.WriteLine(videoService.GetVideo("123")); // Returns from cache
        Console.WriteLine(videoService.GetVideo("456")); // Loads and caches
    }
}

