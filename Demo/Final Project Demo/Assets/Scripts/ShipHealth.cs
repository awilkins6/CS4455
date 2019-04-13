using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float shipHealth;
    float startingShipHealth;
    List<GameObject> aliens = new List<GameObject>();
    public ProgressBar pb;
    public float alienDamage;

    void Start()
    {
   //      foreach (Transform child in GameObject.Find("Aliens").transform) {
   // 			aliens.Add(child.gameObject);
 		// }
 		startingShipHealth = shipHealth;
 		pb.BarValue = shipHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(shipHealth);
        pb.BarValue = shipHealth;
        // Debug.Log(pb.BarValue);
    }

    // void OnCollisionEnter(Collision c) {
    // 	if(c.gameObject.tag == "Alien") {
    //         shipHealth -= alienDamage * Time.deltaTime;
    //         Debug.Log("alien contact");
    //     }
    //
    //     //debug test to see if one alien touches based on name
    //     // if(c.gameObject.name == "Alien") {
    //     //     shipHealth -= alienDamage;
    //     //     Debug.Log("one alien contact");
    //     // }
    // }
    public void doDamage(float damage) {
      shipHealth -= damage;
      shipHealth = Mathf.Clamp01(shipHealth);
    }
}
