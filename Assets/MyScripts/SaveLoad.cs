using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

    public Dropdown songsDropdown;
    Dictionary<int, int[]> allTrackDataPerSong = new Dictionary<int, int[]>();

    public List<ButtonBehaviour> buttonBehaviours = new List<ButtonBehaviour>();

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
        SongJsons songData = new SongJsons { songJsons = new string[totalSongs] };

        for( int songIndex = 0; songIndex < totalSongs; songIndex++ ) {

            TrackData trackData = new TrackData { trackNumbers = allTrackDataPerSong[songIndex] };
            songData.songJsons[songIndex] = JsonUtility.ToJson( trackData );
        }

        string allSongsJson = JsonUtility.ToJson( songData );
        PlayerPrefs.SetString("saveData", allSongsJson);

        // Decide where to save this string (on disk somewhere or in PlayerPrefs, etc.
    }

    public void Load( string saveData )
    {
        print("Loading data \n" + saveData);

        SongJsons songData = JsonUtility.FromJson<SongJsons>( saveData );

        for( int songIndex = 0; songIndex < songData.songJsons.Length; songIndex++ ) {

            TrackData trackData = JsonUtility.FromJson<TrackData>( songData.songJsons[songIndex] );
            allTrackDataPerSong[songIndex] = trackData.trackNumbers;
        }

        for( int buttonIndex = 0; buttonIndex < buttonBehaviours.Count; buttonIndex++ ) {
            buttonBehaviours[buttonIndex].UpdateButtonText();
        }
    }

    public void UpdateTrackData( ButtonBehaviour button, int newTrackNumber ) {
        int buttonIndex = buttonBehaviours.IndexOf( button );
        int[] trackData = currentTrackData;
        trackData[buttonIndex] = newTrackNumber;
        allTrackDataPerSong[songsDropdown.value] = trackData;
    }

    public int GetTrackData( ButtonBehaviour button ) {
        int buttonIndex = buttonBehaviours.IndexOf( button );
        return currentTrackData[buttonIndex];
    }

    public void UpdateAllButtonsForSong( int songIndex ) {
        int[] trackData = allTrackDataPerSong[songIndex];

        for( int buttonIndex = 0; buttonIndex < buttonBehaviours.Count; buttonIndex++ ) {
            buttonBehaviours[buttonIndex].currentSelectedTrack = trackData[buttonIndex];
        }
    }

    int totalSongs { get { return songsDropdown.options.Count; } }
    int[] currentTrackData { get { return allTrackDataPerSong[songsDropdown.value]; } }
}

public class SongJsons {
    public string[] songJsons;
}

public class TrackData
{
    public int[] trackNumbers;
}
