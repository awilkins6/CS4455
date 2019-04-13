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
    public float alienDamage = 4f;

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
        target.GetComponent<AlienScript>().doDamage(alienDamage*Time.deltaTime);
        if (Vector3.Distance(transform.position, target.transform.position) < 10f) {
          target = null;
        }
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
}
