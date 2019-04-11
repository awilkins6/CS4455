using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHook : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    //private Vector3 offset;

    public float turnSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 0.3f, target.transform.position.z - 0.6f);
    }

}
