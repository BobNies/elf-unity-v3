using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ELF
    Tilt manager: Handles tilt & tilt warning
*/
public class TiltManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnTiltWarning += TiltWarning;
        BcpMessageController.OnTilt += Tilt;
        BcpMessageController.OnSlamTilt += SlamTilt;
    }

    void OnDestroy()
    {
        BcpMessageController.OnTiltWarning -= TiltWarning;
        BcpMessageController.OnTilt -= Tilt;
        BcpMessageController.OnSlamTilt -= SlamTilt;
    }

    public void TiltWarning(object sender, TiltWarningMessageEventArgs e)
    {
        // TODO
        //if (!warnings.IsNone)
        //  warnings.Value = e.Warnings;

        //if (!warningsRemaining.IsNone)
        //  warningsRemaining.Value = e.WarningsRemaining;
    }

    public void Tilt(object sender, BcpMessageEventArgs e)
    {
        // TODO
    }

    public void SlamTilt(object sender, BcpMessageEventArgs e)
    {
        // TODO
    }
}
