using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class datamanagement : MonoBehaviour
{
    public static datamanagement dataManagement;
    public int highscore;

    private void Awake()
    {
        if (dataManagement == null){
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        } else if (dataManagement != this)
        {
            Destroy(gameObject);
        }
        }
    public void SaveData()
        //Data is saved
    {
        BinaryFormatter binform = new BinaryFormatter(); //creates a bin formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gamescore.dat"); // creates the file
        gameData data = new gameData(); // creates container for the data
        data.highScore = highscore;
        binform.Serialize(file, data); //serializes and adds score to the data file
        file.Close(); //closes the file
    }
    public void LoadData()
    {
        // data is loaded
        if (File.Exists (Application.persistentDataPath + "/gamescore.dat"))
        {
            BinaryFormatter binform = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "gamescore.dat", FileMode.Open);
            gameData data = (gameData)binform.Deserialize(file);
            file.Close();
            highscore = data.highScore;
        }
    }

    }
[Serializable]
class gameData
{
    public int highScore;
}
