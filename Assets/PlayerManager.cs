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
    private int numberOfPlayers = 0;
    private int currentPlayerNum = 0;

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

        //test only
        //MasterAudio.PlaySound(playerOneAddedSound);
        //scoreManager.playerOneTransform.transform.DOScale(.5f, 1).SetEase(Ease.InElastic);
    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerAdded -= PlayerAdded;
        BcpMessageController.OnPlayerTurnStart -= PlayerTurnStart;
    }

    private void PlayerRemoved(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                // 0 to view, -100 to hide
                scoreManager.playerOneTransform.transform.DOMoveY(-100, 1).SetEase(Ease.OutBounce);
                scoreManager.playerOneTransform.transform.DOScale(.8f, 1).SetEase(Ease.InElastic);
                //scoreManager.playerOneTransform.transform.DOScale(1, 1).SetEase(Ease.InElastic);
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
        }
    }

    public void PlayerAdded(object sender, PlayerAddedMessageEventArgs e)
    {
        int playerNum = e.PlayerNum;
        numberOfPlayers = playerNum;

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
                scoreManager.playerOneTransform.transform.DOMoveY(50, 1).SetEase(Ease.OutBounce);
                break;
            case 2:
                MasterAudio.PlaySound(playerTwoAddedSound);
                scoreManager.playerTwoTransform.transform.DOMoveY(50, 1).SetEase(Ease.OutBounce);
                break;
            case 3:
                MasterAudio.PlaySound(playerThreeAddedSound);
                scoreManager.playerThreeTransform.transform.DOMoveY(50, 1).SetEase(Ease.OutBounce);
                break;
            case 4:
                MasterAudio.PlaySound(playerFourAddedSound);
                scoreManager.playerFourTransform.transform.DOMoveY(50, 1).SetEase(Ease.OutBounce);
                break;
        }
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        int playerNum = e.PlayerNum;
        currentPlayerNum = playerNum;

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
                scoreManager.playerOneTransform.transform.DOScale(.8f, 1).SetEase(Ease.InElastic);
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOScale(.8f, 1).SetEase(Ease.InElastic);
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOScale(.8f, 1).SetEase(Ease.InElastic);
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOScale(.8f, 1).SetEase(Ease.InElastic);
                break;
        }

        // minimize the previous player score widget
        minimizeCurrentScore(Globals.playerNumberPrevious);
    }

    private void minimizeCurrentScore(int playerNum)
    {
        switch (playerNum)
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

    public void resetScoreTransforms()
    {
        // minimize last player
        minimizeCurrentScore(currentPlayerNum);
        // loop each player - move off screen
        for (int i = 1; i < 5; i++)
        {           
            PlayerRemoved(i);
        }         
    }

}

