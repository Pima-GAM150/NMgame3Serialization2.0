using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

    public SongButtonCollection[] buttonCollections;

    public void LoadButtonClicked()
    {
        Load(PlayerPrefs.GetString("saveData"));
    }

    public void SaveButtonClicked()
    {
        SerializableSongButtonCollection songCollection = new SerializableSongButtonCollection { jsons = new string[buttonCollections.Length] };
        for( int collectionIndex = 0; collectionIndex < buttonCollections.Length; collectionIndex++ )
        {
            ButtonBehaviour[] buttonBehaviours = buttonCollections[collectionIndex].buttonBehaviours;
            SaveData saveData = new SaveData { trackNumbers = new int[buttonBehaviours.Length] };

            for (int index = 0; index < buttonBehaviours.Length; index++)
            {
                saveData.trackNumbers[index] = buttonBehaviours[index].numberOfClicks;
            }

            songCollection.jsons[collectionIndex] = JsonUtility.ToJson(saveData);
        }


        string json = JsonUtility.ToJson(songCollection);

        print("Saving data \n" + json);
        PlayerPrefs.SetString("saveData", json);

        // Decide where to save this string (on disk somewhere or in PlayerPrefs, etc.
    }

    public void Load( string json )
    {
        print("Loading data \n" + json);
        // Decide when to call this function (Start, when pressing a load button, etc)

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        for (int collectionIndex = 0; collectionIndex < buttonCollections.Length; collectionIndex++)
        {
            ButtonBehaviour[] buttonBehaviours = buttonCollections[collectionIndex].buttonBehaviours;

            for (int index = 0; index < buttonBehaviours.Length; index++)
            {
                buttonBehaviours[index].numberOfClicks = saveData.trackNumbers[index];
                buttonBehaviours[index].UpdateButtonText();
                print("Just set button " + buttonBehaviours[index].transform.parent.name + " text to " + saveData.trackNumbers[index].ToString());
            }
        }
    }
}

[System.Serializable]
public class SongButtonCollection
{
    public ButtonBehaviour[] buttonBehaviours;
}

public class SerializableSongButtonCollection
{
    public string[] jsons;
}

public class SaveData
{
    public int[] trackNumbers;
}
