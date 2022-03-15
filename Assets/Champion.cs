using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class Champion : MonoBehaviour
{

    public Modular3DText name;

    // Start is called before the first frame update
    void Start()
    {
        UpdateName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateName()
    {
        yield return new WaitForSeconds(3);

        name.Text = "aaa"; // Globals.championName;
    }

}
