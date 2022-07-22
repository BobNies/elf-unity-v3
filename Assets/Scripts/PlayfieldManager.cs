using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

// Controls UI on the small PF monitor
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
    private GameObject currentScreen;
    private float tweenTime = .2f;


    // Start is called before the first frame update
    void Start()
    {
        awardText = Award.transform.Find("TextAward").GetComponent<TextMeshProUGUI>();
        ShowLevel(0);
    }

    public void ShowAward(string text, int delay = 3)
    {
        Award.transform.DOLocalMoveY(0, 0).SetEase(Ease.OutQuad);
        awardText.text = text;
        DOTween.Restart("AwardText");
        StartCoroutine(HideAward(delay));
    }

    IEnumerator HideAward(int delay)
    {
        yield return new WaitForSeconds(delay);
        Award.transform.DOLocalMoveY(900, 0).SetEase(Ease.OutQuad);
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
        //Debug.Log("bob ShowLevel: " + level);
        // move out current screen
        if (currentScreen != null)
        {
            currentScreen.transform.DOLocalMoveY(900, tweenTime).SetEase(Ease.OutQuad);
        }

        switch (level)
        {
            case 0:
                moveScreen(attract);
                break;
            case 1:
                moveScreen(L1);
                break;
            case 2:
                moveScreen(L2);
                break;
            case 3:
                moveScreen(L3);
                break;
            case 4:
                moveScreen(L4);
                break;
            case 5:
                moveScreen(L5);
                break;
            case 6:
                moveScreen(L6);
                break;
            case 7:
                moveScreen(L7);
                break;
            case 8:
                moveScreen(LSkillShot);
                break;
            case 9:
                moveScreen(LBallLock);
                break;
            case 10:
                moveScreen(LJackpot);
                break;
            case 11:
                moveScreen(LRampShot);
                break;
            case 12:
                moveScreen(LSpecial);
                break;
            case 13:
                moveScreen(LOmg);
                break;
        }
    }

    private void moveScreen(GameObject level)
    {
        level.transform.DOLocalMoveY(0, tweenTime).SetEase(Ease.OutQuad);
        currentScreen = level;
    }

}
