using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MText;

public class Champion : MonoBehaviour
{

    public Modular3DText name;
    private bool updated = false;

    // Start is called before the first frame update
    void Start()
    {
        //register to listen for new high score
        BcpServer.Instance.Send(BcpMessage.RegisterTriggerMessage("high_score_award_display"));

        //UpdateName();
        name.Text = "abc";  //Globals.championName;
    }

    void OnDisable()
    {
        BcpMessageController.OnTrigger -= Trigger;
    }

    // Update is called once per frame
    void Update()
    {
        if (!updated)
        {
            string cn = Globals.championName;
            if (!String.IsNullOrEmpty(cn))
            {
                updated = true;
                name.Text = Globals.championName;
            }
        }
        
    }

    public void Trigger(object sender, TriggerMessageEventArgs e)
    {        
        if (e.Name == "high_score_award_display")
        {
            try
            {
                string playerName = e.BcpMessage.Parameters["player_name"].Value;
                if (!String.IsNullOrEmpty(playerName))
                {
                    Globals.championName = playerName;
                    name.Text = playerName;
                }
            }
            catch (Exception ex)
            {
                BcpServer.Instance.Send(BcpMessage.ErrorMessage("An error occurred while processing a 'high_score_award_display' trigger message: " + ex.Message, e.BcpMessage.RawMessage));
            }
        }
    }

}
