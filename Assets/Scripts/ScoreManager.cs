using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using DG.Tweening;
using DarkTonic.MasterAudio;

/* ELF
     Score manager: listen for score/points changes and update users's score.
     Handles high-scores.
*/
public class ScoreManager : MonoBehaviour
{
    public VideoManager videoManager;
    public PresentManager presentManager;
    [Tooltip("The minimum award value(score) to pop the box top")]
    public int minScorePopBox = 1000000;
    [Tooltip("Sound FX played when the box top pops")]
    [SoundGroupAttribute] public string popBoxTopSound;

    private TextMeshProUGUI scoreP1;
    private TextMeshProUGUI scoreP2;
    private TextMeshProUGUI scoreP3;
    private TextMeshProUGUI scoreP4;

    private int currentPlayerNumber;

    [Tooltip("Object that includes the displayed score 1")]
    public GameObject playerOneTransform;
    [Tooltip("Object that includes the displayed score 2")]
    public GameObject playerTwoTransform;
    [Tooltip("Object that includes the displayed score 3")]
    public GameObject playerThreeTransform;
    [Tooltip("Object that includes the displayed score 4")]
    public GameObject playerFourTransform;


    void Start()
    {
        scoreP1 = playerOneTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP2 = playerTwoTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP3 = playerThreeTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        scoreP4 = playerFourTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();

        // reset scores
        scoreP1.text = "0";
        scoreP2.text = "0";
        scoreP3.text = "0";
        scoreP4.text = "0";

        currentPlayerNumber = 0;
        BcpMessageController.OnPlayerScore += PlayerScore;

    }

    void OnDestroy()
    {
        BcpMessageController.OnPlayerScore -= PlayerScore;

    }

    /// <summary>
    /// Called every frame by Unity. Updates the timer.
    /// </summary>
    void Update()
    {
        if (currentPlayerNumber != Globals.playerNumber)
        {
            currentPlayerNumber = Globals.playerNumber;
            //TODO - listen for player change, update UI
        }

    }

    public void ResetallScores()
    {
        scoreP1.text = "0";
        scoreP2.text = "0";
        scoreP3.text = "0";
        scoreP4.text = "0";

    }

    public void PlayerScore(object sender, PlayerScoreMessageEventArgs e)
    {
        int player = e.PlayerNum;
        int score = e.Value;
        int change = e.Change;
        //int previousVal = e.PreviousValue;
        string newScore = score.ToString("n0"); //"#,#"
        string newBoxScore = change.ToString("n0");

        //format with commas


        // if score > 1mil, pop the box with score
        if (change >= minScorePopBox)
        {
            presentManager.updateScoreText(newBoxScore);
            //TODO - find better sound
            MasterAudio.PlaySound(popBoxTopSound);
        }

        switch (player)
        {
            case 1:
                scoreP1.text = newScore;
                break;
            case 2:
                scoreP2.text = newScore;
                break;
            case 3:
                scoreP3.text = newScore;
                break;
            case 4:
                scoreP4.text = newScore;
                break;
        }

    }


}