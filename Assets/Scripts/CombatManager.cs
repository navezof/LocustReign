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

    public int turn;
    public int round;

    public void Awake()
    {
        combatUI = GetComponent<CombatUI>();
        resolutionUI.gameObject.SetActive(false);
    }

    public void Start()
    {
        round = 0;
        SetRole();
        combatUI.phase.text = "Turn " + turn + " - " + attacker.name + " : choose your attacks.";
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
        combatUI.phase.text = "Round " + round + " - The wheels of fate!";
        Resolve();
    }

    public void ResolutionReady()
    {
        resolutionUI.gameObject.SetActive(false);
        defender.activeLine.EmptyLine();
        attacker.activeLine.EmptyRound(round);
        round++;
        if (round < attacker.activeLine.GetComponentsInChildren<Card>().Length)
        {
            defender.SetDefender();
        }
        else
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
        if (red.isAttacker)
            resolutionUI.drawResolution(red, red.activeLine.GetCard(round), blue, blue.activeLine.GetCard(0));
        else
            resolutionUI.drawResolution(red, red.activeLine.GetCard(0), blue, blue.activeLine.GetCard(round));
    }

    public void EndTurn()
    {
        attacker.activeLine.EmptyLine();
        defender.activeLine.EmptyLine();
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

        if (pawn.isAttacker)
        {
            card = pawn.activeLine.GetCard(round);
            power += pawn.attribute.ATK;
        }
        else
        {
            card = pawn.activeLine.GetCard(0);
            power += pawn.attribute.DEF;
        }
        if (card)
        {
            power += card.arcane;
            pawn.dice = Random.Range(1, card.dice);
            power += pawn.dice;
        }

        return (power);
    }
}
