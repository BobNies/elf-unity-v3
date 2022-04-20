using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Class that holds global variables so they can be accessible by other classes.
*/
public class Globals : MonoBehaviour
{
    // Current player 1 thru 4
    public static int playerNumber;
    public static int ballNumber;

    public static int playerNumberPrevious;

    public static string championName;

    // Add BCP listeners that will update statics.
    void Start()
    {
        playerNumber = 0;
        championName = "";

        BcpMessageController.OnPlayerTurnStart += PlayerTurnStart;
        BcpMessageController.OnBallStart += BallStart;
    }

    void OnDisable()
    {
        // Removes an 'OnModeStart' event handler
        BcpMessageController.OnPlayerTurnStart -= PlayerTurnStart;
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        playerNumberPrevious = playerNumber;
        playerNumber = e.PlayerNum;
    }

    public void BallStart(object sender, BallStartMessageEventArgs e)
    {
        ballNumber = e.Ball;
    }
}
