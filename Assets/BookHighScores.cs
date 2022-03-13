using UnityEngine;
using System;
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

    private bool updated = false;

    void Start()
    {
        BcpLogger.Trace("bob start............................");
        name1.Text = "start";
        // ["data_manager", "high_scores", "high_score_config", "pending_award"]
        // set the text from machine var
        // high_score_category1_label
        //if (!String.IsNullOrEmpty(machineVariableName))
        //{
        // Event: ====== 'machine_var_score1_label'====== Args={'value': 'GRAND CHAMPION', 'prev_value': None, 'change': True}
        // Event: ====== 'machine_var_score1_name' ====== Args ={ 'value': 'BRI', 'prev_value': None, 'change': True}
        // Event: ====== 'machine_var_score1_value' ====== Args ={ 'value': 4242, 'prev_value': None, 'change': True}
        //  JSONNode label1 = BcpMessageManager.Instance.GetMachineVariable("score1_label");
        //Debug.Log("bob label1:" + label1);
        // BcpLogger.Trace("========= bob label1: " + label1);
        //if (label1 != null)
        //{
        //  textScore1.Text = label1;
        // string value = variable.Value;

        //if (intValue != null && !intValue.IsNone) intValue.Value = variable.AsInt;
        //if (floatValue != null && !floatValue.IsNone) floatValue.Value = variable.AsFloat;
        //if (boolValue != null && !boolValue.IsNone) boolValue.Value = variable.AsBool;
        //}
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (!updated)
        {
            JSONNode score1Name = BcpMessageManager.Instance.GetMachineVariable("score1_name");

            if (score1Name != null)
            {
                name1.Text = score1Name;
                //get the rest of the values
                name2.Text = BcpMessageManager.Instance.GetMachineVariable("score2_name");
                name2.Text = BcpMessageManager.Instance.GetMachineVariable("score3_name");
                name4.Text = BcpMessageManager.Instance.GetMachineVariable("score4_name");
                name5.Text = BcpMessageManager.Instance.GetMachineVariable("score5_name");

                score1.Text = BcpMessageManager.Instance.GetMachineVariable("score1_value");
                score2.Text = BcpMessageManager.Instance.GetMachineVariable("score2_value");
                score3.Text = BcpMessageManager.Instance.GetMachineVariable("score3_value");
                score4.Text = BcpMessageManager.Instance.GetMachineVariable("score4_value");

                JSONNode score5Name = BcpMessageManager.Instance.GetMachineVariable("score5_value");
                if (score5Name != null) {
                    updated = true;
                    score5.Text = score5Name;
                }
            }
        }
    }
}
