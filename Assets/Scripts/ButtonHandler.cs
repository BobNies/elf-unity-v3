using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine;

/* ELF
    Button handler used with the Service scene.
*/
public class ButtonHandler : Button
{
    private string switchName;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log("Down");
        sendEvent(1);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
       // Debug.Log("Up");
       // sendEvent(0);
    }

    public void SendBCPSwitch(string switchName)
    {
        this.switchName = switchName;
    }

    private void sendEvent(int switchState)
    {
        if (!String.IsNullOrEmpty(switchName))
            BcpServer.Instance.Send(BcpMessage.TriggerMessage(switchName));
        //BcpServer.Instance.Send(BcpMessage.TriggerMessage(switchName));
        //BcpServer.Instance.Send(BcpMessage.SwitchMessage(switchName, switchState));
    }
}
