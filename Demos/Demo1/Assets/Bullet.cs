using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int damage;
    public int dir = 1;

    Vector2 minScreenBounds, maxScreenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 1)
        {
            rb.velocity = new Vector2(0, 11);
        }
        else
        {
            rb.velocity = new Vector2(0, -7);
        }

        if (transform.position.y > maxScreenBounds.y || transform.position.y < minScreenBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && dir == 1)
        {
            if (PlayerPrefs.GetInt("difficulty") > 0)
                damage = 10;
            else
                damage = 15;

            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && dir == -1)
        {
            collision.gameObject.GetComponent<Spaceship>().Damage();
            int score = PlayerPrefs.GetInt("Score") - 100;

            if (score < 0)
            {
                PlayerPrefs.SetInt("Score", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Score", score);
            }
            Destroy(gameObject);
        }
    }
}