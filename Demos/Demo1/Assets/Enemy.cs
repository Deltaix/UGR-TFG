using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float xSpeed, ySpeed;
    public GameObject bullet;
    public bool canShoot;
    public float fireRate;
    public float health;
    public ParticleSystem explosion;
    public int score;
    public GameObject heal;
    float healChance;
    bool dropHeal;
    Rigidbody2D rb;
    Vector2 minScreenBounds;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        if (PlayerPrefs.GetInt("difficulty") > 0)
        {
            healChance = 0.25f;
        }
        else
        {
            healChance = 0.45f;
        }

        if (Random.Range (0f, 1f) <= healChance)
        {
            dropHeal = true;
        }
        else
        {
            dropHeal = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);

        if (transform.position.y < minScreenBounds.y - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Spaceship>().Damage();
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 500);
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (dropHeal)
            {
                Instantiate(heal, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            if (dropHeal)
            {
                Instantiate(heal, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
