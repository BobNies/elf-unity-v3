using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public VideoManager videoManager;

    private TextMeshProUGUI scoreP1;
    private TextMeshProUGUI scoreP2;
    private TextMeshProUGUI scoreP3;
    private TextMeshProUGUI scoreP4;

    public GameObject playerOneTransform;
    public GameObject playerTwoTransform;
    public GameObject playerThreeTransform;
    public GameObject playerFourTransform;

    private int currentPlayerNumber;
  
    void Start()
    {
        scoreP1 = playerOneTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP2 = playerTwoTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP3 = playerThreeTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP4 = playerFourTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();

        // reset scores
        scoreP1.text = "0";

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
        int change = e.Change;
        int previousVal = e.PreviousValue;
        //  Debug.Log("bob ScoreReceived:" + score);
        switch (player)
        {
            case 1:             
                scoreP1.text = score.ToString();
                break;
            case 2:               
                scoreP2.text = score.ToString();
                break;
            case 3:               
                scoreP3.text = score.ToString();
                break;
            case 4:               
                scoreP4.text = score.ToString();
                break;
        }
        
    }  
}
