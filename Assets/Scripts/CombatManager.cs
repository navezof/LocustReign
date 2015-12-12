using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour {

    public enum EPhase
    {
        Attacker,
        Defender,
        Resolution
    };

    public EPhase phase;

    public Pawn red;
    public Pawn blue;

    public Pawn attacker;
    public Pawn defender;

    public CombatUI combatUI;
    public ResolutionUI resolutionUI;

    public int turn;
    public int round;

    void Awake()
    {
        combatUI = GetComponent<CombatUI>();
        resolutionUI = GetComponent<ResolutionUI>();
    }

	void Start ()
    {
        attacker = red;
        defender = blue;

        StartTurn();
	}

    public void StartTurn()
    {
        round = 0;

        phase = EPhase.Attacker;
        attacker.SetAttacker(true);
    }

    public void SetRole()
    {
        Pawn swap;

        swap = attacker;
        attacker = defender;
        defender = swap;
    }

    public void Done()
    {
        if (phase == EPhase.Attacker)
        {
            AttackerDone();
        }
        else if (phase == EPhase.Defender)
        {
            DefenderDone();
        }
    }

    void AttackerDone()
    {
        attacker.SetAttacker(false);
        defender.SetDefender(true);
        phase = EPhase.Defender;
    }

    void DefenderDone()
    {
        defender.SetDefender(false);
        phase = EPhase.Resolution;
        resolutionUI.SetResolution(true);
        resolutionUI.SetValues(true);
        resolutionUI.Resolution(true);
    }

    public void ResolutionDone()
    {
        resolutionUI.SetResolution(false);
        resolutionUI.SetValues(false);
        resolutionUI.Resolution(false);
        EndRound();
    }

    public void EndRound()
    {
        attacker.ManaConsumption();
        if (IsGameOver())
        {
            Debug.Log("GameOver");
            return;
        }
        if (IsTurnOver())
        {
            turn++;
            attacker.Reset();
            defender.Reset();
            SetRole();
            StartTurn();
        }
        else
        {
            round++;
            defender.SetDefender(true);
            phase = EPhase.Defender;
        }
    }

    public bool IsGameOver()
    {
        if (attacker.HasMana())
            return (false);
        return (true);
    }

    public bool IsTurnOver()
    {
        if (round >= 1)
        {
            return (true);
        }
        return (false);
    }
}
