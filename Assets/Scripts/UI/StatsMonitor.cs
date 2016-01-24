using UnityEngine;
using UnityEngine.UI;

public class StatsMonitor : MonoBehaviour {

    public StatsHandler target;

    private Text text;

    void Start() {
        text = GetComponent<Text>();
    }

	void OnGUI () {
        if(target != null) {//if not dead

            text.text  = "Health: " + target.GetHealth() + "\n";
            text.text += "Mana: " + target.GetMana();

        } else { //if dead

            text.text  = "Health: Dead\n";
            text.text += "Mana: Dead";
        } 
        
	}
}
