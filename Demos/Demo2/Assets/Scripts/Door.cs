using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject rightDoor, leftDoor;
    private bool isOpen;
    private AudioSource jingle;
    // Start is called before the first frame update
    void Start()
    {
        rightDoor = transform.GetChild(0).gameObject;
        leftDoor = transform.GetChild(1).gameObject;
        isOpen = false;
        jingle = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            Vector3 targetRight = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y, 3.75f);
            Vector3 targetLeft = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y, -3.75f);

            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, targetRight, Time.deltaTime);
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, targetLeft, Time.deltaTime);
        }
    }

    public void Open()
    {
        isOpen = true;
        jingle.Play();
    }
}
