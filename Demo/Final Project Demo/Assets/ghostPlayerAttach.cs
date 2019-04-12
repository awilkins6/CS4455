using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostPlayerAttach : MonoBehaviour
{
    public GameObject target;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
      camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position; //follow player
        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
    }
}
