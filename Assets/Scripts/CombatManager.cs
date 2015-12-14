using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour {

    public enum EPhase
    {
        ATTACKER,
        DEFENDER,
        RESOLUTION
    }

    Pawn attacker;
    Pawn defender;

    CombatUI combatUI;
    public ResolutionUI resolutionUI;

    public Pawn red;
    public Pawn blue;

    public int round;

    public void Awake()
    {
        combatUI = GetComponent<CombatUI>();
        resolutionUI.gameObject.SetActive(false);
    }

    public void Start()
    {
        SetRole();
        combatUI.phase.text = attacker.name + " : choose your attacks.";
        attacker.SetAttacker();
    }

    void SetRole()
    {
        if (red.dominion.dominion >= blue.dominion.dominion)
        {
            attacker = red;
            defender = blue;
        }
        else
        {
            attacker = blue;
            defender = red;
        }
    }

    public void AttackerReady()
    {
        combatUI.phase.text = defender.name + " : choose your defense.";
        defender.SetDefender();
    }

    public void DefenderReady()
    {
        combatUI.phase.text = "The wheels of fate!";
        Resolve();
    }

    public void ResolutionReady()
    {
        resolutionUI.gameObject.SetActive(false);
        round++;
        if (round < attacker.activeLine.GetComponentsInChildren<Card>().Length)
            defender.SetDefender();
        EndTurn();
    }

    public void Resolve()
    {
        attacker.power = GetPower(attacker);
        defender.power = GetPower(defender);
        if (attacker.power > defender.power)
            attacker.isWinner = true;
        else
            defender.isWinner = false;
        resolutionUI.gameObject.SetActive(true);
        resolutionUI.drawResolution(red, red.activeLine.GetCard(round), blue, blue.activeLine.GetCard(round));
    }

    public void EndTurn()
    {
        if (!isEndGame())
            Start();
        else
            CombatOver();
    }

    public bool isEndGame()
    {
        return (false);
    }

    public void CombatOver()
    {
        Debug.Log("Combat over!");
    }

    public int GetPower(Pawn pawn)
    {
        Card card;
        int power = 0;

        card = pawn.activeLine.GetCard(round);

        power = 0;
        if (card)
            power += card.arcane;

        if (card)
        {
            pawn.dice = Random.Range(1, card.dice);
            power += pawn.dice;
        }

        if (pawn.isAttacker)
            power += pawn.attribute.ATK;
        else
            power += pawn.attribute.DEF;

        return (power);
    }
}
