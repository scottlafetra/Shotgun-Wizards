using UnityEngine;
using System.Collections;

public class SpawnsOnDeath : MonoBehaviour {

    public GameObject toSpawn;
	
	void OnDisable () {
        Instantiate(toSpawn, transform.position, transform.rotation);
	}
}
