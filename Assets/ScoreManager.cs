using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public VideoManager videoManager;

    //public TextMeshProUGUI player1ScoreText;

    public GameObject playerOneTransform;
    public GameObject playerTwoTransform;
    public GameObject playerThreeTransform;
    public GameObject playerFourTransform;

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
                var scoreP1 = playerOneTransform.transform.Find("score").GetComponent<Text>();
                scoreP1.text = score.ToString();
                //player1ScoreText.text = score.ToString();
                break;
            case 2:
                var scoreP2 = playerTwoTransform.transform.Find("score").GetComponent<Text>();
                scoreP2.text = score.ToString();
                break;
            case 3:
                var scoreP3 = playerThreeTransform.transform.Find("score").GetComponent<Text>();
                scoreP3.text = score.ToString();
                break;
            case 4:
                var scoreP4 = playerFourTransform.transform.Find("score").GetComponent<Text>();
                scoreP4.text = score.ToString();
                break;
        }
        
    }  
}
