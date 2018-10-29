using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumButton : ButtonBehaviour {

    public int currentSelectedTrack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentSelectedTrack = numberOfClicks;
        buttonText.text = currentSelectedTrack.ToString();
        ButtonCountReset();
    }
    

}
