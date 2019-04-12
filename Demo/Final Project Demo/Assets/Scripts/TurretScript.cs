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
      if (target) {
        head.transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(target.transform.position-transform.position).eulerAngles.y, 0);
      }
    }

    private void OnTriggerStay(Collider other)
    {
      if (!target) {
        if (other.gameObject.GetComponent<AlienScript>()) {
          target = other.gameObject;
        }
      }
    }

    private void OnTriggerLeave(Collider other)
    {
      if (target == other) {
        target = null;
      }
    }
}
