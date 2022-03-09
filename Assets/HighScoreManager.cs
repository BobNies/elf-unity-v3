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
     Listen for Event when a high_score_award_display BCP Trigger 
     Handles high-scores.
*/
public class ScoreManager : MonoBehaviour
{
    //public VideoManager videoManager;

    private string hightScoreAwardDisplay;  // show high scores
    private string highScoreEnterInitials; // player enters initials

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



        //High scores
        BcpServer.Instance.Send(BcpMessage.RegisterTriggerMessage(hightScoreAwardDisplay));
        BcpMessageController.OnTrigger += Trigger;

    }

    void OnDisable()
    {
        BcpMessageController.OnPlayerScore -= PlayerScore;
        BcpMessageController.OnTrigger -= Trigger;

    }

    /// <summary>
    /// Called every frame by Unity. Updates the timer.
    /// </summary>
    void Update()
    {
        timeoutSecondsRemaining -= Time.deltaTime;
        if (timeoutSecondsRemaining <= 0.0f)
        {
            //BcpLogger.Trace("GetBCPHighScoreEnterInitials: Timeout reached");
            // Abort();
        }

    }


    public void Trigger(object sender, TriggerMessageEventArgs e)
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
