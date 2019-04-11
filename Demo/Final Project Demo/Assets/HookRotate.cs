using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRotate : MonoBehaviour
{

    [SerializeField]
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -60, 60);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


        
    }
}
