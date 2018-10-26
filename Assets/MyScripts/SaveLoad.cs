using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

    public Text[] buttonTexts;

    public void SaveButtonClicked()
    {
        SaveData saveData = new SaveData { trackNumbers = new int[buttonTexts.Length] };

        for (int index = 0; index < buttonTexts.Length; index++)
        {
            saveData.trackNumbers[index] = int.Parse( buttonTexts[index].text );
        }

        string json = JsonUtility.ToJson(saveData);

        // Decide where to save this string (on disk somewhere or in PlayerPrefs, etc.
    }

    public void Load( string json )
    {
        // Decide when to call this function (Start, when pressing a load button, etc)

        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        for (int index = 0; index < buttonTexts.Length; index++)
        {
            buttonTexts[index].text = saveData.trackNumbers[index].ToString();
        }
    }
}

public class SaveData
{
    public int[] trackNumbers;
}
