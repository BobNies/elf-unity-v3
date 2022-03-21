using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;

// play audio clips on ball end, etc
public class BallStartEndManager : MonoBehaviour
{

    [SoundGroupAttribute] public string[] ballEndSounds;

    // Start is called before the first frame update
    void Start()
    {
        BcpMessageController.OnBallEnd += BallEnd;
    }

    // Update is called once per frame
    void Update()
    {
        BcpMessageController.OnBallEnd -= BallEnd;
    }

    // play random sound on end.
    public void BallEnd(object sender, BcpMessageEventArgs e)
    {
        MasterAudio.PlaySound(ballEndSounds[Random.Range(0, ballEndSounds.Length)]);
    }

}
