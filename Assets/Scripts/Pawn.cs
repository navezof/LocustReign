using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pawn : MonoBehaviour {
    CombatManager combat;

    public Attribute attribute;
    public Dominion dominion;
    public Health health;
    public Mana mana;
    public PersonaManager persona;

    public Line activeLine;
    public Hand hand;

    public Button button_OnReady;

    public bool isWinner;
    public bool isAttacker;
    public int dice;
    public int power;

    void Awake()
    {
        attribute = GetComponent<Attribute>();
        dominion = GetComponent<Dominion>();
        health = GetComponent<Health>();
        mana = GetComponent<Mana>();
        persona = GetComponent<PersonaManager>();
    }

    void Start()
    {
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();

        persona.ActivatePersona();

        activeLine.gameObject.SetActive(false);
        button_OnReady.gameObject.SetActive(false);
    }

    public void Win()
    {
        dominion.addDominion(activeLine.GetCurrentCard().dominion);
        activeLine.GetCurrentCard().ExecuteShards(combat.defender);
    }

    public void Lose()
    {
        activeLine.GetCurrentCard().Break();
    }

    public void SetAttacker()
    {
        activeLine.ActivateAttackMode(true);
        hand.Activate(true);
        button_OnReady.gameObject.SetActive(true);
        isAttacker = true;
    }

    public void SetDefender()
    {
        activeLine.ActivateDefenseMode(true);
        hand.Activate(true);
        button_OnReady.gameObject.SetActive(true);
        isAttacker = false;
    }

    public void Die()
    {
        Debug.Log(name + ": Dead!");
    }

    public void onLineReadyClick()
    {
        hand.Activate(false);
        button_OnReady.gameObject.SetActive(false);
        if (isAttacker)
            combat.AttackerReady();
        else
            combat.DefenderReady();
    }

    public Persona GetPersona()
    {
        return (persona.GetPersona());
    }
}
