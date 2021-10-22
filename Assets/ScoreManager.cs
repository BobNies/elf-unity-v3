using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI player3Text;
    public TextMeshProUGUI player4Text;

    private int currentPlayerNumber;
  
    void Start()
    {
        currentPlayerNumber = 0;
        BcpMessageController.OnPlayerScore += PlayerScore;
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
        //  Debug.Log("bob ScoreReceived:" + score);
        switch (player)
        {
            case 1:
                player1Text.text = score.ToString();
                break;
            case 2:
                player2Text.text = score.ToString();
                break;
            case 3:
                player3Text.text = score.ToString();
                break;
            case 4:
                player4Text.text = score.ToString();
                break;
        }
        
    }  
}
