using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NavManager : MonoBehaviour
{
    private int index;
    private GameObject currentPanel;
    private GameObject currentBG;

    public TMP_Text titleTxt;
    public string[] panelTitles;
    public GameObject[] panels;
    public GameObject[] panelBgs;
    public Toggle snowParticles;
    public GameObject snowP;

    void Start()
    {
        snowP.SetActive(true);
        snowParticles.onValueChanged.AddListener(delegate {
            ToggleCheck(snowParticles);
        });

        SetActivePanel(0);
    }
    public void NextPanel()
    {
        SetActivePanel((int)Mathf.Repeat(++index, panels.Length));
    }
    public void PrevPanel()
    {
        SetActivePanel((int)Mathf.Repeat(--index, panels.Length));
    }
    private void SetActivePanel(int index)
    {
        if (currentPanel != null )
        currentPanel.SetActive(false);
       
        titleTxt.text = panelTitles[index];
        currentPanel = panels[index];
       
        currentPanel.SetActive(true);
       
       if(currentBG != null) currentBG.SetActive(false);
        currentBG = panelBgs[index];
        currentBG.SetActive(true);

    }
    public void ToggleCheck(Toggle change)
    {
        
        if (snowParticles.isOn == true)
        {
            snowParticles.isOn = true;
            snowP.SetActive(true);
        }
        else
        {
            snowP.SetActive(false);
            snowParticles.isOn = false;
        }
    }
}
