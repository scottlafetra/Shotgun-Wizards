using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    private GameObject targetPlayer;
    private StatsHandler playerStats;
    private GameObject[] playerList;
    private NavMeshAgent nav;

    private StatsHandler myStats;

    public float attackCooldown = 1;
    public float attackDamage;
    public float attackRange;
    private float nextAttackAt;

    private bool firstUpdate = true;


    void Start() {
        playerList = GameObject.FindGameObjectsWithTag("Player");

        //find the closest player
        targetPlayer = playerList[0];
        playerStats = playerList[0].GetComponent<StatsHandler>();
        nav = GetComponent<NavMeshAgent>();

        myStats = GetComponent<StatsHandler>();

        nextAttackAt = 0;

        nav.speed = myStats.moveSpeed;
    }

	
	// Update is called once per frame
	void Update () {
        //snyc speed
        nav.speed = myStats.moveSpeed;

        if (!myStats.IsAlive()) {
            Destroy(gameObject);
        }

        if(playerStats.GetHealth() > 0) {
            nav.SetDestination(targetPlayer.transform.position);
        }
        else {
            nav.enabled = false;
        }

        

        //attack if in range and cooldown has passed
        if(!firstUpdate && nav.remainingDistance < attackRange && Time.time > nextAttackAt) {
            targetPlayer.GetComponent<StatsHandler>().ChangeHealth(-attackDamage);

            //set when enemy can next attack
            nextAttackAt = Time.time + attackCooldown;
        }

        firstUpdate = false;
	}
}
