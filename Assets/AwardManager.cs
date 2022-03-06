using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;
using TMPro;
using DG.Tweening;

public class AwardManager : MonoBehaviour
{
    public Transform awardTransform;
    public TextMeshProUGUI award1;
    public TextMeshProUGUI award2;
    public TextMeshProUGUI award3;
    public TextMeshProUGUI award4;

    // Start is called before the first frame update
    void Start()
    {
        resetAllAwards();
        //test only
        // tweenOut();
        //tweenIn();
    }

    public void resetAllAwards()
    {
        award1.text = "0";
        award2.text = "0";
        award3.text = "0";
        award4.text = "0";
    }

    public void tweenIn()
    {
        Vector3 v = new Vector3(100f, 0f);
        awardTransform.DOLocalMove(v, 1f).SetEase(Ease.InElastic);
    }

    public void tweenOut()
    {
        Vector3 v = new Vector3(-100f, 0f);
        awardTransform.DOLocalMove(v, 1f).SetEase(Ease.OutQuad);
    }
}
