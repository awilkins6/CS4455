using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public enum AIState
    {
        Idle,
        Targeting
    };

    public AIState aiState;
    public GameObject target;

    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        aiState = AIState.Idle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
      if (other.GetComponent<AlienScript>() != null) {
        head.transform.LookAt(other.transform.position);
      }
    }
}
