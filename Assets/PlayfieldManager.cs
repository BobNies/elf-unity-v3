using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls UI on the small PF monitor
// show/hide objects per level
public class PlayfieldManager : MonoBehaviour
{

    public GameObject Attract;
    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject L5;
    public GameObject L6;
    public GameObject L7;
    public GameObject L8;
    public GameObject L9;
    public GameObject L10;
    public GameObject L11;
    public GameObject L12;
    public GameObject L13;

    private GameObject[] screens;

    // Start is called before the first frame update
    void Start()
    {
        screens = new GameObject[] { L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, L13, Attract };
    }

    // 1 -forest
    // 2 - park
    // 3 - coffee
    // 4 - gimbels
    // 5 - gumdrop
    // 6 - nutcrackker
    // 7 - nutcracker
    // 8 - park

    // 9 - ball lock
    // 10 - jackpot
    // 11 - plunger skillshot
    // 12 - shoot ramp
    // 13 - special
    public void ShowLevel(int level)
    {
        hideAllExcept(level);
        switch(level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                //attract
                break;
        }
    }

    private void hideAllExcept(int level)
    {
        foreach (GameObject obj in screens)
        {
            obj.SetActive(false);
        }

        screens[level - 1].SetActive(true);
    }
}
