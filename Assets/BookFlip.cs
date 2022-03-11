using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using echo17.EndlessBook;
using DG.Tweening;

public class BookFlip : MonoBehaviour
{

    public EndlessBook book;
    public float stateAnimationTime = 1f;
    public EndlessBook.PageTurnTimeTypeEnum turnTimeType = EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime;
    public float turnTime = 1f;
    public float timeBetweenTurn = 20f;

    private float timer = 0f;
    private float origTimeBetweenTurn = 20;
    private int currentPage = 1;
    private int cycles = 0;

    void Awake()
    {
        // cache the book
        book = GameObject.Find("Book").GetComponent<EndlessBook>();
        origTimeBetweenTurn = timeBetweenTurn;
    }

    // Start is called before the first frame update
    void Start()
    {
        //book.TurnForward(1);
        //SetState(EndlessBook.StateEnum.OpenFront);
        //book.TurnForward(1);
        //book.TurnToPage(3, turnTimeType, turnTime);
        //tweenOut();
    }

    protected virtual void SetState(EndlessBook.StateEnum state)
    {
        // turn of the touch pad
       // ToggleTouchPad(false);

        // set the state
        book.SetState(state, stateAnimationTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            //flip the page
            timer = origTimeBetweenTurn;
            currentPage += 1;
            if (currentPage > book.LastPageNumber)
            {
                //tweenOut();
                currentPage = 1;
                cycles += 1;
            }
            book.TurnToPage(currentPage, turnTimeType, turnTime);
        }
    }

    private void changePage()
    {
        book.TurnToPage(3, turnTimeType, turnTime);
    }

    public void tweenIn()
    {
        book.transform.DOScale(1f, 1f).SetEase(Ease.InElastic);
    }

    public void tweenOut()
    {
        book.transform.DOScale(0f, 1f).SetEase(Ease.OutElastic);
    }
}
