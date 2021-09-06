using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        float timer = 0.0f;

        while (timer < 3.0f)
        {
            timer += Time.deltaTime;
        }

        gameObject.SetActive(true);
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
