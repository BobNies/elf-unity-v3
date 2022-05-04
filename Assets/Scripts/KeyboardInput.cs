using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

// For testing, using KB inputs.
// Disable in scene for production.
public class KeyboardInput : MonoBehaviour
{
    //public KeyCode startPressed;
    public string startPressed = "s";
    public string startLongPressed = "0";
    public string leftFliper = "z";
    public string rightFliper = "/";
    public string level1Start = "1";    //level_candy_cane_forest
    public string level2Start = "2";    //level_gumdrop
    public string level3Start = "3";    //level_lincoln_tunnel
    public string level4Start = "4";    //level_gimbels
    public string level5Start = "5";    //level_coffee
    public string level6Start = "6";    //level_nutcracker
    public string level7Start = "7";    //level_central_park

    public string modeAttractStart = "8";
    public string modeAttractStop = "9";

    public string playfield_skillshot = "d";
    // TODO -f, g

    public string lockLit = "n";
    public string multiballStart = "m";
    public string multiballComplete = "b";
    public string highScoreEnterInitials = "v";

    public string playerAdded = "q";
    public string playerTurnStarted = "w";

    public string award1 = "h";
    public string award2 = "j";
    public string award3 = "k";
    public string award4 = "l";
    public string tiltWarning = "y";
    public string tilt = "t";
    public string audioTest1 = ",";
    public string audioTest2 = ".";

#if UNITY_EDITOR
    [SoundGroupAttribute] public string[] ballEndSounds;
#endif

#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(audioTest1))
        {
            MasterAudio.PlaySound(ballEndSounds[0]);
        }
        else if (Input.GetKeyDown(audioTest2))
        {
            MasterAudio.PlaySound(ballEndSounds[1]);
        }
    }
#endif

}
