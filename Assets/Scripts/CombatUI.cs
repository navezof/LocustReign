using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatUI : MonoBehaviour {

    CombatManager combat;
    public Text phase;

	// Use this for initialization
	void Start () {
        combat = GetComponent<CombatManager>();
	}
	
	// Update is called once per frame
	void Update () {
        phase.text = "Turn : " + combat.turn + " - Round : " + combat.round + " - Phase : " + combat.phase.ToString();
	}
}
