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
        StartCoroutine(updateView(2));
    }

    public void Update()
    {
        StartCoroutine(updateView(1));
    }

    //TODO - find better way - need to update when a new score is set.
    IEnumerator updateView(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

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
            Globals.championName = score1Name;
            int intVal;
            int.TryParse(score1Value, out intVal);
            score1.Text = intVal.ToString("n0");
        }
        if (score2Name != null && score2Value != null)
        {
            name2.Text = score2Name;

            int intVal;
            int.TryParse(score2Value, out intVal);
            score2.Text = intVal.ToString("n0");
        }
        if (score3Name != null && score3Value != null)
        {
            name3.Text = score3Name;
            int intVal;
            int.TryParse(score3Value, out intVal);
            score3.Text = intVal.ToString("n0");
        }
        if (score4Name != null && score4Value != null)
        {
            name4.Text = score4Name;
            int intVal;
            int.TryParse(score4Value, out intVal);
            score4.Text = intVal.ToString("n0");
        }
        if (score5Name != null && score5Value != null)
        {
            name5.Text = score5Name;
            int intVal;
            int.TryParse(score5Value, out intVal);
            score5.Text = intVal.ToString("n0");
        }
    }

}
