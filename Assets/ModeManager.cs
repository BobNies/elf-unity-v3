using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DarkTonic.MasterAudio;

// ELF
// Mode manager: Listen for modes to start/stop and update the UI.
// Normally we will play videos, sounds, trigger UI effects (b-day box animations)
public class ModeManager : MonoBehaviour
{
    public VideoManager videoManager;
    public PlayfieldManager playfieldManager;
   // public HighScoreManager highScoreManager;

   // public VideoClip videoCandyCaneForest;
   // public VideoClip videoCentralPark;
    //public VideoClip videoCoffee;
    //public VideoClip videoGimbels;
    //public VideoClip videoGumdrop;
    //public VideoClip videoLincolnTunnel;
    //public VideoClip videoNutcracker;
    public VideoClip videoOmg;
    public VideoClip videoSinging;
    public VideoClip videoSomeoneSpecial;
    public VideoClip[] videoClips;
    public int videoQueueTime = 1;
    [MasterCustomEventAttribute] public string playlist;

    void Start()
    {
        BcpMessageController.OnModeStart += ModeStart;
        BcpMessageController.OnModeStop += ModeStop;

        // test only
        // videoManager.playVideo(videoCandyCaneForest);
    }

    void OnDestroy()
    {
        BcpMessageController.OnModeStart -= ModeStart;
        BcpMessageController.OnModeStop -= ModeStop;
    }

        public void ModeStart(object sender, ModeStartMessageEventArgs e)
    {
        //Debug.Log("bob ModeStart:" + e.Name);
        //BcpLogger.Trace("bob ModeStart: " + e.Name);

        switch (e.Name)
        {
            // 7 levels
            // play videos
            // control small monitor UI
            // TODO - set up small PF on attract
            case "high_score":
                //enable high score script
               // BcpLogger.Trace("bob high_score*** ");
                //this.gameObject.GetComponent<HighScoreManager>().enabled = true;
                break;
            case "attract":
                MasterAudio.StopPlaylist(); // just incase
                playfieldManager.ShowLevel(0);
                break;
            case "level_candy_cane_forest":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(1);
                // start BG music
                StartPlaylist();
                break;
            case "level_central_park":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(7);
                break;
            case "level_coffee":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(5);
                break;
            case "level_gimbels":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(4);
                break;
            case "level_gumdrop":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(2);
                break;
            case "level_lincoln_tunnel":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(3);
                break;
            case "level_nutcracker":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(6);
                break;
            case "level_park":
                playfieldManager.ShowLevel(7);
                break;
            // sub-levels
            // TODO - 8 is unused
            // TODO - play then put back
            case "ball_lock":
               // playfieldManager.ShowLevel(9);
                break;
            case "end_of_ball_bonus":
                break;
            case "jackpot":
                //playfieldManager.ShowLevel(10);
                break;
            case "jet_bonus":
                break;
            case "omg":
                //videoManager.playVideo(videoOmg);
                break;
            case "plunger_skill_shot":
                //playfieldManager.ShowLevel(11);
                break;
            case "ramp_shot":
                //playfieldManager.ShowLevel(12);
                break;
            case "singing":
                videoManager.stopAllVideos();
                videoManager.playVideo(videoSinging);
                break;
            case "someone_special":
                playVideoOnBallOne();
                playfieldManager.ShowLevel(13);
                break;
            
        }
        
    }

    private void playVideoOnBallOne()
    {
        if (Globals.ballNumber == 1)
        {
            //videoClips[Random.Range(0, videoClips.Length)]
            // MasterAudio.PlaySound(ballEndSounds[Random.Range(0, ballEndSounds.Length)]);
            //videoManager.playVideo(videoClips[Random.Range(0, videoClips.Length)]);
            StartCoroutine(queueVideo());
        }
    }

    IEnumerator queueVideo()
    {
        yield return new WaitForSeconds(videoQueueTime);
        videoManager.stopAllVideos(); // prevent dual vids playing
        videoManager.playVideo(videoClips[Random.Range(0, videoClips.Length)]);
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        //todo - kill active vids?
        switch (e.Name)
        {
            // 7 levels
            // play videos
            // control small monitor UI
            // TODO - set up small PF on attract
            case "high_score":
                videoManager.stopAllVideos();
               //this.gameObject.GetComponent<HighScoreManager>().enabled = false;
                break;
        }
    }

    private void StartPlaylist()
    {
        MasterAudio.StartPlaylist(playlist);
    }

}
