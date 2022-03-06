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
        //videoPlayer.transform.DOScaleY(1f, .5f);

        // Hide video screen onStart
        if (initVideoScreen)
        {
            videoPlayer.transform.DOScale(0f, .5f)
                .SetEase(Ease.OutQuint);
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.Debug.Log("video is done ***");
       // doTween.DOPlay();
        //videoPlayer.frame = -1;
        videoPlayer.Pause();
        //videoPlayer.targetTexture.Release();
        // videoPlayer.transform.DOMoveY(-30, 1);
        // transform.DOMoveX(45, 1).SetDelay(2).SetEase(Ease.OutQuad).OnComplete(MyCallback);
        videoPlayer.transform.DOScale(0f, .5f)
            .SetEase(Ease.OutQuint);
       // videoHasPlayed = true;
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
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

        //  //videoPlayer.source = VideoSource.VideoClip;
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
        // doTween.DOPlayBackwards();
    }

}
