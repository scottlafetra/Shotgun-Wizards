using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    private Transform player;
    private StatsHandler playerStats;
    private StatsHandler enemyStats;
    private GameObject[] playerList;
    private NavMeshAgent nav;

    private StatsHandler myStats;

    void Start() {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        player = playerList[0].transform;
        playerStats = playerList[0].GetComponent<StatsHandler>();
        enemyStats = GetComponent<StatsHandler>();
        //nav = GetComponent<NavMeshAgent>();

        myStats = GetComponent<StatsHandler>();
    }

	
	// Update is called once per frame
	void Update () {/*
        if(enemyStats.GetHealth() > 0 && playerStats.GetHealth() > 0) {
            nav.SetDestination(player.position);
        }
        else {
            nav.enabled = false;
        }*/

        if (!myStats.IsAlive()) {
            Destroy(gameObject);
        }
	}
}
