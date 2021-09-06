using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody rb;
    private AudioSource jingle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jingle = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-movementVertical, 0.0f, movementHorizontal);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        jingle.Play();
        Destroy(col.gameObject);
    }
}
