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

    void Start() {
      startingShipHealth = shipHealth;
      pb.BarValue = shipHealth;
    }

    // Update is called once per frame
    void Update() {
        pb.BarValue = shipHealth;
    }
    
    public void doDamage(float damage) {
      shipHealth -= damage;
      shipHealth = Mathf.Clamp(shipHealth, 0, 100f);
    }
}
