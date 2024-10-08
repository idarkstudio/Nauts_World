using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public string videoURL = "https://www.example.com/video.mp4";
    private VideoPlayer videoPlayer;

    private void Start()
    {
        // Create a new VideoPlayer component
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        // Set the video URL
        videoPlayer.url = videoURL;

        // Set the video to play on awake
        videoPlayer.playOnAwake = true;

        // Prepare the video player
        videoPlayer.Prepare();

        // Register a callback to start playing the video once it's prepared
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        // Start playing the video
        videoPlayer.Play();
    }
}

