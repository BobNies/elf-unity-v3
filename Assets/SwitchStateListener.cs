using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//play sound FX's based on switch events

public class SoundFxManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnSwitch += Switch;
    }

    void OnDestroy()
    {
        BcpMessageController.OnSwitch -= Switch;
        // BcpMessageController.OnTrigger -= Trigger;
    }

    public void Switch(object sender, SwitchMessageEventArgs e)
    {
        //BcpLogger.Trace("HighScoreManager: Switch (" + e.Name + ", " + e.State.ToString() + ")");

        if (e.State != 1)
            return;

       // if (e.Name == shiftLeftEvent) ShiftLeft();
       // else if (e.Name == shiftRightEvent) ShiftRight();
       // else if (e.Name == selectEvent) Select();
    }

}
