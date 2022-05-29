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

//TODO - amimations, FX when increasing val.
// TODO - more awards: LoopMaster, RampMaster, JesterMaster
// TODO - show current level

public class AwardManager : MonoBehaviour
{
    public PlayfieldManager playfieldManager;

    [Header("Top-Left award Boxes")]
    [Tooltip("Main transform that holds all the award boxes. Used for show/hide.")]
    public Transform awardTransform;
    public TextMeshProUGUI textAward1;
    public TextMeshProUGUI textAward2;
    public TextMeshProUGUI textAward3;
    public TextMeshProUGUI textAward4;

    [Header("BCP triggers to advance above awards")]
    [Tooltip("The name of the BCP Trigger to listen for. Should be a Counter.events_when_hit")]
    public string triggerAward1;
    public string triggerAward2;
    public string triggerAward3;
    public string triggerAward4;

    [Header("Prefab awards for matching BCP message")]
    public GameObject pf_startFullBallMb;
    public GameObject pf_popJester;
    public GameObject pf_plungerSkillShotAwarded;
    public GameObject pf_ballSave;
    public GameObject pf_awardExtraBall;
    public GameObject pf_startExtraBall;
    public GameObject pf_snowLaneAdvanceComplete;
    public GameObject pf_topLaneAdvanceComplete;
    public GameObject pf_santaLitComplete;
    public GameObject pf_angryTargetsAdvanceComplete;
    public GameObject pf_dropElfAdvanceComplete;
    public GameObject pf_targetsBuddyAdvanceComplete;
    public GameObject pf_targetFoodGroupsAwarded;
    // public GameObject pf_jetsCollectAward;
    // public GameObject pf_loopCollectAward;
    // public GameObject pf_vukCollectAward;


#if UNITY_EDITOR
    private KeyboardInput mgr;
#endif


    void Start()
    {
#if UNITY_EDITOR
        mgr = GameObject.Find("TEST_ONLY").GetComponent<KeyboardInput>();
#endif

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
        // To receive a trigger, it MUST be registered in BcpMessageManager:elfTriggers
        //  #Event: ======'spinner_collect_award'====== Args={'count': 3}
        string name = e.Name;
        //Debug.Log("bob name:" + name);
        //BcpLogger.Trace("bob name: " + name);

        string count = "0";
        if (e.BcpMessage != null)
        {
            count = e.BcpMessage.Parameters["count"].Value;
        }
        
        if (name == triggerAward1)
        {           
            textAward1.text = count;
            // animation
            DOTween.Restart("hat");
            //squareAward1.transform.DORotate(new Vector3(360f, 0, 0), .22f, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        }
        else if (name == triggerAward2)
        {
            textAward2.text = count;
            DOTween.Restart("flake");
        }
        else if (name == triggerAward3)
        {
            textAward3.text = count;
            DOTween.Restart("cookie");
        }
        else if (name == triggerAward4)
        {
            textAward4.text = count;
            DOTween.Restart("present");
        } else
        {
            // spawn prefabs
            GameObject gObj = null;
            var killTime = 5f;
            switch(name)
            {
                case "ball_save_bs_plunger_saving_ball":
                    gObj = pf_ballSave;
                    break;
                case "start_full_ball_mb":
                    gObj = pf_startFullBallMb;
                    break;
                case "pop_jester":
                    gObj = pf_popJester;
                    break ;
                case "plunger_skill_shot_awarded":
                    break;
                case "award_extra_ball":
                    gObj = pf_awardExtraBall;
                    displayAwardOnPlayfieldMonitor("Extra Ball");
                    break;
                case "start_extra_ball":
                    gObj = pf_startExtraBall;
                    displayAwardOnPlayfieldMonitor("Shoot Again", 4);
                    break;
                case "snow_lane_advance_complete":
                    gObj = pf_snowLaneAdvanceComplete;
                    break;
                case "top_lane_advance_complete":
                    gObj = pf_topLaneAdvanceComplete;
                    break;
                case "santa_lit_complete":
                    gObj = pf_santaLitComplete;
                    break;
                case "angry_targets_advance_complete":
                    gObj = pf_angryTargetsAdvanceComplete;
                    break;
                case "drop_elf_advance_complete":
                    gObj = pf_dropElfAdvanceComplete;
                    break;
                case "targets_buddy_advance_complete":
                    gObj = pf_targetsBuddyAdvanceComplete;
                    break;
                case "target_food_groups_awarded":
                    gObj = pf_targetFoodGroupsAwarded;
                    break;
                // case "spinner_collect_award":
                //     break;
                // case "jets_collect_award":
                //     break;
                // case "loop_collect_award":
                //     break;
                // case "vuk_collect_award":
                //     break;
            }

            if(gObj != null) {
                //main screen
                var obj = Instantiate(gObj, new Vector3(0, .5f, 0), Quaternion.identity);
                Destroy(obj, killTime);
            }
        }

    }

    private void displayAwardOnPlayfieldMonitor(string text, int delay = 2)
    {
        playfieldManager.ShowAward(text, delay);
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

    // **** DEBUG
#if UNITY_EDITOR
  void Update()
    {
     if (Input.GetKeyDown(mgr.award1))
        {
            Debug.Log("AwardManager Award-1  pressed");
            
            Trigger(null, new TriggerMessageEventArgs(null, triggerAward1));
        }
     else  if (Input.GetKeyDown(mgr.award2))
        {
            Debug.Log("AwardManager Award-2 pressed");
             Trigger(null, new TriggerMessageEventArgs(null, triggerAward2));
        }
    else  if (Input.GetKeyDown(mgr.award3))
        {
            Debug.Log("AwardManager Award-3 pressed");
             Trigger(null, new TriggerMessageEventArgs(null, triggerAward3));
        }
    else  if (Input.GetKeyDown(mgr.award4))
        {
            Debug.Log("AwardManager Award-4 pressed");
            Trigger(null, new TriggerMessageEventArgs(null, triggerAward4));
        }
    else  if (Input.GetKeyDown(mgr.extraBall))
        {
            Debug.Log("AwardManager Award-4 pressed");
            Trigger(null, new TriggerMessageEventArgs(null,"award_extra_ball"));
        }
   
    }
#endif

}
