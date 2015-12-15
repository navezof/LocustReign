using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatUI : MonoBehaviour {

    CombatManager combat;

    public Text phase;
    public Text turn;
    public Button button_endPhase;

    void Awake()
    {
        combat = GetComponent<CombatManager>();
    }
	
	void Update ()
    {
        phase.text = "Phase : " + combat.phase.ToString(); ;
        turn.text = "Turn : " + combat.turn.ToString();
	}

    public void ShowButtonEndPhase(bool value)
    {
        button_endPhase.gameObject.SetActive(value);
    }
}
