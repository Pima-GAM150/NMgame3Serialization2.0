using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarButtons : ButtonBehaviour {

    


	
	void Start () {
		
	}
	
	
	void Update () {
        buttonText.text = numberOfClicks.ToString();
        ButtonCountReset();
    }

   


}
