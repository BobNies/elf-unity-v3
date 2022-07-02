using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using DarkTonic.MasterAudio;


public class GameEndManager : MonoBehaviour
{

    public VideoManager videoManager;
    public ScoreManager scoreManager;
    public BallCountUpdater ballCountUpdater;
    public AwardManager awardManager;
    public PlayerManager playerManager;
    public PlayfieldManager playfieldManager;

    private string modeName = "game";

    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnModeStop += ModeStop;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        BcpMessageController.OnModeStop -= ModeStop;
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {      
        if (!String.IsNullOrEmpty(modeName) && e.Name == modeName)
        {
            // kill all audio (or play small sound 1 time)
            StopPlaylist();
            // stop all videos
            videoManager.stopAllVideos();
            // reset scores
            scoreManager.ResetallScores();
            playerManager.resetScoreTransforms();
            // reset ball#
            ballCountUpdater.tweenOut();
            //reset awards
            awardManager.tweenOut();
            awardManager.resetAllAwardScores();
            // reset PF screen.
            playfieldManager.ShowLevel(0);  //TODO - show something before attract

            //Debug.Log("bob ModeStop - **********************************");
            //BcpLogger.Trace("bob ModeStop - **********************************");
        }

    }

    private void StopPlaylist()
    {
        MasterAudio.StopPlaylist();
    }

}
