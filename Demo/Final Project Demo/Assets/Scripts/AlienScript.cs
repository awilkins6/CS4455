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
    public ShipHealth shipHealth;
    public GameObject healthBar;
    public GameObject progressBar;
    public GameObject camera;

    public float health = 100f;
    public float hitFactor = 10f;

    private Rigidbody rb;
    private Animator animator;


    void Start()
    {
        // anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        aiState = AIState.SeekingShip;
        ship = GameObject.FindGameObjectWithTag("Ship");
        shipHealth = ship.GetComponent<ShipHealth>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    // public float dist;
    // public float lookAheadTime;
    // public Vector3 targetVel;
    // public Vector3 targetPos;


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
                animator.SetBool("attack", false);
                animator.SetBool("walk", true);
                break;
            case AIState.AttackingShip:
                shipHealth.doDamage(2f*Time.deltaTime);
                rb.isKinematic = true;
                //Debug.Log("do nothing");
                animator.SetBool("attack", true);
                animator.SetBool("walk", false);
                break;
        }
        healthBar.transform.LookAt(camera.transform);
        progressBar.GetComponent<ProgressBar>().BarValue = health;

        if (health <= 0f) {
          Die();
        }
    }

    void OnCollisionEnter(Collision c) {
        // Debug.Log(c);
        // Debug.Log(c.gameObject.name);
        if (c.gameObject == ship) {
          foundShip();
        }
        if (c.gameObject.tag == "Player") {
          health -= c.impulse.magnitude * hitFactor;
        }
    }

    public void doDamage(float damage) {
      health -= damage;
    }

    public void foundShip()
    {
        if (aiState != AIState.AttackingShip)
        {
            rb.Sleep();
            // Debug.Log("Found Ship");
            agent.SetDestination(transform.position);
            agent.Stop();
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            aiState = AIState.AttackingShip;
        }
    }

    public void Die() {
      GameManagerScript2.enemyDied();
      Destroy(gameObject);
    }
}
