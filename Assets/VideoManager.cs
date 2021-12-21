using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public string videoName;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    void Start()
    {
        //video player component
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;

        // playVideo(videoName);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        //videoPlayer.enabled = true;
        //videoPlayer.frame = -1;
    }

    public void playVideo(string videoName)
    {
       // videoPlayer.enabled = false;
        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";
        //videoPlayer.source = VideoSource.VideoClip;
        //We want to play from url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
    }

   
}
