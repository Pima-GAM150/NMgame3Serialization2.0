using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScoreList : MonoBehaviour {

    public InputField playerNameInput;
    public Text playerScoreFinal;

    public Text highScoreLabel;

    SerializableScores scores = new SerializableScores {};

    public void SaveScoreToList()
    {
        if (string.IsNullOrEmpty(playerNameInput.text)) return;

        HighScoreEntry scoreEntryToAdd = new HighScoreEntry
        {
            playerName = playerNameInput.text,
            playerScore = playerScoreFinal.text
        };


        scores.entries.Add(scoreEntryToAdd);

        Save();

        Regenerate();
    }

    public void Regenerate()
    {
        string listOfScores = "";

        for (int i = 0; i < scores.entries.Count; i++)
        {
            listOfScores += "Player: " + scores.entries[i].playerName + " : " + scores.entries[i].playerScore;
        }

        highScoreLabel.text = listOfScores;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("shooterHighScores", json);
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString("shooterHighScores");
        scores = JsonUtility.FromJson<SerializableScores>( json );
    }
}

[Serializable]
public class SerializableScores
{
    public List<HighScoreEntry> entries = new List<HighScoreEntry>();
}
