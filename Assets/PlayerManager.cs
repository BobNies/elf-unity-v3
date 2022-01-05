using System;
using UnityEngine;
using DarkTonic.MasterAudio;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public VideoManager videoManager;
    public string videoPlayerAdded;
    public string videoPlayerTurnStart;

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

        //Test mode only
        // scoreManager.playerOneTransform.transform.DOMoveY(100, 1);
        // scoreManager.playerOneTransform.transform.DOScale(1, 1);

        //scoreManager.playerOneTransform.transform.DOMoveY(-30, 1).SetRelative();
        //scoreManager.playerOneTransform.transform.DOScale(.5f, 1);
        //scoreManager.playerTwoTransform.transform.DOMoveY(30f, 1).SetRelative();
        //scoreManager.playerTwoTransform.transform.DOMoveX(-20f, 1).SetRelative();
        //scoreManager.playerTwoTransform.transform.DOScale(.8f, 1);
    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerAdded -= PlayerAdded;
        BcpMessageController.OnPlayerTurnStart -= PlayerTurnStart;
    }

    public void PlayerAdded(object sender, PlayerAddedMessageEventArgs e)
    {
        
        // TODO switch on playerNum
        int playerNum = e.PlayerNum;
        
        if (!String.IsNullOrEmpty(videoPlayerAdded))
        {
            videoManager.playVideo(videoPlayerAdded);
        }

        switch (playerNum)
        {
            case 1:
                // Sound
                MasterAudio.PlaySound(playerOneAddedSound);
                // Score UI animation - move it into the scene
                scoreManager.playerOneTransform.transform.DOMoveY(100, 1);
                break;
            case 2:
                MasterAudio.PlaySound(playerTwoAddedSound);
                scoreManager.playerTwoTransform.transform.DOMoveY(100, 1);
                break;
            case 3:
                MasterAudio.PlaySound(playerThreeAddedSound);
                scoreManager.playerThreeTransform.transform.DOMoveY(100, 1);
                break;
            case 4:
                MasterAudio.PlaySound(playerFourAddedSound);
                scoreManager.playerFourTransform.transform.DOMoveY(100, 1);
                break;
        }
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        // TODO switch on playerNum
        int playerNum = e.PlayerNum;
        if (!String.IsNullOrEmpty(videoPlayerTurnStart))
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
                if (Globals.ballNumber > 1)
                {
                    // already scaled up for ball 1
                    scoreManager.playerOneTransform.transform.DOScale(.8f, 1);
                    scoreManager.playerOneTransform.transform.DOMoveY(30, 1);
                }
                break;
            case 2:
                scoreManager.playerTwoTransform.transform.DOScale(.8f, 1);
                scoreManager.playerTwoTransform.transform.DOMoveY(30, 1);
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOScale(.8f, 1);
                scoreManager.playerThreeTransform.transform.DOMoveY(30, 1);
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOScale(.8f, 1);
                scoreManager.playerFourTransform.transform.DOMoveY(30, 1);
                break;
        }

        // minimize the previous player score widget
        switch (Globals.playerNumberPrevious)
        {
            case 1:
                scoreManager.playerOneTransform.transform.DOScale(.5f, 1);
                scoreManager.playerOneTransform.transform.DOMoveY(-30, 1);
                break;
            case 2:              
                scoreManager.playerTwoTransform.transform.DOScale(.5f, 1);
                scoreManager.playerTwoTransform.transform.DOMoveY(-30, 1);
                break;
            case 3:
                scoreManager.playerThreeTransform.transform.DOScale(.5f, 1);
                scoreManager.playerThreeTransform.transform.DOMoveY(-30, 1);
                break;
            case 4:
                scoreManager.playerFourTransform.transform.DOScale(.5f, 1);
                scoreManager.playerFourTransform.transform.DOMoveY(-30, 1);
                break;
        }
    }

    }
