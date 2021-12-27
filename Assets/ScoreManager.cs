using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public VideoManager videoManager;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI player3ScoreText;
    public TextMeshProUGUI player4ScoreText;

    private int currentPlayerNumber;
  
    void Start()
    {
        currentPlayerNumber = 0;
        BcpMessageController.OnPlayerScore += PlayerScore;
        videoManager.playVideo("bye_buddy");
    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerScore -= PlayerScore;
    }

    void Update()
    {
        if (currentPlayerNumber != Globals.playerNumber)
        {
            currentPlayerNumber = Globals.playerNumber;
            //TODO - listen for player change, update UI
        }
    }

    public void PlayerScore(object sender, PlayerScoreMessageEventArgs e)
    {
        int player = e.PlayerNum;
        int score = e.Value;
        int change = e.Change;
        int previousVal = e.PreviousValue;
        //  Debug.Log("bob ScoreReceived:" + score);
        switch (player)
        {
            case 1:
                player1ScoreText.text = score.ToString();
                break;
            case 2:
                player2ScoreText.text = score.ToString();
                break;
            case 3:
                player3ScoreText.text = score.ToString();
                break;
            case 4:
                player4ScoreText.text = score.ToString();
                break;
        }
        
    }  
}
