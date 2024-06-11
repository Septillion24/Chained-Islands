using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 velocity;
    public float zoomSpeed = 5.0f;
    public float zoom = 5.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 20.0f;
    public float zoomVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left * speed * 5f * Time.deltaTime;
            // transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up * speed * 5f * Time.deltaTime;
            // transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right * speed * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down * speed * 5f * Time.deltaTime;
            // transform.position += Vector3.down * Time.deltaTime * speed;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            zoomVelocity -= zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoomVelocity += zoomSpeed * Time.deltaTime;
        }


        transform.position += velocity * Time.deltaTime;
        zoom = Mathf.Clamp(zoom + zoomVelocity, minZoom, maxZoom);
        Camera.main.orthographicSize = zoom;

        velocity = Vector3.ClampMagnitude(velocity, speed);
        velocity *= Mathf.Pow(0.05f, Time.deltaTime);
        zoomVelocity *= Mathf.Pow(0.02f, Time.deltaTime);
    }
}
