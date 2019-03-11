using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AlienScript : MonoBehaviour
{
    public GameObject[] waypoints;
    public int currWaypoint = 0;
    // private Animator anim;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    public enum AIState
    {
        Patrol,
        SeekTarget,
        Wait,
        SeekingShip,
        AttackingShip,
    };

    public AIState aiState;
    public float t = 0f;
    public GameObject cursor;
    public GameObject ship;


    void Start()
    {
        // anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        aiState = AIState.SeekingShip;
        ship = GameObject.FindGameObjectWithTag("Ship");
    }
    public float dist;
    public float lookAheadTime;
    public Vector3 targetVel;
    public Vector3 targetPos;


    // Update is called once per frame
    void Update()
    {
        // anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);

        switch(aiState)
        {
            //case AIState.SeekingShip:
                //if (!agent.pathPending && agent.remainingDistance < 0.5f)
                //{
                //    t = 0.5f;
                //    aiState = AIState.Wait;
                //}
                //break;
            case AIState.SeekingShip:
                if (!agent.pathPending)
                {
                    agent.SetDestination(ship.transform.position);
                }
                break;
            case AIState.AttackingShip:
                //Debug.Log("do nothing");
                break;
        }
    }

    void OnCollisionEnter(Collision c) {
        Debug.Log(c);
        Debug.Log(c.gameObject.name);
        if (c.gameObject == ship) {
            foundShip();
        }
    }

    public void foundShip()
    {
        if (aiState != AIState.AttackingShip)
        {
            Debug.Log("Found Ship");
            agent.Stop();
            aiState = AIState.AttackingShip;
        }
    }
}
