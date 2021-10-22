using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that holds global variables so they can be accessible by other classes.
public class Globals : MonoBehaviour
{
    // Current player 1 thru 4
    public static int playerNumber;

    // Add BCP listeners that will update statics.
    void Start()
    {
        playerNumber = 0;

        BcpMessageController.OnPlayerTurnStart += PlayerTurnStart;
    }

    void OnDisable()
    {
        // Removes an 'OnModeStart' event handler
        BcpMessageController.OnPlayerTurnStart -= PlayerTurnStart;
    }

    public void PlayerTurnStart(object sender, PlayerTurnStartMessageEventArgs e)
    {
        playerNumber = e.PlayerNum;
    }
}
