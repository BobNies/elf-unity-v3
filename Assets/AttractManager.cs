using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractManager : MonoBehaviour
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
        if (e.Name == "attract")
        {
            //TODO
        }
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        if (e.Name == "attract")
        {
            //TODO
        }
    }
}
