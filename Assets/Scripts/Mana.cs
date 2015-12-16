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
	
	void Update ()
    {
         text_mana.text = "Mana : " + mana.ToString();
	}

    public void RecoverMana()
    {
        mana += manaPerTurn - owner.dominion.dominion;
    }

    public bool HasMana(int neededMana)
    {
        if (neededMana > mana)
            return (false);
        return (true);
    }

    public void UseMana(int usedMana)
    {
        mana -= usedMana;
        if (mana < 0)
            mana = 0;
    }
}
