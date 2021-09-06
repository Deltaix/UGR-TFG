using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int health = 14;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    bool found;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health/2)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            hearts[i].sprite = fullHeart;
        }

        if (health % 2 == 1)
        {
            found = false;
            for (int i = hearts.Length - 1; i >= 0 && !found; i--)
            {
                if(hearts[i].IsActive())
                {
                    hearts[i + 1].enabled = true;
                    hearts[i + 1].sprite = halfHeart;
                    found = true;
                }
            }

            if (!found)
            {
                hearts[0].enabled = true;
                hearts[0].sprite = halfHeart;
            }
        }
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }
}