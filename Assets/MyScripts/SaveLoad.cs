using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

    // the Dropdown UI object that stores each song listing
    public Dropdown songsDropdown;

    // stores a key / value pair for each song (identified by an integer - its index in the dropdown) and the integer array that represents the track data for that song
    Dictionary<int, int[]> allTrackDataPerSong = new Dictionary<int, int[]>();

    // a list of all the UI objects that can be clicked on to change track numbers
    public List<ButtonBehaviour> buttonBehaviours = new List<ButtonBehaviour>();

    // make this manager a singleton so it's easy to access from anywhere
    public static SaveLoad singleton;

    void Start() {
        singleton = this;

        // for every option in the songs dropdown list
        for( int index = 0; index < totalSongs; index++ ) {

            // add to the dictionary a key/value pair
            // the key is the song, the value is an array of integers the same length as the number of buttons
            allTrackDataPerSong.Add( index, new int[buttonBehaviours.Count] );
        }
    }

    public void LoadButtonClicked()
    {
        Load(PlayerPrefs.GetString("saveData"));
    }

    public void SaveButtonClicked()
    {
        // create a new "all songs" data object (defined at the bottom of the file) that holds an array of json.  It's a json string that holds json strings in an array :P
        SongJsons songData = new SongJsons { songJsons = new string[totalSongs] };

        // go through the dictionary we hold in memory that contains track data per song
        for( int songIndex = 0; songIndex < totalSongs; songIndex++ ) {

            // create a new track data object into which we'll put the array of integers that we've been holding that represents the current track data
            TrackData trackData = new TrackData { trackNumbers = allTrackDataPerSong[songIndex] };

            // convert the track data object to a string and then assign it to one slot of the "all songs" data object
            songData.songJsons[songIndex] = JsonUtility.ToJson( trackData );
        }

        // convert the "all songs" data object to its own string and then save it in PlayerPrefs
        string allSongsJson = JsonUtility.ToJson( songData );
        PlayerPrefs.SetString("saveData", allSongsJson);
    }

    public void Load( string saveData )
    {
        print("Loading data \n" + saveData);

        // unpack the "all songs" string into a data object (this whole method is more or less the opposite of the save method)
        SongJsons songData = JsonUtility.FromJson<SongJsons>( saveData );

        // go through each string that represents a song in the "all songs" data object
        for( int songIndex = 0; songIndex < songData.songJsons.Length; songIndex++ ) {

            // create a track data object and fill it with the info that was stored about tracks for this song (i.e. an integer array)
            TrackData trackData = JsonUtility.FromJson<TrackData>( songData.songJsons[songIndex] );
            allTrackDataPerSong[songIndex] = trackData.trackNumbers;
        }

        // update the text boxes to match the data for each button
        for( int buttonIndex = 0; buttonIndex < buttonBehaviours.Count; buttonIndex++ ) {
            buttonBehaviours[buttonIndex].UpdateButtonText();
        }
    }

    // this method changes the data stored for a button
    public void UpdateTrackData( ButtonBehaviour button, int newTrackNumber ) {

        // find which button we're updating as an index in our button array
        int buttonIndex = buttonBehaviours.IndexOf( button );

        // get all the track data for the current song
        int[] trackData = currentTrackData;

        // change the track data associated with this button to the new number this method has been asked to use
        trackData[buttonIndex] = newTrackNumber;

        // update the dictionary that stores all data by giving it the modified array for the current song
        allTrackDataPerSong[songsDropdown.value] = trackData;
    }

    public int GetTrackData( ButtonBehaviour button ) {
        // find which index a certain button represents in our buttons array and then return the stored track data for that button
        int buttonIndex = buttonBehaviours.IndexOf( button );
        return currentTrackData[buttonIndex];
    }

    // change the currently selected song based on a new song index (from the dropdown list) and alter the "current track" of each button to match
    public void UpdateAllButtonsForSong( int songIndex ) {
        int[] trackData = allTrackDataPerSong[songIndex];

        for( int buttonIndex = 0; buttonIndex < buttonBehaviours.Count; buttonIndex++ ) {
            buttonBehaviours[buttonIndex].currentSelectedTrack = trackData[buttonIndex];
        }
    }

    // convenience properties to keep the code above cleaner because they get used a lot
    int totalSongs { get { return songsDropdown.options.Count; } }
    int[] currentTrackData { get { return allTrackDataPerSong[songsDropdown.value]; } }
}

// data objects that store a primitive array for easy conversion to json
public class SongJsons {
    public string[] songJsons;
}

public class TrackData
{
    public int[] trackNumbers;
}
