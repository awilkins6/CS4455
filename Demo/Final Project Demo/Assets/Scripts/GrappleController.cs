using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public bool hooked;
    public static bool fired;

    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;

    void Update()
    {
        //firing hook by left clicking mouse
        if (Input.GetMouseButton(0) && fired == false)
        {
            fired = true;

        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(-Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
        }

        // if the hook was launched and collided with a hookable obj
        if (hooked == true)
        {
            hook.transform.parent = hookedObject.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 1)
            {
                ReturnHook();
            }

        } else
        {
            hook.transform.parent = hookHolder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void ReturnHook()
    {
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;
    }
}
