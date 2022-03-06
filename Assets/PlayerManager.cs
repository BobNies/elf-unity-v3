using System;
using UnityEngine;
using DarkTonic.MasterAudio;
using UnityEngine.Video;
using DG.Tweening;

/* ELF
    Player Manager: tracks players added/removed, game reset
    Handles player score UI animations
*/
public class PlayerManager : MonoBehaviour
{
    private bool animatePlayerOneScore = false;

    public VideoManager videoManager;
    public VideoClip videoPlayerAdded;
    public VideoClip videoPlayerTurnStart;

    public ScoreManager scoreManager;

    [SoundGroupAttribute] public string playerOneAddedSound;
    [SoundGroupAttribute] public string playerTwoAddedSound;
    [SoundGroupAttribute] public string playerThreeAddedSound;
    [SoundGroupAttribute] public string playerFourAddedSound;

    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnPlayerAdded += PlayerAdded;
        BcpMessageController.OnPlayerTurnStart += PlayerTurnStart;
        //BcpMessageController.OnBallEnd += BallEnd;
        // catch all Triggers not predefined in BcpMessageController
        BcpMessageController.OnTrigger += Trigger; //TODO - move to separate

        //test only
        //MasterAudio.PlaySound(playerOneAddedSound);
        //scoreManager.playerOneTransform.transform.DOScale(.5f, 1).SetEase(Ease.InElastic);
    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerAdded -= PlayerAdded;
        BcpMessageController.OnPlayerTurnStart -= PlayerTurnStart;
        //BcpMessageController.OnBallEnd += BallEnd;
        //BcpMessageController.OnTrigger -= Trigger;
    }

    public void PlayerAdded(object sender, PlayerAddedMessageEventArgs e)
    {

        int playerNum = e.PlayerNum;

        if (videoPlayerAdded != null)
        {
            videoManager.playVideo(videoPlayerAdded);
        }

        switch (playerNum)
        {
            case 1:
                // Sound
                MasterAudio.PlaySound(playerOneAddedSound);
                // Score UI animation - move it into the scene
                // 0 to view, -100 to hide
                scoreManager.playerOneTransform.transform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
                break;
            case 2:
                MasterAudio.PlaySound(playerTwoAddedSound);
                scoreManager.playerTwoTransform.transform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
                break;
            case 3:
                MasterAudio.PlaySound(playerThreeAddedSound);
                scoreManager.playerThreeTransform.transform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
                break;
            case 4:
                MasterAudio.PlaySound(playerFourAddedSound);
                scoreManager.playerFourTransform.transform.DOLocalMoveY(0, 1).SetEase(Ease.OutBounce);
                break;
        }
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        // TODO switch on playerNum
        int playerNum = e.PlayerNum;
        if (videoPlayerTurnStart != null && Globals.ballNumber == 2)
        {
            videoManager.playVideo(videoPlayerTurnStart);
        }

        if (playerNum == Globals.playerNumberPrevious)
        {
            // 1 player or same player(shoot again)
            return;
        }

        // Move/Expand the score widget
        switch (playerNum)
        {
            case 1:
                if (animatePlayerOneScore)
                {
                    // already scaled up for ball 1
                    scoreManager.playerOneTransform.transform.DOScale(1f, 1).SetEase(Ease.InElastic);
                }

                animatePlayerOneScore = true;
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOScale(1, 1).SetEase(Ease.InElastic);
               
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOScale(1, 1).SetEase(Ease.InElastic);
               
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOScale(1, 1).SetEase(Ease.InElastic);
               
                break;
        }

        // minimize the previous player score widget
        switch (Globals.playerNumberPrevious)
        {
            case 1:
                scoreManager.playerOneTransform.transform.DOScale(.5f, 1);
               
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOScale(.5f, 1);
                
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOScale(.5f, 1);
               
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOScale(.5f, 1);
               
                break;
        }
    }

    //All other messages
    public void Trigger(object sender, TriggerMessageEventArgs e)
    {
        // Determine if this trigger message is the one we are interested in. 
        string name = e.Name;
        Debug.Log("bob triggner:" + name);
        if (name == "game_ended") // game_cancel_released
        {
            //TODO - finish -- reset
            //Start button long-pressed: restart game
            scoreManager.playerOneTransform.transform.DOScale(.8f, 1);
            scoreManager.playerOneTransform.transform.DOMoveY(100, 1);
        }
    }

}

