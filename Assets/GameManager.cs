using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] fruits;
    public float delay;
    float timer;
    public TextMeshProUGUI HighScoreNumber;

    public void Start()
    {
        if (SaveSystem.LoadScore() != null)
        {
            HighScoreNumber.text = SaveSystem.LoadScore().highScore;
        }
    }

    void FixedUpdate()
    {
           timer += Time.deltaTime;
            if (timer > delay)
            {
                GameObject fruit = Instantiate(fruits[Random.Range(0, 4)], new Vector3(Random.Range(-3.5f, 0f), 4, 0), Quaternion.Euler(100, 0, 0));
                fruit.SetActive(true);
                timer = 0;
            }       
    }
}
