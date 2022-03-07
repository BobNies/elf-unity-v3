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
                scoreManager.playerOneTransform.transform.DOLocalMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOLocalMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOLocalMoveY(-100, 1).SetEase(Ease.OutBounce);
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOLocalMoveY(-100, 1).SetEase(Ease.OutBounce);
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
        for (int i = 0; i < numberOfPlayers; i++)
        {
            PlayerRemoved(i);
        }         
    }

}

