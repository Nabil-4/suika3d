using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveScore(string highScore)
    {
        ScoreData scoreData = new ScoreData();
        scoreData.highScore = highScore;

        string path = Application.persistentDataPath + "/highScore.n";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, scoreData);

        fileStream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/highScore.n";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ScoreData scoreData = formatter.Deserialize(fileStream) as ScoreData;
            fileStream.Close();

            return scoreData;
        } 
        else
        {
            return null;
        }

    }
}
