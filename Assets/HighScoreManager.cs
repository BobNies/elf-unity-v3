using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using MText;
using DG.Tweening;
using BCP.SimpleJSON;
using DarkTonic.MasterAudio;

/* ELF
     Listen for Event when a high_score_award_display BCP Trigger 
     Handles high-scores.
*/
public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    public Modular3DText initial1 = null;
    [SerializeField]
    public Modular3DText initial2 = null;
    [SerializeField]
    public Modular3DText initial3 = null;
    [SerializeField]
    public Modular3DText selector = null;

    public BookHighScores bookHighScores;
    public BookFlip bookFlip;
    public GameObject highScoresContainer;
    public GameObject initialsContainer;

    // private string hightScoreAwardDisplay;  // show high scores
    // private string highScoreEnterInitials; // player enters initials

    // The maximum number of high score characters user is permitted
    private int maxCharacters;
    // The available characters the user is presented during intitial selection
    private string characterSet;
    private string shiftLeftEvent;
    private string shiftRightEvent;
    private string selectEvent;
    private float timeoutSeconds;

    private int currentCharacter;
    private int currentPosition;
    private List<string> initials = null;
    private List<string> characterList = null;
    private float timeoutSecondsRemaining;


    //TODO - hide onStart
    void Start()
    {
        // enter initials
        BcpMessageController.OnSwitch += Switch;
        //High scores
       // BcpServer.Instance.Send(BcpMessage.RegisterTriggerMessage("high_score_enter_initials"));
       // BcpMessageController.OnTrigger += Trigger;

       
    }

    void OnEnable()
    {
        reset();
        BuildCharacterList();
        //PositionChanged();
        //CharacterChanged();
        // resetUI
        bookFlip.tweenIn();
        bookFlip.turnToPageOneAndDisableFlip();
        highScoresContainer.SetActive(false);
        initialsContainer.SetActive(true);
        //play audio
        StartCoroutine(PlayClip());
    }

    void OnDestroy()
    {
        BcpMessageController.OnSwitch -= Switch;
       // BcpMessageController.OnTrigger -= Trigger;
    }

    /// <summary>
    /// Called every frame by Unity. Updates the timer.
    /// </summary>
    void Update()
    {
        timeoutSecondsRemaining -= Time.deltaTime;
        if (timeoutSecondsRemaining <= 0.0f)
        {
           // BcpLogger.Trace("HighScoreManager: Timeout reached");
            // Abort();
            // todo time out here, not mpf. send msg ?
        }

    }

    IEnumerator PlayClip()
    {
        yield return new WaitForSeconds(1);
        MasterAudio.PlaySound("whats_your_name");
    }

    private void reset() {
        maxCharacters = 3;
        timeoutSeconds = 60.0f;
        characterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_- ";
        shiftLeftEvent = "s_flipper_lt";
        shiftRightEvent = "s_flipper_rt";
        selectEvent = "s_start";
       
        currentCharacter = 0;
        currentPosition = 0;
        timeoutSecondsRemaining = timeoutSeconds;

        if (initials == null)
            initials = new List<string>(maxCharacters);
        else
            initials.Clear();

        for (int index = 0; index < maxCharacters; index++)
            initials.Add("");
    }

     public void Switch(object sender, SwitchMessageEventArgs e)
    {
        //BcpLogger.Trace("HighScoreManager: Switch (" + e.Name + ", " + e.State.ToString() + ")");

        if (e.State != 1)
            return;

        if (e.Name == shiftLeftEvent) ShiftLeft();
        else if (e.Name == shiftRightEvent) ShiftRight();
        else if (e.Name == selectEvent) Select();
    }

    public void Trigger(object sender, TriggerMessageEventArgs e)
    {
        // Determine if this trigger message is the one we are interested in.  If so, send specified FSM event.
        if (e.Name == "high_score_enter_initials")
        {
            //BcpLogger.Trace("HighScoreManager: Trigger (" + e.Name + ")");
            try
            {
                //TODO here
                //show book
                Debug.Log("bob tweenIn:");
                BcpLogger.Trace("bob tweenIn");
            }
            catch (Exception ex)
            {
                BcpServer.Instance.Send(BcpMessage.ErrorMessage("HighScoreManager An error occurred while processing a 'high_score_award_display' trigger message: " + ex.Message, e.BcpMessage.RawMessage));
            }

        }
    }

    // Called when user presses shift left button
    private void ShiftLeft()
    {
        BcpLogger.Trace("HighScoreManager: ShiftLeft");

        currentCharacter--;
        if (currentCharacter < 0)
            currentCharacter = characterList.Count - 1;

        CharacterChanged();
    }

    // Called when user presses shift right button
    private void ShiftRight()
    {
        BcpLogger.Trace("HighScoreManager: ShiftRight");

        currentCharacter++;
        if (currentCharacter >= characterList.Count)
            currentCharacter = 0;

        CharacterChanged();
    }

    // Called when user presses select button
    private void Select()
    {
        BcpLogger.Trace("HighScoreManager: Select");
        if (characterList[currentCharacter] == "back")
        {
            if (currentPosition > 0)
            {
                currentPosition--;
                PositionChanged();
            }

        }
        else if (characterList[currentCharacter] == "end")
        {
            Done();
        }
        else
        {
            string currentChar = characterList[currentCharacter];
            // Add selected character to saved initials string
            initials[currentPosition] += currentChar;

            // set UI
            Debug.Log("bob currentPosition:" + currentPosition);
            Debug.Log("bob initials:" + initials[currentPosition]);
            BcpLogger.Trace("bob: currentPosition:"+ currentPosition);
            BcpLogger.Trace("bob: text:" + initials[currentPosition]);
            switch (currentPosition)
            {
                case 0:
                    initial1.Text = currentChar;
                    break;
                case 1:
                    initial2.Text = currentChar;
                    break;
                case 2:
                    initial3.Text = currentChar;
                    break;
            }

            // Go to next position (or end)
            currentPosition++;
            if (currentPosition >= maxCharacters)
            {
                Debug.Log("bob currentPosition done:" + currentPosition);
                BcpLogger.Trace("bob: currentPosition DONE:" + currentPosition);
                Done();
            }
            else
            {
                PositionChanged();
                BuildCharacterList();
            }
        }
    }

    //Called whenever the current character changes
    private void CharacterChanged()
    {
        BcpLogger.Trace("HighScoreManager: CharacterChanged");
        selector.Text = characterList[currentCharacter];
    }

    // Called whenever the current character position changes
    private void PositionChanged() 
    {
        BcpLogger.Trace("HighScoreManager: PositionChanged");
    }

    private void BuildCharacterList() 
    {
        if (characterList == null)
            characterList = new List<string>();

        characterList.Clear();

        for (int index = 0; index < characterSet.Length; index++)
            characterList.Add(characterSet[index].ToString());

        if (currentCharacter > 1)
            characterList.Add("back");

        characterList.Add("end");
    }

    // Called internally when the user has completed entering their initials.
    private void Done()
    {
        BcpLogger.Trace("HighScoreManager: Done");

        string finalInitials = string.Join("", initials).TrimEnd();
        //if (!selectedInitials.IsNone)
          //  selectedInitials.Value = finalInitials;

        //Globals.championName = finalInitials;
        BcpMessage message = BcpMessage.TriggerMessage("text_input_high_score_complete");
        message.Parameters["text"] = new JSONString(finalInitials);
        BcpServer.Instance.Send(message);

        //reset UI
        highScoresContainer.SetActive(true);
        initialsContainer.SetActive(false);
        // update score on page 1  -- BookHighScore
        bookHighScores.Update();
        //TODO - update Champion Text here ?

    }

}
