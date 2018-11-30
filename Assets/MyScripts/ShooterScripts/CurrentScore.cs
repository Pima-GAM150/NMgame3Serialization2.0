using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    public Text label;


	void Start () {
        label.text = FindObjectOfType<PlayerScripts>().playerScore.ToString();
	}
	
}
