using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using MText;
using DG.Tweening;
using BCP.SimpleJSON;

public class BookHighScores : MonoBehaviour
{
    [SerializeField]
    public Modular3DText name1 = null;
    [SerializeField]
    public Modular3DText score1 = null;
    [SerializeField]
    public Modular3DText name2 = null;
    [SerializeField]
    public Modular3DText score2 = null;
    [SerializeField]
    public Modular3DText name3 = null;
    public Modular3DText score3 = null;
    public Modular3DText name4 = null;
    public Modular3DText score4 = null;
    public Modular3DText name5 = null;
    public Modular3DText score5 = null;

    void Start()
    {
        StartCoroutine(updateView());
    }

    //TODO - find better way - need to update when a new score is set.
    IEnumerator updateView()
    {
        yield return new WaitForSeconds(2);

        JSONNode score1Name = BcpMessageManager.Instance.GetMachineVariable("score1_name");
        JSONNode score2Name = BcpMessageManager.Instance.GetMachineVariable("score2_name");
        JSONNode score3Name = BcpMessageManager.Instance.GetMachineVariable("score3_name");
        JSONNode score4Name = BcpMessageManager.Instance.GetMachineVariable("score4_name");
        JSONNode score5Name = BcpMessageManager.Instance.GetMachineVariable("score5_name");

        JSONNode score1Value = BcpMessageManager.Instance.GetMachineVariable("score1_value");
        JSONNode score2Value = BcpMessageManager.Instance.GetMachineVariable("score2_value");
        JSONNode score3Value = BcpMessageManager.Instance.GetMachineVariable("score3_value");
        JSONNode score4Value = BcpMessageManager.Instance.GetMachineVariable("score4_value");
        JSONNode score5Value = BcpMessageManager.Instance.GetMachineVariable("score5_value");

        if (score1Name != null && score1Value != null)
        {
            name1.Text = score1Name;
            score1.Text = score1Value;
            Globals.championName = score1Name;
        }
        if (score2Name != null && score2Value != null)
        {
            name2.Text = score2Name;
            score2.Text = score2Value;
        }
        if (score3Name != null && score3Value != null)
        {
            name3.Text = score3Name;
            score3.Text = score3Value;
        }
        if (score4Name != null && score4Value != null)
        {
            name4.Text = score4Name;
            score4.Text = score4Value;
        }
        if (score5Name != null && score5Value != null)
        {
            name5.Text = score5Name;
            score5.Text = score5Value;
        }
    }

}
