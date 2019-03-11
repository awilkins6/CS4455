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
        
    }
}
