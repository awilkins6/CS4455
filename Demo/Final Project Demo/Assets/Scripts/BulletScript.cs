using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float deathTimer = 10f;
    public GameObject target;

    void Update() {
      deathTimer -= Time.deltaTime;
      if (deathTimer <= 0) {
        Object.Destroy(gameObject);
      }
    }

    public void setTarget(GameObject t) {
      target = t;
      GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * TurretScript.bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.GetComponent<AlienScript>()) {
        other.gameObject.GetComponent<AlienScript>().doDamage(TurretScript.alienDamage);
        Object.Destroy(gameObject);
      }
    }

}
