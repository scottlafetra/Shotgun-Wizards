using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public PlayerInputHandler playerIn;
    public ShotgunController shotgun;

    private CharacterController characterController;

    private StatsHandler myStats;

	void Start () {

        characterController = GetComponent<CharacterController>();
        if (characterController == null) {
            Debug.Log("Character Controller not found!");
        }

        myStats = GetComponent<StatsHandler>();
        if(myStats == null) {
            Debug.Log("Stats Handler not found!");
        }
    }

    void Update() {

        //Test input
        if (playerIn.GetDuelAxisAsButtonDown("Primary Spell") != 0) {
            Debug.Log("Prime Spell");
            shotgun.fire();
        }

        if (playerIn.GetButtonDown("Secondary Spell 1")) {
            Debug.Log("Spell1");
        }

        if (playerIn.GetButtonDown("Secondary Spell 2")) {
            Debug.Log("Spell2");
        }

        if (playerIn.GetButtonDown("Fire")) {
            myStats.AddElementalEffect(gameObject.AddComponent<ElementalEffect>());
        }

        //Movement
        characterController.Move(playerIn.GetMoveAxis() * myStats.moveSpeed * Time.deltaTime);

        //Look Direction
        Quaternion rotation = new Quaternion();
        Vector3 axisIn = playerIn.GetLookAxis();
        if(axisIn.magnitude > 0) {
            rotation.SetLookRotation(axisIn);
            transform.rotation = rotation;
        }
        
        if (!myStats.IsAlive()) {
            Destroy(gameObject);
        }
    }
}
