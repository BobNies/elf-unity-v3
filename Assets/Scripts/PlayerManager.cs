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
    //public VideoClip videoPlayerAdded;
    //public VideoClip videoPlayerTurnStart;

#if UNITY_EDITOR
    private KeyboardInput mgr;
    private int playerAddedCount = 1;
    private int playerStartedCount = 1;
#endif

    public ScoreManager scoreManager;

    [SoundGroupAttribute] public string playerOneAddedSound;
    [SoundGroupAttribute] public string playerTwoAddedSound;
    [SoundGroupAttribute] public string playerThreeAddedSound;
    [SoundGroupAttribute] public string playerFourAddedSound;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mgr = GameObject.Find("TEST_ONLY").GetComponent<KeyboardInput>();
#endif

        BcpMessageController.OnPlayerAdded += PlayerAdded;
        BcpMessageController.OnPlayerTurnStart += PlayerTurnStart;

        //test only
        //MasterAudio.PlaySound(playerOneAddedSound);
        //scoreManager.playerOneTransform.transform.DOScale(.5f, 1).SetEase(Ease.InElastic);
    }

    void OnDestroy()
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

        //if (videoPlayerAdded != null)
        //{
        //  videoManager.playVideo(videoPlayerAdded);
        //}

        switch (playerNum)
        {
            case 1:
                // Sound
                if (playerOneAddedSound != null)
                {
                    MasterAudio.PlaySound(playerOneAddedSound);
                }
                // Score UI animation - move it into the scene
                scoreManager.playerOneTransform.transform.DOMoveY(60, 1).SetEase(Ease.OutBounce);
                break;
            case 2:
                if (playerTwoAddedSound != null)
                {
                    MasterAudio.PlaySound(playerTwoAddedSound);
                }

                scoreManager.playerTwoTransform.transform.DOMoveY(60, 1).SetEase(Ease.OutBounce);
                break;
            case 3:
                if (playerThreeAddedSound != null)
                {
                    MasterAudio.PlaySound(playerThreeAddedSound);
                }

                scoreManager.playerThreeTransform.transform.DOMoveY(60, 1).SetEase(Ease.OutBounce);
                break;
            case 4:
                if (playerFourAddedSound != null)
                {
                    MasterAudio.PlaySound(playerFourAddedSound);
                }

                scoreManager.playerFourTransform.transform.DOMoveY(60, 1).SetEase(Ease.OutBounce);
                break;
        }
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        int playerNum = e.PlayerNum;
        currentPlayerNum = playerNum;

        // if (videoPlayerTurnStart != null && Globals.ballNumber == 2)
        //{
        //  videoManager.playVideo(videoPlayerTurnStart);
        //}

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

    // **** DEBUG
#if UNITY_EDITOR
  void Update()
    {
        if (Input.GetKeyDown(mgr.playerAdded))
        {
            Debug.Log("PlayerManager playerAdded");
            PlayerAdded(null, new PlayerAddedMessageEventArgs(null, playerAddedCount));
            playerAddedCount +=1;
        }
        else if (Input.GetKeyDown(mgr.playerTurnStarted))
        {
            PlayerTurnStart(null, new PlayerTurnStartMessageEventArgs(null, playerStartedCount));
            if (playerStartedCount == 4)
            {
                playerStartedCount = 1;
            } else 
            {
                playerStartedCount +=1;
            }
        }
       
    }
#endif

}

