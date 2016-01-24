using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellController : MonoBehaviour {

    public GameObject precastEffect;
    public GameObject spellEffect;

    public float cooldownTime;
    private float nextCast;

    public bool isBoodmagic;

    public float manaCost;

    private Dictionary<GameObject, GameObject> castSpells;//spell effects in play that can be looked up by caster

    void Start() {
        nextCast = 0;
    }

    private void InstatiateSpell(GameObject caster, GameObject spell) {
        /*
        if( castSpells.ContainsKey())

        castSpell = (GameObject) Instantiate(spell, caster.transform.position, caster.transform.rotation);
        castSpell.GetComponent<ProjectileController>().setShooter(caster);
        */
    }

    public void PressSpell(GameObject caster) {
        StatsHandler casterStats = caster.GetComponent<StatsHandler>();

        //check for cooldown
        if (Time.time >= nextCast) {
            nextCast = Time.time + cooldownTime;//set nup next time for next cast

            //check if caster has enough mana and cast if they do, cast the spell
            if (casterStats.GetMana() >= manaCost) {

                //remove mana then cast
                casterStats.ChangeMana(-manaCost);
                InstatiateSpell(caster, precastEffect);

            }
            else if (isBoodmagic && casterStats.GetHealth() + casterStats.GetMana() >= manaCost) {

                //remove mana and health then cast
                casterStats.ChangeHealth(-(manaCost - casterStats.GetMana()));//minus the extra needed
                casterStats.ChangeMana(-casterStats.GetMana());
                InstatiateSpell(caster, precastEffect);
            }
        }
    }

    public void ReleaseSpell(GameObject caster) {
        //if()
    }

    public void DisarmSpell(GameObject caster) {

    }
}
