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
        switch (e.Name)
        {
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
