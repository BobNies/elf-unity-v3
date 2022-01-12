using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

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

         //playVideo(videoName);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        //videoPlayer.enabled = true;
        //videoPlayer.frame = -1;
        videoPlayer.Pause();
        //videoPlayer.targetTexture.Release();
        // videoPlayer.transform.DOMoveY(-30, 1);
        videoPlayer.transform.DOScaleY(.1f, .5f);
        
        //videoPlayer.enabled = false;
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

    public void playVideo(string videoName)
    {
        //videoPlayer.enabled = true;
        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";
        //videoPlayer.source = VideoSource.VideoClip;
        //We want to play from url

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
    }

}
