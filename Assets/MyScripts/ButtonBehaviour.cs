using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBehaviour : MonoBehaviour {

    public Text buttonLabel;
    public virtual int currentSelectedTrack {
        get {
            return SaveLoad.singleton.GetTrackData( this );
        }
        set {
            if( currentSelectedTrack < maxNumberOfClicks ) {
                SaveLoad.singleton.UpdateTrackData( this, value );
            }
            else {
                SaveLoad.singleton.UpdateTrackData( this, 0 );
            }

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
