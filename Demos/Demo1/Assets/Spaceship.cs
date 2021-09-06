using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gun;
    public GameObject bullet;
    public float speed;
    public float delay;
    bool allowFire;
    public ParticleSystem explosion;
    int health = 14;
    public Health hp;
    public GameObject gameOver;
    AudioSource[] sounds;
    Vector3 pos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = transform.Find("Gun").gameObject;
        allowFire = true;
        sounds = GetComponents<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed));

        pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (Input.GetKey(KeyCode.Mouse0) && allowFire)
        {
            StartCoroutine(Shoot());
        }
    }

    public void Damage()
    {
        if (PlayerPrefs.GetInt("difficulty") > 0)
        {
            health = health - 2;
        }
        else
        {
            health--;
        }

        hp.SetHealth(health);
        sounds[2].Play();

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameOver.GetComponent<GameOver>().End();
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        allowFire = false;
        Instantiate(bullet, gun.transform.position, Quaternion.identity);
        sounds[0].Play();
        yield return new WaitForSeconds(delay);
        allowFire = true;
    }

    public void Heal()
    {
        sounds[1].Play();
        health += 2;
        if (health > 14)
        {
            health = 14;
        }
        hp.SetHealth(health);
    }
}
