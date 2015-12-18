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

    ResolutionUI resolutionUI;
    PhaseTimer phaseTimer;

    public int turn;
    public int round;

    public void Awake()
    {
        resolutionUI = GetComponent<ResolutionUI>();
        phaseTimer = GetComponent<PhaseTimer>();
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

        player.hand.DrawHand(player.persona.GetPersona().GetDeck());
        player.personaHand.DrawHand(null);
        locust.hand.DrawHand(locust.persona.GetPersona().GetDeck());
        locust.personaHand.DrawHand(null);

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
        attacker.hasHand = true;

        attacker.hand.Show(true);
        attacker.line.Show(true);
        attacker.hand.EnableInteraction(true);
        attacker.line.EnableInteraction(true);
    }

    public void EndAttackerPhase()
    {
        attacker.hasHand = false;
        attacker.personaHand.Show(false);
        attacker.line.ValidateLine();
        attacker.hand.EnableInteraction(false);
        if (attacker != player)
        {
            attacker.hand.Show(false);
            attacker.line.ShowCards(false);
        }
        DefenderPhase();
    }

    void DefenderPhase()
    {
        phase = EPhase.DEFENDER;
        defender.hasHand = true;
        phaseTimer.StartTimer();

        defender.hand.Show(true);
        defender.line.ShowFirstSlot();
        attacker.line.ShowFirstCard(true);

        defender.hand.EnableInteraction(true);
        defender.line.EnableInteraction(true);
    }

    public void EndDefenderPhase()
    {
        phaseTimer.StopTimer();
        defender.hasHand = false;
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

        int attackerPower = GetPower(attacker);
        int defenderPower = GetPower(defender);
        if (attackerPower > defenderPower)
        {
            Win(attacker, defender);
            Lose(defender);
        }
        else if (attackerPower < defenderPower)
        {
            Win(defender, attacker);
            Lose(attacker);
        }
        else
        {
            Draw(attacker, defender);
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
        if (pawn.line.GetFirstCard() != null)
            pawn.line.GetFirstCard().Break(1);
    }

    void Draw(Pawn attacker, Pawn defender)
    {
        attacker.isWinner = false;
        defender.isWinner = false;
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
        if (player.health.IsDead())
        {
            Debug.Log("GAME OVER");
        }
        else if (locust.health.IsDead())
        {
            Debug.Log("Player win!");
        }
    }

    public int GetPower(Pawn pawn)
    {
        int power = 0;

        if (pawn.line.GetFirstCard() == null)
            return (0);

        power += pawn.line.GetFirstCard().arcane;
        pawn.dice = Random.Range(1, pawn.line.GetFirstCard().dice);
        power += pawn.dice;

        if (pawn.isAttacker)
            power += pawn.attribute.ATK + pawn.dominion.dominion;
        else
            power += pawn.attribute.DEF;
        pawn.power = power;
        return (power);
    }

    void ExitCombat()
    {
        player.CloseCombatUI();
        locust.CloseCombatUI();
    }
}
