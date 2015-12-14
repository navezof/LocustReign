using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mana : MonoBehaviour {

    Pawn owner;

    public int mana;
    public int manaPerTurn;
    public Text text_mana;

    void Awake()
    {
        owner = GetComponentInParent<Pawn>();
    }
	
	void Update () {
        text_mana.text = "Mana : " + mana.ToString();
	}

    void RecoverMana()
    {
        mana += manaPerTurn - owner.dominion.dominion;
    }
}
