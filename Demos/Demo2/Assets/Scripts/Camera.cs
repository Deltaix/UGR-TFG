using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float smoothFactor;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
        smoothFactor = 0.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        transform.LookAt(player);
    }
}
