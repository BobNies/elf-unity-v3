using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;
using DG.Tweening;

public class BallCountUpdater : MonoBehaviour
{
    [SerializeField] 
    public Modular3DText modular3DText = null;

    private int currentBallNo = 0;
    private bool isShowing = false;
    private Vector3 vec = new Vector3(.2f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        //test only
        //tweenIn();
    }

    // Update is called once per frame
    void Update()
    {
        int ballNo = Globals.ballNumber;
        if (currentBallNo != ballNo)
        {
            if(!isShowing)
            {
                isShowing = true;
                //bring text into view
                tweenIn();
            }
            currentBallNo = ballNo;
            // Only update when it changes.
            modular3DText.Text = "Ball " + ballNo + " of 3";
            // animation
            modular3DText.transform.DOShakeScale(1, vec, 10, 90f, true).SetEase(Ease.InOutFlash);
        }
    }

    public void tweenIn()
    {
        modular3DText.transform.DOScale(1f, .1f); //.SetEase(Ease.InQuint);
    }

    public void tweenOut()
    {
        modular3DText.transform.DOScale(0f, .1f); //.SetEase(Ease.OutQuint);
    }

}
