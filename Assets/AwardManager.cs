using System;
using UnityEngine;
using MText;
using TMPro;
using DG.Tweening;

// award icons on top right:
// icon 1: spinner
// icon 2: pops
// icon 3: inner loop
// icon 4: outer loop
// vuk

public class AwardManager : MonoBehaviour
{
    public Transform awardTransform;
    public TextMeshProUGUI textAward1;
    public TextMeshProUGUI textAward2;
    public TextMeshProUGUI textAward3;
    public TextMeshProUGUI textAward4;

    [Tooltip("The name of the BCP Trigger to listen for. Should be a Counter.events_when_hit")]
    public string triggerAward1;
    public string triggerAward2;
    public string triggerAward3;
    public string triggerAward4;

    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnTrigger += Trigger;

        resetAllAwards();
        //test only
        // tweenOut();
        //tweenIn();
    }

    void OnDestroy()
    {
        BcpMessageController.OnTrigger -= Trigger;
    }

    public void Trigger(object sender, TriggerMessageEventArgs e)
    {
        // To receive a trigger, it MUST be registered in BcpMessageManager
        //  #Event: ======'spinner_collect_award'====== Args={'count': 3}
        string name = e.Name;
        //Debug.Log("bob name:" + name);
        //BcpLogger.Trace("bob name: " + name);
        string count = e.BcpMessage.Parameters["count"].Value;
       
        if (name == triggerAward1)
        {           
            textAward1.text = count;
        }
        else if (name == triggerAward2)
        {
            textAward2.text = count;
        }
        else if (name == triggerAward3)
        {
            textAward3.text = count;
        }
        else
        {
            textAward4.text = count;
        }

    }

    public void resetAllAwards()
    {
        textAward1.text = "0";
        textAward2.text = "0";
        textAward3.text = "0";
        textAward4.text = "0";
    }

    public void tweenIn()
    {
        awardTransform.DOLocalMoveX(-350, 1f).SetEase(Ease.InQuad);
    }

    public void tweenOut()
    {
        awardTransform.DOLocalMoveX(-500, 1f).SetEase(Ease.OutQuad);
    }
}
