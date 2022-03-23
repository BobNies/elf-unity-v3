using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

/* ELF
    Video Manager: handles video playback 
*/
public class VideoManager : MonoBehaviour
{
    public bool minimizeOnStart = true;
    public bool mainGameVideo = true;

    public VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private Vector3 vec = new Vector3(5, 3);

    void Start()
    {
        //video player component
        //videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;

        // Hide video screen onStart
        if (minimizeOnStart && mainGameVideo)
        {
            videoPlayer.transform.DOScale(0f, .5f)
                .SetEase(Ease.OutQuint);
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayer.Pause();

        if (mainGameVideo)
        {
            videoPlayer.transform.DOScale(0f, .5f)
                .SetEase(Ease.OutQuint);
        }
    }

    public void stopAllVideos()
    {
        if(videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
    }

    public void playVideo(VideoClip videoClip)
    {
        stopAllVideos();

        easeInVideoScreen();

        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    public void playVideo(string videoName)
    {
        stopAllVideos();
        easeInVideoScreen();

        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
    }

    public void easeInVideoScreen()
    {
        if (mainGameVideo)
        {
            videoPlayer.transform.DOScale(vec, .5f)
                .SetEase(Ease.OutQuint);
        }
    }

}
