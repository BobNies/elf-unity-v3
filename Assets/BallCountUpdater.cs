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

    private void tweenIn()
    {
         modular3DText.transform.DOMoveY(-0.7399979f, 1f).SetEase(Ease.InElastic);
    }

    public void tweenOut()
    {
        modular3DText.transform.DOMoveY(-1f, 1f).SetEase(Ease.OutElastic);
    }

}
