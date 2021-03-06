using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DarkTonic.MasterAudio;

public class AttractManager : MonoBehaviour
{
    public VideoManager videoManager;
    public ScoreManager scoreManager;
    public BallCountUpdater ballCountUpdater;
    public AwardManager awardManager;
    public BookFlip bookFlip;
    public Transform present;
    public bool playMusicOnStart = false;
    [MasterCustomEventAttribute] public string playlist;

    private PlayerManager playerManager;

    void Awake()
    {
        playerManager = this.gameObject.GetComponent<PlayerManager>();
    }

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
        if (e.Name == "attract")
        {
            //TODO - hide all play UI
            playerManager.resetScoreTransforms();
                // reset ball#
            ballCountUpdater.tweenOut();
            //reset awards
            awardManager.tweenOut();
            present.DOScale(0f, .5f); //SetEase(Ease.InElastic); // DOMove(new Vector3(0, 4, 0), 2);
            // play audio from Master playlist audioPlaylist
            if(playMusicOnStart && playlist != null)
            {
                MasterAudio.StartPlaylist(playlist);
            }
           
            //book
            bookFlip.tweenIn();
            //StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        //awardManager.tweenIn();
        bookFlip.tweenOut();
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        if (e.Name == "attract")
        {
            //TODO - put back play UI
            awardManager.tweenIn();
            Vector3 v = new Vector3(3, 3, 1);
            present.DOScale(v, .5f).SetEase(Ease.InElastic);
            ballCountUpdater.tweenIn();
            //hide book
            bookFlip.tweenOut();
            //stop audio
            MasterAudio.StopPlaylist();
        }
    }
}
