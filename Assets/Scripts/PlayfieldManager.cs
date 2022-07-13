using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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
    public GameObject LSkillShot;
    public GameObject LBallLock;
    public GameObject LJackpot;
    public GameObject LRampShot;
    public GameObject LSpecial;
    public GameObject LOmg;

    public GameObject Award;
    private TextMeshProUGUI awardText;

    public GameObject[] allScreens;

    // Start is called before the first frame update
    void Start()
    {
        if (allScreens.Length == 0)
            allScreens = GameObject.FindGameObjectsWithTag("playfield");
        //Debug.Log("bob allScreens len: " + allScreens.Length);
        awardText = Award.transform.Find("TextAward").GetComponent<TextMeshProUGUI>();
        ShowLevel(0);
    }

    public void ShowAward(string text, int delay = 3)
    {
        Award.SetActive(true);
        awardText.text = text;
        DOTween.Restart("AwardText");
        StartCoroutine(HideAward(delay));
    }

    IEnumerator HideAward(int delay)
    {
        yield return new WaitForSeconds(delay);
        Award.SetActive(false);
    }

    // 0 - attract
    // 1 - forest
    // 2 - gumdrop
    // 3 - tunnel
    // 4 - gimbels
    // 5 - coffee
    // 6 - nutcrackker
    // 7 - park

    // 8 - skillshot
    // 9 - ball lock
    // 10 - jackpot
    // 11 - plunger skillshot
    // 12 - shoot ramp
    // 13 - special
    public void ShowLevel(int level)
    {
        hideAll();
        //Debug.Log("bob ShowLevel: " + level);

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
                LSkillShot.SetActive(true);
                break;
            case 9:
                LBallLock.SetActive(true);
                break;
            case 10:
                LJackpot.SetActive(true);
                break;
            case 11:
                LRampShot.SetActive(true);
                break;
            case 12:
                LSpecial.SetActive(true);
                break;
            case 13:
                LOmg.SetActive(true);
                break;
        }
    }

    private void hideAll()
    {
        foreach (GameObject go in allScreens)
        {
            go.SetActive(false);
        }
    }

}
