using UnityEngine;
using TMPro;

public class FruitCollision : MonoBehaviour
{
    public GameObject[] fruits;
    public TextMeshProUGUI ScoreNumber;
    void OnCollisionEnter(Collision collision)
    {
        int n = 0;
        if (collision.collider.name == gameObject.name)
        {
            for (int i = 0; i < fruits.Length; i++)
            {
                if (gameObject.name == fruits[i].name)
                {
                    n = i;
                }
            }

            if (gameObject.transform.position.y > collision.collider.transform.position.y)
            {
                Destroy(collision.collider.gameObject);
                Destroy(gameObject);
                if(n + 1 < fruits.Length)
                {
                    Instantiate(fruits[n + 1], gameObject.transform.position, Quaternion.Euler(100, 0, 0));
                }
                ScoreNumber.text = (int.Parse(ScoreNumber.text) + ((n + 1) * 2)).ToString();
            }
        }  
    }
}
