using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class BallCountUpdater : MonoBehaviour
{
    [SerializeField] 
    public Modular3DText modular3DText = null;

    // Start is called before the first frame update
    void Start()
    {
        int ballNo = Globals.ballNumber;
        modular3DText.Text = "BALL " + ballNo + " of 3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
