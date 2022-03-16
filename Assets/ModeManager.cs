using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// ELF
// Mode manager: Listen for modes to start/stop and update the UI.
// Normally we will play videos, sounds, trigger UI effects (b-day box animations)
public class ModeManager : MonoBehaviour
{
    public VideoManager videoManager;
    public PlayfieldManager playfieldManager;

    public VideoClip videoCandyCaneForest;
    public VideoClip videoCentralPark;
    public VideoClip videoCoffee;
    public VideoClip videoGimbels;
    public VideoClip videoGumdrop;
    public VideoClip videoLincolnTunnel;
    public VideoClip videoNutcracker;
    public VideoClip videoOmg;
    public VideoClip videoSinging;
    public VideoClip videoSomeoneSpecial;

    void Start()
    {
        BcpMessageController.OnModeStart += ModeStart;
        BcpMessageController.OnModeStop += ModeStop;

        // test only
       // videoManager.playVideo(videoCandyCaneForest);
    }

    void OnDisable()
    {
        BcpMessageController.OnModeStart -= ModeStart;
        BcpMessageController.OnModeStop -= ModeStop;
    }

        public void ModeStart(object sender, ModeStartMessageEventArgs e)
    {
        // only play on ball 1
        if (Globals.ballNumber > 1) { return; }
        //Debug.Log("bob ModeStart:" + e.Name);
        //BcpLogger.Trace("bob ModeStart: " + e.Name);

        switch (e.Name)
        {
            // 7 levels
            // play videos
            // control small monitor UI
            // TODO - set up small PF on attract
            case "level_candy_cane_forest":
                videoManager.playVideo(videoCandyCaneForest);
                playfieldManager.ShowLevel(1);
                break;
            case "level_central_park":
                videoManager.playVideo(videoCentralPark);
                playfieldManager.ShowLevel(2);
                break;
            case "level_coffee":
                videoManager.playVideo(videoCoffee);
                playfieldManager.ShowLevel(3);
                break;
            case "level_gimbels":
                videoManager.playVideo(videoGimbels);
                playfieldManager.ShowLevel(4);
                break;
            case "level_gumdrop":
                videoManager.playVideo(videoGumdrop);
                playfieldManager.ShowLevel(5);
                break;
            case "level_lincoln_tunnel":
                videoManager.playVideo(videoLincolnTunnel);
                playfieldManager.ShowLevel(6);
                break;
            case "level_nutcracker":
                videoManager.playVideo(videoNutcracker);
                playfieldManager.ShowLevel(7);
                break;
            // sub-levels
            case "ball_lock":
                playfieldManager.ShowLevel(8);
                break;
            case "end_of_ball_bonus":
                break;
            case "jackpot":
                playfieldManager.ShowLevel(9);
                break;
            case "jet_bonus":
                break;
            case "omg":
                videoManager.playVideo(videoOmg);
                break;
            case "plunger_skill_shot":
                playfieldManager.ShowLevel(10);
                break;
            case "ramp_shot":
                playfieldManager.ShowLevel(11);
                break;
            case "singing":
                videoManager.playVideo(videoSinging);
                break;
            case "someone_special":
                videoManager.playVideo(videoSomeoneSpecial);
                playfieldManager.ShowLevel(12);
                break;
            
        }
        
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        //todo - kill active vids?
    }
}
