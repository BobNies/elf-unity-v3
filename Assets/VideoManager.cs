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
    public DOTweenAnimation doTween;
    public string videoName;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private bool videoHasPlayed = false;

    void Start()
    {
        //video player component
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;
        //videoPlayer.transform.DOScaleY(1f, .5f);

        //playVideo(videoName);
        //doTweenStart.CreateTween(true, true);
        //doTween.DOPlay();
        //doTween.DOPlayBackwards();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.Debug.Log("video is done ***");
        doTween.DOPlay();
        //videoPlayer.frame = -1;
        videoPlayer.Pause();
        //videoPlayer.targetTexture.Release();
        // videoPlayer.transform.DOMoveY(-30, 1);
       // videoPlayer.transform.DOScaleY(0f, .5f);
        videoHasPlayed = true;
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

    public void playVideo(string videoName)
    {
        UnityEngine.Debug.Log("playVideo ***");
        doTween.DOPlayBackwards();

        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";
        //videoPlayer.source = VideoSource.VideoClip;
        //We want to play from url

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();
        videoHasPlayed = true;
    }

}
