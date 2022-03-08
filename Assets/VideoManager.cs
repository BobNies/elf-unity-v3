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
    public bool initVideoScreen = true;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private Vector3 vec = new Vector3(5, 3);

    void Start()
    {
        //video player component
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;

        // Hide video screen onStart
        if (initVideoScreen)
        {
            videoPlayer.transform.DOScale(0f, .5f)
                .SetEase(Ease.OutQuint);
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayer.Pause();

        videoPlayer.transform.DOScale(0f, .5f)
            .SetEase(Ease.OutQuint);
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
        easeInVideoScreen();
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    public void playVideo(string videoName)
    {
        easeInVideoScreen();

        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
    }

    public void easeInVideoScreen()
    {
        UnityEngine.Debug.Log("playVideo ***");
        videoPlayer.transform.DOScale(vec, .5f)
            .SetEase(Ease.OutQuint);
    }

}
