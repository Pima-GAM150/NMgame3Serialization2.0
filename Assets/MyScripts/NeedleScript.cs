using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NeedleScript : MonoBehaviour {


    
    //the needle speed variables the currentSpeed is hidden for the purpose to stop the need in its tracks with out using constraints. the public varibale can remain constant
    public float needleMoveSpeed;
    float currentPlayBackSpeed;
    //
    public Transform startingPos;
    public enum State {Stop = 0, Pause = 1, Play = 2}
    public State needlesState;

   //every frame the needle checks the state it is in. if its state is paused then it does the pause fuction. if the state is play then playfunction and so on 
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
    }//end of the update and statecheck

   //no start function

    public void PlayButtonPress()
    {//pressing buttons changes the state of the button. the state will determines the behaviour of the needle
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
    //end of the button state selecions


    public void NeedlePlay()
    {//when this play function is firing the needle takes the move speed and travels to the right. funny glitch if the needle is too fast for the end point check it flies of the screen        
        currentPlayBackSpeed = needleMoveSpeed * Time.deltaTime;

        transform.Translate(Vector2.right * currentPlayBackSpeed);
    }// end play

    public void NeedlePause()
    {// puasing will pput the current speed to 0 there for halting the needle to stay in its spot but also not using constraints cus that was being dumb
        currentPlayBackSpeed = 0;        
    }//end pause

    public void NeedleStop()
    {// the stop function returns the needle to its starting position which is another empty gameobject.
        transform.position = startingPos.position;
    }//end stop


    












    private void OnTriggerEnter2D(Collider2D contact)
    {
        //check if at the end of the button tracks to reset its position
        if (contact.gameObject.tag == "End")
        {
            transform.position = startingPos.position;
        }

        ///!!!!!!!!!!!HAD TO COMMENT OUT ALL THAT CUZ IT CAUSED ERRORS, ONCE I GOT TRACKS TO FILL WITH THE ARRAYS IT SHOULD WOULD
        ///HOWEVER STILL HAVE ERRORS PROLLY WHEN 0 BUT IT WORKS OTHER WISE WHEN IT GETS COMPONENT<BUTTONBEHAVORIUS> SO I DONT KNOW

        ////start guitar soundscheck
        if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 1)
        {
            FindObjectOfType<AudioManager>().PlayGuitar("Guitar1");
        }
        else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 2)
        {
            FindObjectOfType<AudioManager>().PlayGuitar("Guitar2");
        }
        else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 3)
        {
            FindObjectOfType<AudioManager>().PlayGuitar("Guitar3");
        }
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 4)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar4");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 5)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar5");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 6)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar6");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 7)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar7");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 8)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar8");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 9)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar9");
        //}
        //else if (contact.GetComponent<GuitarButtons>().currentSelectedTrack == 10)
        //{
        //    FindObjectOfType<AudioManager>().PlayGuitar("Guitar10");
        //}
        else FindObjectOfType<AudioManager>().PlayNothing();
        ////end guitarsounds check


        ////START BASS sound check
        //if (contact.GetComponent<BassButton>().currentSelectedTrack == 1)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass1");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 2)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass2");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 3)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass3");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 4)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass4");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 5)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass5");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 6)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass6");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 7)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass7");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 8)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass8");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 9)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass9");
        //}
        //else if (contact.GetComponent<BassButton>().currentSelectedTrack == 10)
        //{
        //    FindObjectOfType<AudioManager>().PlayBass("Bass10");
        //}
        //else FindObjectOfType<AudioManager>().Pause();
        ////end BASS


        //start drums
        if (contact.GetComponent<DrumButton>() != null)
        {
            if (contact.GetComponent<DrumButton>().currentSelectedTrack == 1)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum1");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 2)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum2");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 3)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum3");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 4)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum4");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 5)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum5");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 6)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum6");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 7)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum7");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 8)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum8");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 9)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum9");
            }
            else if (contact.GetComponent<DrumButton>().currentSelectedTrack == 10)
            {
                FindObjectOfType<AudioManager>().PlayDrums("Drum10");
            }
           
            //end drums
            Debug.Log("I am touching" + contact.gameObject.GetComponent<ButtonBehaviour>().numberOfClicks);
        } else FindObjectOfType<AudioManager>().PlayNothing();
    }//end of OnTriggerStay

}//end of the script



