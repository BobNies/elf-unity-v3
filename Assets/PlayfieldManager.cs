using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls UI on the small PF monitor
// show/hide objects per level
public class PlayfieldManager : MonoBehaviour
{
    public GameObject background;
    public GameObject attract;
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

    //private GameObject[] screens;

    // Start is called before the first frame update
    void Start()
    {
       // screens = new GameObject[] { Attract, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, L13};
        ShowLevel(0);
    }

    // 0 - attract
    // 1 - forest
    // 2 - gumdrop
    // 3 - tunnel
    // 4 - gimbels
    // 5 - coffee
    // 6 - nutcrackker
    // 7 - park
    // 8 - UNUSED

    // 9 - ball lock
    // 10 - jackpot
    // 11 - plunger skillshot
    // 12 - shoot ramp
    // 13 - special
    public void ShowLevel(int level)
    {
        Debug.Log("bob ShowLevel: " + level);
        //BcpLogger.Trace("bob ShowLevelb: " + level);
        hideAll();
       // if (level != 0)
        //{
            background.SetActive(true);
        //}
        
        // loop by a tag instead
        switch (level)
        {
            case 0:
                // attrack
               // background.SetActive(false);
                attract.SetActive(true);
                break;
            case 1:
                L1.SetActive(true);
                break;
            case 2:
                L2.SetActive(true);
                break;
            case 3:
                L3.SetActive(true);
                break;
            case 4:
                L4.SetActive(true);
                break;
            case 5:
                L5.SetActive(true);
                break;
            case 6:
                L6.SetActive(true);
                break;
            case 7:
                L7.SetActive(true);
                break;
            case 8:
               // L8.SetActive(true);
                break;
            case 9:
                L9.SetActive(true);
                break;
            case 10:
                L10.SetActive(true);
                break;
            case 11:
                L11.SetActive(true);
                break;
            case 12:
                L12.SetActive(true);
                break;
            case 13:
                L13.SetActive(true);
                break;
        }
    }

    private void hideAll()
    {
        attract.SetActive(false);
        L1.SetActive(false);
        L2.SetActive(false);
        L3.SetActive(false);
        L4.SetActive(false);
        L5.SetActive(false);
        L6.SetActive(false);
        L7.SetActive(false);
        L8.SetActive(false);
        L9.SetActive(false);
        L10.SetActive(false);
        L11.SetActive(false);
        L12.SetActive(false);
        L13.SetActive(false);

        //screens[level].SetActive(true);
    }
}
