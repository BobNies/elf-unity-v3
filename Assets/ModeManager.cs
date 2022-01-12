using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ELF
// Mode manager: Listen for modes to start/stop and update the UI.
// Normally we will play videos, sounds, trigger UI effects (b-day box animations)
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
        switch (e.Name)
        {
            //TODO - play videos
            case "start_singing":
                break;
            case "snow_fight":
                break;
            case "someone_special":
                break;
            case "lvl_best_coffee":
                break;
            case "lvl_candy_cane_forest":
                break;
            case "lvl_central_park":
                break;
            case "lvl_gimbels":
                break;
            case "lvl_lincoln_tunnel":
                break;
            case "lvl_nutcracker":
                break;
            case "lvl_sea_gumdrop":
                break;
        }
        
    }

    public void ModeStop(object sender, ModeStopMessageEventArgs e)
    {
        //todo
    }
}
