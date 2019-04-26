using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float deathTimer = 10f;
    public GameObject target;

    void Start() {

    }

    void Update() {
      deathTimer -= Time.deltaTime;
      if (deathTimer <= 0) {
        Object.Destroy(gameObject);
      }
    }

    public void setTarget(GameObject t) {
      target = t;
      // if (target) {
      GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * TurretScript.bulletSpeed;
      // }
    }

    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.GetComponent<AlienScript>()) {
        other.gameObject.GetComponent<AlienScript>().doDamage(TurretScript.alienDamage);
      }
      Object.Destroy(gameObject);
      Debug.Log(other.gameObject.name);
    }

}
