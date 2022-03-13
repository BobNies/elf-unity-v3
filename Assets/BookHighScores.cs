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
        
    }

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
