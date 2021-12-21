using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{

    void Start()
    {
        BcpMessageController.OnModeStart += ModeStart;
        BcpMessageController.OnModeStop += ModeStop;
    }

    void OnDisable()
    {
        BcpMessageController.OnModeStart -= ModeStart;
        BcpMessageController.OnModeStop -= ModeStop;
    }

        public void ModeStart(object sender, ModeStartMessageEventArgs e)
    {
        //TODO - switch on mode names
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        //todo
    }
}
