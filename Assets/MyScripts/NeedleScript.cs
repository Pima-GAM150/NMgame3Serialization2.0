using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour {


    public float needleMoveSpeed;
    float currentPlayBackSpeed;
    public Transform startingPos;
    public enum State {Stop = 0, Pause = 1, Play = 2}
    public State needlesState;

    
    void Update()
    {
        if (needlesState == State.Pause)
            {
                NeedlePause();
            }
        if (needlesState == State.Play)
        {
            NeedlePlay();
        
            
        }
        if (needlesState == State.Stop)
        {
            NeedleStop();
        }
    }
    private void Start()
    {
      
    }


    public void PlayButtonPress()
    {
        needlesState = State.Play;
    }

    public void PauseButtonPress()
    {
        needlesState = State.Pause;
    }

    public void StopButtonPress()
    {
        needlesState = State.Stop;
    }

    public void NeedlePlay()
    {
        
        currentPlayBackSpeed = needleMoveSpeed * Time.deltaTime;

        transform.Translate(Vector2.right * currentPlayBackSpeed);

    }

    public void NeedlePause()
    {
        currentPlayBackSpeed = 0;
    
    }

    public void NeedleStop()
    {
        transform.position = startingPos.position;
    }



    private void OnTriggerEnter2D(Collider2D contact)
    {
        if (contact.gameObject.tag == "End")
        {
            transform.position = startingPos.position;
        }
    
        Debug.Log("I am touching" + contact.gameObject.GetComponent<ButtonBehaviour>().numberOfClicks);
        if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 1)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum1");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 2)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum2");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 3)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum3");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 4)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum4");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 5)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum5");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 6)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum6");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 7)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum7");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 8)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum8");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 9)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum9");
        }
        else if (contact.GetComponent<ButtonBehaviour>().numberOfClicks == 10)
        {
            FindObjectOfType<AudioManager>().PlayDrums("Drum10");
        }
        
    }

}



