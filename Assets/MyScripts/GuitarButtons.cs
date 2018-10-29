using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarButtons : ButtonBehaviour {


    public int currentSelectedTrack;


    void Start () {
		
	}
	
	
	void Update ()
    {
        currentSelectedTrack = numberOfClicks;
        buttonText.text = numberOfClicks.ToString();
        ButtonCountReset();
    }

   


}
