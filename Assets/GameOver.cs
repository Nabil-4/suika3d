using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameManager;
    public TextMeshProUGUI HighScoreNumber;
    public TextMeshProUGUI ScoreNumber;
    private float triggerTime;

    void OnTriggerEnter()
    {
        triggerTime = Time.time;
    }

    private void OnTriggerStay()
    {
        if (Time.time - triggerTime > 2f)
        {
            Debug.Log("GameOver");
            GameManager.SetActive(false);
            if (int.Parse(ScoreNumber.text) > int.Parse(HighScoreNumber.text))
            {
                HighScoreNumber.text = ScoreNumber.text;
                SaveSystem.SaveScore(HighScoreNumber.text);
            }
            Invoke("Restart", 3f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
