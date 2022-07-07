using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DarkTonic.MasterAudio;

/* ELF
    Tilt manager: Handles tilt & tilt warning
*/
public class TiltManager : MonoBehaviour
{
    public GameObject tiltObject;
    public TextMeshProUGUI tiltText;

    [SoundGroupAttribute] public string tilt;

#if UNITY_EDITOR
    private KeyboardInput mgr;
#endif

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mgr = GameObject.Find("TEST_ONLY").GetComponent<KeyboardInput>();
#endif
        // NOTE: BcpMessageManager does not handle these correctly, MUST add tags (tilt_warning,tilt,slam)
        // to the Unity scene Bcp Message Manager
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
        StartCoroutine(queueTilt("Warning"));
        // TODO
        //if (!warnings.IsNone)
        //  warnings.Value = e.Warnings;

        //if (!warningsRemaining.IsNone)
        //  warningsRemaining.Value = e.WarningsRemaining;
    }

    public void Tilt(object sender, BcpMessageEventArgs e)
    {
        StartCoroutine(queueTilt("Tilt"));
    }

    public void SlamTilt(object sender, BcpMessageEventArgs e)
    {
        StartCoroutine(queueTilt("Tilt"));
    }

    IEnumerator queueTilt(string msg)
    {
        tiltText.text =msg;
        tiltObject.SetActive(true);
        MasterAudio.PlaySound(tilt);
        yield return new WaitForSeconds(4);
        tiltObject.SetActive(false);
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
