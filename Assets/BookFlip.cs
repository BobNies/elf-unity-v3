using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using echo17.EndlessBook;

public class BookFlip : MonoBehaviour
{

    public EndlessBook book;
    public float stateAnimationTime = 1f;
    public EndlessBook.PageTurnTimeTypeEnum turnTimeType = EndlessBook.PageTurnTimeTypeEnum.TotalTurnTime;
    public float turnTime = 1f;

    void Awake()
    {
        // cache the book
        book = GameObject.Find("Book").GetComponent<EndlessBook>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //book.TurnForward(1);
        //SetState(EndlessBook.StateEnum.OpenFront);
        //book.TurnForward(1);
        book.TurnToPage(3, turnTimeType, turnTime);
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
        
    }

    private void changePage()
    {

    }
}
