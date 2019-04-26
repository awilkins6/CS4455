using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  	public GameObject player;
    public GameObject pole;
    public GameObject camera;

  	public Vector3 offset;
    public float speedH = 4.0f;
    public float speedV = 4.0f;
    public bool shopOpen = false;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Ray ray;
    private RaycastHit hit;
    private float dist = 1f;
    public float maxDist = 5f;
    private float buffer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (!shopOpen)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60, 60);
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        transform.position = player.transform.position + offset;



        ray = new Ray(pole.transform.position, -1 * pole.transform.forward);
        if (Physics.Raycast(ray, out hit)) {
          dist = Mathf.Clamp(hit.distance, 0, maxDist);
        } else {
          dist = maxDist;
        }

        camera.transform.position = pole.transform.position + pole.transform.rotation * new Vector3(0, 0, -dist+buffer);
    }
}
