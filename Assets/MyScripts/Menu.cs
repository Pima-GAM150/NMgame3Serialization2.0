using UnityEngine.Audio;
using UnityEngine;


public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().PlayExtraSound("MenuMusic");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
