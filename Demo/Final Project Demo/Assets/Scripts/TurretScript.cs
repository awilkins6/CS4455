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
    public static float alienDamage = 5f;
    public static float dmgUpgrade = 2f;

    public Transform bulletPrefab;
    public AudioSource shotSound;
    public float bulletTimer = 0f;
    private float bulletTime = 0.5f;
    private GameObject nb;
    public static float bulletSpeed = 160f;

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

        if (bulletTimer <= 0) {
          bulletTimer = bulletTime;
          nb = Object.Instantiate(bulletPrefab, head.transform.position + 2f * head.transform.forward, Quaternion.identity).gameObject;
          nb.GetComponent<BulletScript>().setTarget(target);
          shotSound.Play();
        } else {
          bulletTimer -= Time.deltaTime;
        }
        // target.GetComponent<AlienScript>().doDamage(alienDamage*Time.deltaTime);

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

    public static void augmentDamage() {
      alienDamage += dmgUpgrade;
    }
}
