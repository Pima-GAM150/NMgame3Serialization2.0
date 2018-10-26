using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBehaviour : MonoBehaviour {

    public Text buttonText;
    public int numberOfClicks;
    public int maxNumberOfClicks;

    public virtual void ButtonClick()
    {
        numberOfClicks++;
        

    }


    public virtual void ButtonCountReset()
    {
        if (numberOfClicks > maxNumberOfClicks)
        {
            numberOfClicks = 0;
        }
    }

   





}
