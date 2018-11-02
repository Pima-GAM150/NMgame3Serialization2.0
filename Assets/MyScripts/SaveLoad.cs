using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

    public ButtonBehaviour[] buttonBehaviours;

    public void LoadButtonClicked()
    {
        Load(PlayerPrefs.GetString("saveData"));
    }

    public void SaveButtonClicked()
    {
        SaveData saveData = new SaveData { trackNumbers = new int[buttonBehaviours.Length] };

        for (int index = 0; index < buttonBehaviours.Length; index++)
        {
            saveData.trackNumbers[index] = buttonBehaviours[index].numberOfClicks;
        }

        string json = JsonUtility.ToJson(saveData);

        print("Saving data \n" + json);
        PlayerPrefs.SetString("saveData", json);

        // Decide where to save this string (on disk somewhere or in PlayerPrefs, etc.
    }

    public void Load( string json )
    {
        print("Loading data \n" + json);
        // Decide when to call this function (Start, when pressing a load button, etc)

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        for (int index = 0; index < buttonBehaviours.Length; index++)
        {
            buttonBehaviours[index].numberOfClicks = saveData.trackNumbers[index];
            buttonBehaviours[index].UpdateButtonText();
            print("Just set button " + buttonBehaviours[index].transform.parent.name + " text to " + saveData.trackNumbers[index].ToString());
        }
    }
}

public class SaveData
{
    public int[] trackNumbers;
}
