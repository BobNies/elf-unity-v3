using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using DarkTonic.MasterAudio;

/* ELF
    Video Manager: handles video playback 
    NODE: if you modify this script, you need to delete/add the player back to MasterAudio
*/
public class VideoManager : MonoBehaviour
{
    [Tooltip("Should the Video screen be minimized on start")]
    public bool minimizeOnStart = true;
    [Tooltip("Is this the main video screen. Usually the screen in front of the Book")]
    public bool mainGameVideo = true;

    public PresentManager presentManager;

    public VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private Vector3 vec = new Vector3(5, 3);
    private float playlistResumeVolume;

    void Start()
    {
        //video player component
        //videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;

        playlistResumeVolume = PlaylistController.InstanceByName("PlaylistController").PlaylistVolume;


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

            presentManager.show();

            //duck audio
            //MasterAudio.UnmutePlaylist();
            PlaylistController.InstanceByName("PlaylistController").FadeToVolume(playlistResumeVolume, .5f); //.38f
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

        if (mainGameVideo)
        {
            //mute background music during video
            //MasterAudio.MutePlaylist();
            PlaylistController.InstanceByName("PlaylistController").FadeToVolume(.15f, .5f);
            presentManager.hide();
        }
    }

    public void playVideo(string videoName)
    {
        stopAllVideos();
        easeInVideoScreen();

        string url = "file://" + Application.streamingAssetsPath + "/" + videoName + ".mp4";

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Play();

        if (mainGameVideo)
        {
            //mute background music during video
            MasterAudio.MutePlaylist();
        }
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
