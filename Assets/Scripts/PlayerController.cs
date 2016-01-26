using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public PlayerInputHandler playerIn;
    public ShotgunController shotgun;

    public SpellController primarySpell;
    public SpellController secondarySpell;

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
        if (playerIn.GetAxisAsButtonDown("Primary Spell") < 0) {
            shotgun.fire();
        }

        if (playerIn.GetAxisAsButtonDown("Primary Spell") > 0) {
            primarySpell.PressSpell(gameObject);
        }
        if (playerIn.GetAxisAsButtonUp("Primary Spell") > 0) {
            primarySpell.ReleaseSpell(gameObject);
        }

        if (playerIn.GetButtonDown("Secondary Spell")) {
            secondarySpell.PressSpell(gameObject);
        }
        if(playerIn.GetButtonUp("Secondary Spell")) {
            secondarySpell.ReleaseSpell(gameObject);
        }

        if (playerIn.GetButtonDown("Disarm")) {

            if(playerIn.GetAxisAsButton("Primary Spell") > 0) {

                primarySpell.DisarmSpell();

            } else if(playerIn.GetButton("Secondary Spell")) {

                secondarySpell.DisarmSpell();
            }
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
