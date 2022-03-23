using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

//play sound FX's based on switch events

public class SoundFxManager : MonoBehaviour
{
    [SoundGroupAttribute] public string jets;
    [SoundGroupAttribute] public string spinner;
    //[SoundGroupAttribute] public string captiveLeft;
    [SoundGroupAttribute] public string captiveRight;
    [SoundGroupAttribute] public string singleDrops;
    [SoundGroupAttribute] public string elfDrop;
    [SoundGroupAttribute] public string angryTargets;
    [SoundGroupAttribute] public string blueTargets;
    [SoundGroupAttribute] public string vuk;
    [SoundGroupAttribute] public string outerLoop;
    [SoundGroupAttribute] public string innerLoop;
    [SoundGroupAttribute] public string snowLanes;
    [SoundGroupAttribute] public string upperLanes;
    [SoundGroupAttribute] public string buddyTargets;
    //[SoundGroupAttribute] public string popJesterSound;
    [SoundGroupAttribute] public string santaRamp;
    [SoundGroupAttribute] public string tilt;
    [SoundGroupAttribute] public string jesterCrank;
    [SoundGroupAttribute] public string jesterPop;


    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnSwitch += Switch;
        BcpMessageController.OnTrigger += Trigger;
    }

    void OnDestroy()
    {
        BcpMessageController.OnSwitch -= Switch;
        BcpMessageController.OnTrigger -= Trigger;
    }

    public void Trigger(object sender, TriggerMessageEventArgs e)
    {
        //trigger jester sounds -- ,sh_jester_hit_2_hit,sh_jester_hit_3_hit
        BcpLogger.Trace("bob NAME:" + e.Name);
        switch (e.Name)
        {
            case "sh_jester_hit_1_hit":
            case "sh_jester_hit_2_hit":
                MasterAudio.PlaySound(jesterCrank);
                break;
            case "sh_jester_hit_3_hit":
                MasterAudio.PlaySound(jesterPop);
                break;
        }
    }

    public void Switch(object sender, SwitchMessageEventArgs e)
    {
        BcpLogger.Trace("Sound: Switch (" + e.Name + ", " + e.State.ToString() + ")");

        if (e.State != 1)
            return;
        switch(e.Name)
        {
            case "s_jet_lt":
            case "s_jet_rt":
            case "s_jet_ctr":
                MasterAudio.PlaySound(jets);
                break;
            case "s_spinner":
                MasterAudio.PlaySound(spinner);
                break;
            case "s_target_snowball_rt":
                MasterAudio.PlaySound(captiveRight);
                break;
           // case "s_target_snowball_ctr":
             //   MasterAudio.PlaySound(captiveLeft);
               // break;
            case "s_drop_single_lt":
            case "s_drop_single_rt":
                MasterAudio.PlaySound(singleDrops);
                break;
            case "s_drop_elf_e":
            case "s_drop_elf_l":
            case "s_drop_elf_f":
                MasterAudio.PlaySound(elfDrop);
                break;
            case "s_target_angry_a":
            case "s_target_angry_n":
            case "s_target_angry_g":
            case "s_target_angry_r":
            case "s_target_angry_y":
                MasterAudio.PlaySound(angryTargets);
                break;
            case "s_target_buddy_front":
            case "s_target_vuk_lt":
                MasterAudio.PlaySound(blueTargets);
                break;
            case "s_vuk_main":
                MasterAudio.PlaySound(vuk);
                break;
            case "s_outer_loop_center":
                MasterAudio.PlaySound(outerLoop);
                break;
            case "s_center_loop_lt":
                MasterAudio.PlaySound(innerLoop);
                break;
            case "s_lane_rt_mid":
            case "s_lane_rt_inner":
            case "s_lane_lt_inner":
            case "s_lane_lt_mid":
                MasterAudio.PlaySound(snowLanes);
                break;
            case "s_upper_lane_lt":
            case "s_upper_lane_rt":
                MasterAudio.PlaySound(upperLanes);
                break;
            case "s_target_buddy_y":
            case "s_target_buddy_d2":
            case "s_target_buddy_d1":
            case "s_target_buddy_u":
            case "s_target_buddy_b":
                MasterAudio.PlaySound(buddyTargets);
                break;
            case "s_ramp_loop":
                MasterAudio.PlaySound(santaRamp);
                break;
            case "s_tilt":
                MasterAudio.PlaySound(tilt);
                break;
        }
    }

}
