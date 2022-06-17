using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;
using DG.Tweening;

public class PresentManager : MonoBehaviour
{

    private GameObject containedItem;
    public GameObject present;
    private Vector3 vec = new Vector3(3, 3, 3);

    public Modular3DText containedItemText = null;

    public PresentAnimator presentAnimator;

    // Start is called before the first frame update
    void Start()
    {
       // present =GameObject.Find("main-box").GetComponent<GameObject>();
        containedItem = presentAnimator.ContainedItems[0];
        this.gameObject.GetComponent<Animator>().enabled = true;
        //scoreP1 = playerOneTransform.transform.Find("score").GetComponent<TextMeshProUGUI>();
        //containedItemText = containedItem.transform.Find("JackpotText").GetComponent<Modular3DText>();
        //TEST
        //containedItemText.Text = "1,234,500";
        //presentAnimator.loadContainedItems();
    }

    public void updateScoreText(string score)
    {
        //update the text, then reset the animator
        containedItemText.Text = score;
        presentAnimator.Animate();
    }

    public void show()
    {
        //present.SetActive(true);
        present.transform.DOScale(vec, .5f)
                .SetEase(Ease.OutQuint);
    }

    public void hide()
    {
        //present.SetActive(false);
        present.transform.DOScale(0f, .5f)
                .SetEase(Ease.OutQuint);
    }

}
