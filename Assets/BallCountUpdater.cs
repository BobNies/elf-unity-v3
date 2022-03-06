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
    private Vector3 vec = new Vector3(.2f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int ballNo = Globals.ballNumber;
        if (currentBallNo != ballNo)
        {
            currentBallNo = ballNo;
            // Only update when it changes.
            modular3DText.Text = "Ball " + ballNo + " of 3";
            // animation
            modular3DText.transform.DOShakeScale(1, vec, 10, 90f, true).SetEase(Ease.InOutFlash);
        }
    }
}
