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
    public EPhase phase;

    public Pawn player;
    public Pawn locust;

    Pawn attacker;
    Pawn defender;

    CombatUI combatUI;
    ResolutionUI resolutionUI;

    public int turn;
    public int round;

    public void Awake()
    {
        combatUI = GetComponent<CombatUI>();
        resolutionUI = GetComponent<ResolutionUI>();
    }

    public void Start()
    {
        player.hand.Show(false);
        locust.hand.Show(false);
        player.line.Show(false);
        locust.line.Show(false);
        resolutionUI.Show(false);

        player.persona.Conjure(0);
        locust.persona.Conjure(0);

        StartTurn();
    }

    void StartTurn()
    {
        turn++;

        player.mana.RecoverMana();
        locust.mana.RecoverMana();

        SetRole();
        defender.hand.Show(false);
        defender.line.Show(false);
        AttackerPhase();
    }

    void SetRole()
    {
        if (player.dominion.dominion >= locust.dominion.dominion)
        {
            attacker = player;
            defender = locust;
        }
        else
        {
            attacker = locust;
            defender = player;
        }
        attacker.isAttacker = true;
        defender.isAttacker = false;
    }

    void AttackerPhase()
    {
        phase = EPhase.ATTACKER;

        attacker.hand.Show(true);
        attacker.line.Show(true);
        attacker.hand.EnableInteraction(true);
        attacker.line.EnableInteraction(true);
    }

    public void EndAttackerPhase()
    {
        attacker.line.ValidateLine();
        attacker.hand.EnableInteraction(false);
        if (attacker != player)
        {
            attacker.hand.Show(false);
            attacker.line.ShowCards(false);
            attacker.line.ShowFirstCard(true);
        }
        DefenderPhase();
    }

    void DefenderPhase()
    {
        phase = EPhase.DEFENDER;

        defender.hand.Show(true);
        defender.line.ShowFirstSlot();
        defender.hand.EnableInteraction(true);
        defender.line.EnableInteraction(true);
    }

    public void EndDefenderPhase()
    {
        defender.line.ValidateLine();
        defender.line.EnableInteraction(false);
        defender.hand.EnableInteraction(false);
        if (defender != player)
            defender.hand.Show(false);
        ResolutionPhase();
    }

    void ResolutionPhase()
    {
        phase = EPhase.RESOLUTION;

        if (GetPower(attacker) > GetPower(defender))
        {
            Win(attacker, defender);
            Lose(defender);
        }
        else
        {
            Win(defender, attacker);
            Lose(attacker);
        }
        resolutionUI.Show(true);
        resolutionUI.SetText(player, player.line.GetFirstCard(), locust, locust.line.GetFirstCard());
    }

    void Win(Pawn winner, Pawn loser)
    {
        winner.isWinner = true;
        winner.dominion.addDominion(winner.line.GetFirstCard().dominion);
        winner.line.GetFirstCard().Execute(winner, loser);
    }

    void Lose(Pawn pawn)
    {
        pawn.isWinner = false;
        pawn.line.GetFirstCard().Break(1);
    }

    public void EndResolution()
    {
        attacker.line.RemoveFirstCard();
        defender.line.RemoveFirstCard();
        resolutionUI.Show(false);
        if (IsEndGame())
        {
            CombatOver();
        }
        else if (IsEndTurn())
        {
            StartTurn();
        }
        else
        {
            DefenderPhase();
        }
    }

    public void EndPhase()
    {
        switch (phase)
        {
            case (EPhase.ATTACKER):
                EndAttackerPhase();
                break;
            case (EPhase.DEFENDER):
                EndDefenderPhase();
                break;
            case (EPhase.RESOLUTION):
                EndResolution();
                break;
            default:
                return;
        }
    }

    public bool IsEndTurn()
    {
        if (attacker.line.cards.Length <= 0)
            return (true);
        return (false);
    }

    public bool IsEndGame()
    {
        return (false);
    }

    public void CombatOver()
    {
        Debug.Log("Combat over!");
    }

    public int GetPower(Pawn pawn)
    {
        int power = 0;

        if (pawn.line.GetFirstCard() != null)
        {
            power += pawn.line.GetFirstCard().arcane;
            pawn.dice = Random.Range(1, pawn.line.GetFirstCard().dice);
            power += pawn.dice;
        }
        if (pawn.isAttacker)
            power += pawn.attribute.ATK + pawn.dominion.dominion;
        else
            power += pawn.attribute.DEF;
        pawn.power = power;
        return (power);
    }
}
