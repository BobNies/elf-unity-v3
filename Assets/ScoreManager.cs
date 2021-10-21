using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }

    // Called just after the Unity object is enabled. This happens when a MonoBehaviour instance is created.
    void Start()
    {
        // Adds an 'OnModeStart' event handler
        BcpMessageController.OnPlayerScore += PlayerScore;
        Debug.Log("bob onEnable");
    }

    // Called when the Unity object becomes disabled or inactive
    void OnDisable()
    {
        // Removes an 'OnModeStart' event handler
        BcpMessageController.OnPlayerScore -= PlayerScore;
    }

    // OnModeStart event handler function
    public void PlayerScore(object sender, PlayerScoreMessageEventArgs e)
    {
        // Put mode start code here
        int score = e.Value;
        playerScoreText.text = score.ToString();
        Debug.Log("bob ScoreReceived:" + score);
    }  
}
