using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBehaviour : MonoBehaviour {

    public Text buttonText;
    public int numberOfClicks;
    public int maxNumberOfClicks;

    private void Start()
    {
        UpdateButtonText();
    }

    public virtual void ButtonClick()
    {
        numberOfClicks++;

        UpdateButtonText();
    }


    public virtual void ButtonCountReset()
    {
        if (numberOfClicks > maxNumberOfClicks)
        {
            numberOfClicks = 0;
        }
    }

    public virtual void UpdateButtonText()
    {

    }





}
