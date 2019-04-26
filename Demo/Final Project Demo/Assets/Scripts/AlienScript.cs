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
    //public GameObject ship;
    public ShipHealth shipHealth;
    public GameObject healthBar;
    public GameObject progressBar;
    public GameObject camera;

    public float health = 100f;
    public float hitFactor = 10f;

    private Rigidbody rb;
    private Animation anim;
    private AnimationClip walk;
    private AnimationClip attack;
    private Animator animator;
    private GameObject player;
    private GameObject ship;

    //public GameObject[] waypoints;
	//private int currWaypoint;
	public int waypointsSize;
	public int CurrWaypoint {
		get {
			return currWaypoint;
		}
		set {
			currWaypoint = value;
		}
	}

    void Start()
    {
        // anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        aiState = AIState.SeekingShip;
        ship = GameObject.FindGameObjectWithTag("Ship");
        shipHealth = ship.GetComponent<ShipHealth>();
        rb = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera");
        anim = GetComponent<Animation>();
        int index = 0;
        foreach(AnimationClip clip in anim) {
        	if (index == 0) {
        		walk = clip;
        	} else {
        		attack = clip;
        	}
        	index++;
        }
        animator = gameObject.GetComponent<Animator>();
        //animator.SetBool("attack", false);
        //animator.SetBool("walk", true);
        player = GameObject.Find("PlayerNewContols/Player Body");
        ship = GameObject.Find("ShipProp");
    }

    // public float dist;
    // public float lookAheadTime;
    // public Vector3 targetVel;
    // public Vector3 targetPos;

    private void setNextWaypoint() {
		if (currWaypoint + 1 < waypoints.Length - 1) {
			currWaypoint++;
		} else {
			currWaypoint = 0;
		}

		if (waypoints == null) {
			Debug.LogError("waypoints array returned null, size is 0");
		} else {
			agent.SetDestination(waypoints[currWaypoint].transform.position);
		}
	}

    // Update is called once per frame
    void Update()
    {
        // anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
    	// if (Vector3.Distance(player.transform.position,transform.position) <= 20) {
    	// 	aiState = AIState.SeekTarget;
    	// }

    	// if (Vector3.Distance(transform.position, ship.transform.position) <= 100) {
    	// 	aiState = AIState.SeekingShip;
    	// } else {
    	// 	aiState = AIState.Patrol;
    	// }
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
                    //anim.clip = walk;
                    //anim.Play();
                    animator.SetBool("attack", false);
            		animator.SetBool("walk", true);
                }
                break;
            case AIState.AttackingShip:
                shipHealth.doDamage(2f*Time.deltaTime);
                rb.isKinematic = true;
                //anim.clip = attack;
                //anim.Play();
                //Debug.Log("do nothing");
                animator.SetBool("attack", true);
            	animator.SetBool("walk", false);
                break;
            case AIState.SeekTarget:
          //   	float dist = Vector3.Distance(waypoints[waypoints.Length - 1].transform.position, transform.position);
        		// float lookAheadTime = dist / (navMeshAgent.speed);
        		// float lookAheadTime = Mathf.Clamp(lookAheadTime, -1, 1);
        		// Vector3 futureTarget = waypoints[waypoints.Length - 1].transform.position + (lookAheadTime * waypoints[waypoints.Length - 1].GetComponent<VelocityReporter>().velocity);
        		// navMeshAgent.SetDestination(futureTarget);
        		// animator.SetFloat("vely", navMeshAgent.velocity.magnitude/navMeshAgent.speed);
            	agent.SetDestination(player.transform.position);
            	break;
            case AIState.Patrol:
            	if (agent.remainingDistance < 1 && !agent.pathPending) {
        			setNextWaypoint();
        		}
        		animator.SetFloat("vely", agent.velocity.magnitude/agent.speed);
            	break;

        }
        healthBar.transform.LookAt(camera.transform);
        progressBar.GetComponent<ProgressBar>().BarValue = health;
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
        animator.SetBool("walk", false);
    }

    public void doDamage(float damage) {
      health -= damage;
      if (health <= 0f) {
        Die();
      }
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
            animator.SetBool("attack", true);
            animator.SetBool("walk", false);
        }
    }

    public void Die() {
      Destroy(gameObject);
    }
}
