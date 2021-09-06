using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    GameObject next;
    public int waves = 1;
    Vector2 minScreenBounds, maxScreenBounds;

    private void Awake()
    {
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < waves; i++)
        {
            float rand = Random.Range(0f, 1f);

            if (rand <= 0.15)
            {
                next = enemies[2];
            }
            else if (rand <= 0.4)
            {
                next = enemies[0];
            }
            else
            {
                next = enemies[1];
            }

            Instantiate(next, new Vector3(Random.Range(minScreenBounds.x + 1f, maxScreenBounds.x - 1f), maxScreenBounds.y + 0.2f, 0), Quaternion.identity);
        }
    }
}
