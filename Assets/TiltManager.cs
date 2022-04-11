using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ELF
    Tilt manager: Handles tilt & tilt warning
*/
public class TiltManager : MonoBehaviour
{

#if UNITY_EDITOR
    private KeyboardInput mgr;
#endif

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mgr = GameObject.Find("TEST_ONLY").GetComponent<KeyboardInput>();
#endif

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

        // **** DEBUG
#if UNITY_EDITOR
  void Update()
    {
     if (Input.GetKeyDown(mgr.tilt))
        {
            Debug.Log("Tiltmanager TILT pressed");
            Tilt(null, null);
        }
     else  if (Input.GetKeyDown(mgr.tiltWarning))
        {
            Debug.Log("Tiltmanager tiltWarning pressed");
            TiltWarning(null, null);
        }
    
    }
#endif

}
