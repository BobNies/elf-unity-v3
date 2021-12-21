using System;
using UnityEngine;
using DarkTonic.MasterAudio;

public class PlayerManager : MonoBehaviour
{
    public VideoManager videoManager;
    public string videoPlayerAdded;
    public string videoPlayerTurnStart;

    [SoundGroupAttribute] public string playerOneAddedSound;
    [SoundGroupAttribute] public string playerTwoAddedSound;
    [SoundGroupAttribute] public string playerThreeAddedSound;
    [SoundGroupAttribute] public string playerFourAddedSound;

    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnPlayerAdded += PlayerAdded;
        BcpMessageController.OnPlayerTurnStart += PlayerTurnStart;
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
                MasterAudio.PlaySound(playerOneAddedSound);
                break;
            case 2:
                MasterAudio.PlaySound(playerTwoAddedSound);
                break;
            case 3:
                MasterAudio.PlaySound(playerThreeAddedSound);
                break;
            case 4:
                MasterAudio.PlaySound(playerFourAddedSound);
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
    }

    }
