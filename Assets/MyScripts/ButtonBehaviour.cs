using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBehaviour : MonoBehaviour {

    public Text buttonLabel;

    // instead of having a lot of virtual methods, why not a virtual property?
    // now, whenever you set the currentSelectedTrack integer, it will do a bunch of other things, too, including updating the button text
    public virtual int currentSelectedTrack {
        get {
            // the actual number that represents this button's track data is no longer stored on the button object
            // this is because it can change depending on the song.  Instead, the SaveLoad class has a dictionary that keeps that data.
            // So, when asked what its current track is, this button just returns the associated data from the SaveLoad class, which
            // knows which song it is
            return SaveLoad.singleton.GetTrackData( this );
        }
        set {
            if( currentSelectedTrack < maxNumberOfClicks ) {
                // changes the track number for this button by sending the new preferred value to the SaveLoad manager to change
                SaveLoad.singleton.UpdateTrackData( this, value );
            }
            else {
                // or sets it to zero if it's above the max, like you were before
                SaveLoad.singleton.UpdateTrackData( this, 0 );
            }

            // after everything, update the appearance of the button
            UpdateButtonText();
        }
    }

    public int maxNumberOfClicks;

    public virtual void ButtonClick()
    {
        currentSelectedTrack++;
    }

    public virtual void UpdateButtonText() {
        buttonLabel.text = currentSelectedTrack.ToString();
    }
}
