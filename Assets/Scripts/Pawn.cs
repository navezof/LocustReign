using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {
    CombatManager combat;
    CardUI ui;

    public Persona[] personas;
    public int cPersona;

    public int AGI;
    public int STR;
    public int WIT;

    public Card[] selectedCards;
    public Card.EAttribute[] selectedAttribute;

    public bool isWinner;

    void Awake()
    {
        ui = GetComponentInChildren<CardUI>();
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();
    }

	void Start ()
    {        
        selectedCards = new Card[3];
        selectedAttribute = new Card.EAttribute[2];
	}
	
	void Update ()
    {
	}

    public void SetDone(bool value)
    {
        combat.Done();
    }

    public void SetAttacker(bool value)
    {
        ui.SetAttackerMode(value);
    }

    public void SetDefender(bool value)
    {
        ui.SetDefenderMode(value, combat.round);
    }

    public void Reset()
    {
        selectedCards = new Card[3];
        selectedAttribute = new Card.EAttribute[2];
        ui.Reset();
    }

    public Persona GetPersona()
    {
        return (personas[cPersona]);
    }

    public int GetCardValue(int round)
    {
        return (GetPersona().mana + GetAttribute(selectedAttribute[round]) + selectedCards[round].sync);
    }

    public int GetAttribute(Card.EAttribute attribute)
    {
        switch (attribute)
        {
            case Card.EAttribute.AGI:
                return AGI;
            case Card.EAttribute.STR:
                return STR;
            case Card.EAttribute.WIT:
                return WIT;
            default:
                return 0;
        }
    }

    public void IsWinner(bool value)
    {
        isWinner = value;
    }
}
