using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMarkerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        AlienScript x = other.gameObject.GetComponent<AlienScript>();
        if (x)
        {
            Debug.Log("Ship hit a alien!");
            x.foundShip();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("stay");
    }
}
