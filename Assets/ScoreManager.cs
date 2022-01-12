using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

/* ELF
     Score manager: listen for score/points changes and update users's score.
     Handles high-scores.
*/
public class ScoreManager : MonoBehaviour
{
    public VideoManager videoManager;

    private TextMeshProUGUI scoreP1;
    private TextMeshProUGUI scoreP2;
    private TextMeshProUGUI scoreP3;
    private TextMeshProUGUI scoreP4;

    private string hightScoreAwardDisplay = "high_score_award_display";  // show high scores
    private string highScoreEnterInitials = "high_score_enter_initials"; // player enters initials

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

        //High scores
        BcpServer.Instance.Send(BcpMessage.RegisterTriggerMessage(hightScoreAwardDisplay));
        BcpMessageController.OnTrigger += HighScoreAward;

    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerScore -= PlayerScore;
        BcpMessageController.OnTrigger -= HighScoreAward;

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

     public void HighScoreAward(object sender, TriggerMessageEventArgs e)
    {
        // Determine if this trigger message is the one we are interested in.  If so, send specified FSM event.
        if (!String.IsNullOrEmpty(hightScoreAwardDisplay) && e.Name == hightScoreAwardDisplay)
        {
            try
            {
                String award = e.BcpMessage.Parameters["award"].Value;
                String playerName = e.BcpMessage.Parameters["player_name"].Value;
                String value = e.BcpMessage.Parameters["value"].AsInt;
                //TODO - show player initial Scene.
            }
            catch (Exception ex)
            {
                BcpServer.Instance.Send(BcpMessage.ErrorMessage("An error occurred while processing a 'high_score_award_display' trigger message: " + ex.Message, e.BcpMessage.RawMessage));
            }

        }
    }
}
