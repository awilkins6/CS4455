using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	[SerializeField]
	private Vector3 offset;
    public float turnSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.EulerAngles(0, turnSpeed*moveHorizontal, 0) * transform.rotation;

        transform.position = player.transform.position + offset;

    }
}
