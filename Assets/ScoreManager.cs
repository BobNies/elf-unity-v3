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

    private int currentPlayerNumber;

    private string hightScoreAwardDisplay;  // show high scores
    private string highScoreEnterInitials; // player enters initials

    public GameObject playerOneTransform;
    public GameObject playerTwoTransform;
    public GameObject playerThreeTransform;
    public GameObject playerFourTransform;

    // The maximum number of high score characters user is permitted
    private int maxCharacters;
    // The available characters the user is presented during intitial selection
    private string characterSet;
    private string shiftLeftEvent;
    private string shiftRightEvent;
    private string selectEvent;
    private string abortEvent;
    private float timeoutSeconds;

    private int currentCharacter;
    private int currentPosition;
    private List<string> initials = null;
    //private List<string> characterList = null;
    private float timeoutSecondsRemaining;

    void Awake()
    {

    }

    void Start()
    {
        hightScoreAwardDisplay = "high_score_award_display";
        highScoreEnterInitials = "high_score_enter_initials";

        maxCharacters = 3;
        // characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_- ";
        shiftLeftEvent = "s_flipper_lt";
        shiftRightEvent = "s_flipper_rt";
        selectEvent = "s_start";
        abortEvent = "sw_esc";
        timeoutSeconds = 20.0f;
        // TODO - move high score to own file.
        currentCharacter = 0;
        currentPosition = 0;
        timeoutSecondsRemaining = timeoutSeconds;

        if (initials == null)
            initials = new List<string>(maxCharacters);
        else
            initials.Clear();

        for (int index = 0; index < maxCharacters; index++)
            initials.Add("");

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

        timeoutSecondsRemaining -= Time.deltaTime;
        if (timeoutSecondsRemaining <= 0.0f)
        {
            BcpLogger.Trace("GetBCPHighScoreEnterInitials: Timeout reached");
            // Abort();
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
                string award = e.BcpMessage.Parameters["award"].Value;
                string playerName = e.BcpMessage.Parameters["player_name"].Value;
                int value = e.BcpMessage.Parameters["value"].AsInt;
                //TODO - show player initial Scene.
            }
            catch (Exception ex)
            {
                BcpServer.Instance.Send(BcpMessage.ErrorMessage("An error occurred while processing a 'high_score_award_display' trigger message: " + ex.Message, e.BcpMessage.RawMessage));
            }

        }
    }
}
