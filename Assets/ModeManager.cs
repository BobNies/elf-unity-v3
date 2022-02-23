using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ELF
// Mode manager: Listen for modes to start/stop and update the UI.
// Normally we will play videos, sounds, trigger UI effects (b-day box animations)
public class ModeManager : MonoBehaviour
{
    public VideoManager videoManager;
    public string videoCandyCaneForest;
    public string videoCentralPark;
    public string videoCoffee;
    public string videoGimbels;
    public string videoGumdrop;
    public string videoLincolnTunnel;
    public string videoNutcracker;
    //public string videoBallLock;
    public string videoOmg;
    public string videoSinging;
    public string videoSomeoneSpecial;

    void Start()
    {
        BcpMessageController.OnModeStart += ModeStart;
        BcpMessageController.OnModeStop += ModeStop;
    }

    void OnDisable()
    {
        BcpMessageController.OnModeStart -= ModeStart;
        BcpMessageController.OnModeStop -= ModeStop;
    }

        public void ModeStart(object sender, ModeStartMessageEventArgs e)
    {
        //TODO - only play on ball 1
        if (Globals.ballNumber > 1) { return; }
        Debug.Log("bob ModeStart:" + e.Name);
        BcpLogger.Trace("ModeStart: " + e.Name);
        switch (e.Name)
        {
            // case "attract": // TODO- handle n attractManager
            // 7 levels
            case "level_candy_cane_forest":
                videoManager.playVideo(videoCandyCaneForest);
                break;
            case "level_central_park":
                videoManager.playVideo(videoCentralPark);
                break;
            case "level_coffee":
                videoManager.playVideo(videoCoffee);
                break;
            case "level_gimbels":
                videoManager.playVideo(videoGimbels);
                break;
            case "level_gumdrop":
                videoManager.playVideo(videoGumdrop);
                break;
            case "level_lincoln_tunnel":
                videoManager.playVideo(videoLincolnTunnel);
                break;
            case "level_nutcracker":
                videoManager.playVideo(videoNutcracker);
                break;
            // sub-levels
            case "ball_lock":
                break;
            case "end_of_ball_bonus":
                break;
            case "jackpot":
                break;
            case "jet_bonus":
                break;
            case "omg":
                videoManager.playVideo(videoOmg);
                break;
            case "plunger_skill_shot":
                break;
            case "ramp_shot":
                break;
            case "singing":
                videoManager.playVideo(videoSinging);
                break;
            case "someone_special":
                videoManager.playVideo(videoSomeoneSpecial);
                break;
            
        }
        
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        //todo
    }
}
