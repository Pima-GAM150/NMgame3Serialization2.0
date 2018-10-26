using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassButton : ButtonBehaviour {

    //these buttons will vary on the sound that will be attached to the numbers.

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = numberOfClicks.ToString();
        ButtonCountReset();
    }
}
