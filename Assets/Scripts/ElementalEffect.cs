using UnityEngine;
using System.Collections;

public class ElementalEffect : MonoBehaviour {

    private string effectName;

    private float startTime;
    protected float lifetime;

    protected StatsHandler stats;

    private int stacks;

    public ElementalEffect() {
        Start();
    }

	// Use this for initialization
	void Start () {
        setName();
        startTime = Time.time;
        stacks = 1;
        lifetime = 5.0f;
        stats = GetComponent<StatsHandler>();
	}

    protected void setName() {//Override this to set the name
        effectName = "Default Effect";
    }

	// Update is called once per frame
	void Update () {
        stats.ChangeHealth(-1 * stacks * Time.deltaTime);
	}

    public string getName() {
        return effectName;
    }

    public bool isDone() {
        if(Time.time > startTime + lifetime) {
            if (stacks < 1) {
                return true;

            } else {
                stacks -= 1;
                startTime += lifetime;

                return isDone();
            }
        } else {
            return false;
        }
    }

    public void addToStack() {
        stacks += 1;
    }

}
