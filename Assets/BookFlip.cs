using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using echo17.EndlessBook;
using DG.Tweening;

public class BookFlip : MonoBehaviour
{
    public VideoClip[] videoClips;

    public float stateAnimationTime = 1f;
    public EndlessBook.PageTurnTimeTypeEnum turnTimeType = EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime;
    public float PageFlipAnimationTime = 1f;
    public float turnTimePage = 5f;
    public int cyclesBetweenVideoPlay = 3;

    private EndlessBook book;
    private VideoManager videoManager;

    private float timer = 0f;
    private float origTimeBetweenTurn = 20;
    private int currentPage = 0;
    private int cycles = 0;
    private int videoCount = 0;
    private int videoIndex = 0;
    private bool disabled = false;

    void Awake()
    {
        book = this.gameObject.GetComponent<EndlessBook>();
        videoManager = this.gameObject.GetComponent<VideoManager>();
        origTimeBetweenTurn = turnTimePage;
        videoCount = videoClips.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        // listen to flipper buttons
       // BcpMessageController.OnTrigger += Trigger;
    }

    void OnDisable() {
      //  BcpMessageController.OnTrigger -= Trigger;
    }

    protected virtual void SetState(EndlessBook.StateEnum state)
    {
        // set the state
        book.SetState(state, stateAnimationTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (!disabled && timer <= 0.0f)
        {
            //flip the page
            timer = origTimeBetweenTurn;
            currentPage += 1;
            if (currentPage > book.LastPageNumber)
            {
                currentPage = 1;
                cycles += 1;               
            }

            book.TurnToPage(currentPage, turnTimeType, PageFlipAnimationTime);

            if(currentPage == 7 && cycles == 0)
            {
                // start the video early by using left side page
                videoManager.playVideo(videoClips[videoIndex]);
                if (videoIndex == videoCount-1)
                {
                    videoIndex = 0;
                } else
                {
                    videoIndex += 1;
                }
            } else if (currentPage == 1)
            {
                videoManager.stopAllVideos();
            }
            
            if (cycles >= cyclesBetweenVideoPlay)
            {
                cycles = 0;
            }
        }
    }

    public void tweenIn()
    {
        book.transform.DOScale(1f, .5f).SetEase(Ease.InQuad);
        disabled = false;
        timer = origTimeBetweenTurn;
        currentPage = 0;
    }

    public void tweenOut()
    {
        book.transform.DOScale(0f, .5f).SetEase(Ease.OutQuad);
        disabled = true;
    }

   //  public void Trigger(object sender, TriggerMessageEventArgs e)
    //{
        // Determine if this switch message is the one we are interested in (name and value equal desired values).  If so, send specified FSM event.
      ///  if (e.Name == "s_flipper_rt_active") 
        //{
            // reset time, flip page next
          //  timer = origTimeBetweenTurn;
        //    book.TurnForward(1);
    //    } else if (e.Name == "s_flipper_lt_active") 
      //  {
            // reset time, flip page
        //    timer = origTimeBetweenTurn;
          //  book.TurnBackward(1);
     //   }
           
   // }
}
