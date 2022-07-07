using System;
using UnityEngine;
using MText;
using TMPro;
using DG.Tweening;
using UnityEngine.Video;

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
    public VideoManager videoManager;
    public VideoClip videoOmg;

    [Header("Top-Left award Boxes")]
    [Tooltip("Main transform that holds all the award boxes. Used for show/hide.")]
    public Transform awardTransform;

    public GameObject spinnerTransform;
    public TextMeshProUGUI textSpinner;
    public TextMeshProUGUI textJets;
    public TextMeshProUGUI textLoops;
    public TextMeshProUGUI textNarwhal;

    [Header("BCP triggers to advance above awards")]
    [Tooltip("The name of the BCP Trigger to listen for. Should be a Counter.events_when_hit")]
    public string triggerAwardSpinner;          // 
    public Spinner_Rotation spinnerRotation;    // 
    public string triggerAwardJets;             // jets_collect_award
    public string triggerAwardLoop;             // loop_collect_award
    public string triggerAwardVuk;              // vuk_collect_award

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


#if UNITY_EDITOR
    private KeyboardInput mgr;
#endif


    void Start()
    {
#if UNITY_EDITOR
        mgr = GameObject.Find("TEST_ONLY").GetComponent<KeyboardInput>();
#endif

        BcpMessageController.OnTrigger += Trigger;

        resetAllAwardScores();
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
        
        if (name == triggerAwardSpinner)
        {           
            textSpinner.text = count;
            // animation
            spinnerRotation.Spin(1.5f);
            //squareAward1.transform.DORotate(new Vector3(360f, 0, 0), .22f, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
        }
        else if (name == triggerAwardJets)
        {
            textJets.text = count;
            DOTween.Restart("flake");
        }
        else if (name == triggerAwardLoop)
        {
            textLoops.text = count;
            DOTween.Restart("loops");
        }
        else if (name == triggerAwardVuk)
        {
            textNarwhal.text = count;
            DOTween.Restart("narwhal");
        } else
        {
            // spawn prefabs
            GameObject gameObjectMainMonitorSpawn = null;
            var killTime = 5f;
            switch(name)
            {
                case "ball_save_bs_plunger_saving_ball":
                    gameObjectMainMonitorSpawn = pf_ballSave;
                    displayAwardOnPlayfieldMonitor("Ball Saved");
                    break;
                case "start_full_ball_mb":
                    gameObjectMainMonitorSpawn = pf_startFullBallMb;
                    displayAwardOnPlayfieldMonitor("MultiBall",4);
                    break;
                case "pop_jester":
                    gameObjectMainMonitorSpawn = pf_popJester;
                    displayAwardOnPlayfieldMonitor("Jester Award");
                    break ;
                case "plunger_skill_shot_awarded":
                    displayAwardOnPlayfieldMonitor("Skillshot Awarded");
                    break;
                case "award_extra_ball":
                    gameObjectMainMonitorSpawn = pf_awardExtraBall;
                    displayAwardOnPlayfieldMonitor("Extra Ball");
                    break;
                case "start_extra_ball":
                    gameObjectMainMonitorSpawn = pf_startExtraBall;
                    displayAwardOnPlayfieldMonitor("Shoot Again", 4);
                    break;
                case "snow_lane_advance_complete":
                    gameObjectMainMonitorSpawn = pf_snowLaneAdvanceComplete;
                    displayAwardOnPlayfieldMonitor("Snow Lane Advance Bonus");
                    break;
                case "top_lane_advance_complete":
                    gameObjectMainMonitorSpawn = pf_topLaneAdvanceComplete;
                    displayAwardOnPlayfieldMonitor("Lane Advance Award");
                    break;
                case "santa_lit_complete":
                    gameObjectMainMonitorSpawn = pf_santaLitComplete;
                    displayAwardOnPlayfieldMonitor("SANTA Bonus");
                    break;
                case "angry_targets_advance_complete":
                    gameObjectMainMonitorSpawn = pf_angryTargetsAdvanceComplete;
                    displayAwardOnPlayfieldMonitor("Angry Elf Advance Bonus");
                    break;
                case "drop_elf_advance_complete":
                    gameObjectMainMonitorSpawn = pf_dropElfAdvanceComplete;
                    displayAwardOnPlayfieldMonitor("Elf Advance Bonus");
                    break;
                case "targets_buddy_advance_complete":
                    gameObjectMainMonitorSpawn = pf_targetsBuddyAdvanceComplete;
                    displayAwardOnPlayfieldMonitor("Buddy Lit Bonus");
                    break;
                case "target_food_groups_awarded":
                    gameObjectMainMonitorSpawn = pf_targetFoodGroupsAwarded;
                    displayAwardOnPlayfieldMonitor("Food Groups Awarded");
                    break;
                case "video_play_omg":
                    videoManager.playVideo(videoOmg);

                    // omg mode is active and ball drained. play video & post award
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

            if(gameObjectMainMonitorSpawn != null) {
                //main screen
                var obj = Instantiate(gameObjectMainMonitorSpawn, new Vector3(0, .5f, 0), Quaternion.identity);
                Destroy(obj, killTime);
            }
        }

    }

    private void displayAwardOnPlayfieldMonitor(string text, int delay = 3)
    {
        playfieldManager.ShowAward(text, delay);
    }

    public void resetAllAwardScores()
    {
        textSpinner.text = "0";
        textJets.text = "0";
        textLoops.text = "0";
        textNarwhal.text = "0";
    }

    public void tweenIn()
    {
        awardTransform.DOLocalMoveX(0, 1f).SetEase(Ease.InQuad);
        textSpinner.transform.DOLocalMoveY(159, .5f).SetEase(Ease.OutQuad);
        //spinnerTransform.transform.DOLocalMoveY(100, .5f).SetEase(Ease.OutQuad);
        spinnerTransform.SetActive(true);
    }

    public void tweenOut()
    {
        awardTransform.DOLocalMoveX(-200, 1f).SetEase(Ease.OutQuad);
        textSpinner.transform.DOLocalMoveY(250, .5f).SetEase(Ease.OutQuad);
        spinnerTransform.SetActive(false);
        //spinnerTransform.transform.DOLocalMoveY(-100, .5f).SetEase(Ease.OutQuad);
    }

    // **** DEBUG
#if UNITY_EDITOR
  void Update()
    {
     if (Input.GetKeyDown(mgr.award1))
        {
            Debug.Log("AwardManager Award-1  pressed");
            //tweenIn();
            Trigger(null, new TriggerMessageEventArgs(null, triggerAwardSpinner));
        }
     else  if (Input.GetKeyDown(mgr.award2))
        {
            //tweenOut();
            Debug.Log("AwardManager Award-2 pressed");
            Trigger(null, new TriggerMessageEventArgs(null, triggerAwardJets));
        }
    else  if (Input.GetKeyDown(mgr.award3))
        {
            Debug.Log("AwardManager Award-3 pressed");
             Trigger(null, new TriggerMessageEventArgs(null, triggerAwardLoop));
        }
    else  if (Input.GetKeyDown(mgr.award4))
        {
            Debug.Log("AwardManager Award-4 pressed");
            Trigger(null, new TriggerMessageEventArgs(null, triggerAwardVuk));
        }
    else  if (Input.GetKeyDown(mgr.extraBall))
        {
            Debug.Log("AwardManager Award-4 pressed");
            Trigger(null, new TriggerMessageEventArgs(null,"award_extra_ball"));
        }
   
    }
#endif

}
