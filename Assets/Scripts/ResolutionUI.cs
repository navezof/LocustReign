using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionUI : MonoBehaviour {

    CombatManager combat;

    public Text text_redCard;
    public Text text_redValue;

    public Text text_blueCard;
    public Text text_blueValue;

    public Text text_resolution;

    public Button button_done;

    public int redPower;
    public int bluePower;

    void Awake()
    {
        combat = GetComponent<CombatManager>();
        SetResolution(false);
        SetValues(false);
    }

    void Start()
    {
        SetListeners();
    }

    void SetListeners()
    {
        button_done.onClick.AddListener(() => { ClickDone(); });
    }

    public void SetResolution(bool value)
    {
        text_redCard.gameObject.SetActive(value);
        text_blueCard.gameObject.SetActive(value);

        if (value)
        {
            if (combat.red.selectedCards[combat.round] != null)
                text_redCard.text = combat.red.selectedCards[combat.round].name;
            else
                text_redCard.text = combat.red.name + " do nothing this round.";
            if (combat.blue.selectedCards[combat.round] != null)
                text_blueCard.text = combat.blue.selectedCards[combat.round].name;
            else
                text_blueCard.text = combat.blue.name + " do nothing this round.";
        }

        button_done.gameObject.SetActive(value);
        text_resolution.gameObject.SetActive(value);
    }

    public void SetValues(bool value)
    {
        text_redValue.gameObject.SetActive(value);
        text_blueValue.gameObject.SetActive(value);

        if (value)
        {
            if (combat.red.selectedCards[combat.round] != null)
                redPower = combat.red.GetCardValue(combat.round);
            else
                redPower = 0;
            if (combat.blue.selectedCards[combat.round] != null)
                bluePower = combat.blue.GetCardValue(combat.round);
            else
                bluePower = 0;

            text_redValue.text = "Card Power : " + redPower;
            text_blueValue.text = "Card Power : " + bluePower;
        }
    }

    public void Resolution(bool value)
    {
        text_resolution.gameObject.SetActive(value);
        button_done.gameObject.SetActive(value);

        if (value)
        {
            if (redPower > bluePower)
            {
                text_resolution.text = combat.red.name + " won the contest!";
                combat.red.IsWinner(true);
            }
            else if (bluePower > redPower)
            {
                text_resolution.text = combat.blue.name + " won the contest!";
                combat.blue.IsWinner(true);
            }
            else
            {
                text_resolution.text = "It is a draw!";
            }
        }
    }

    void ShowResolution(bool value)
    {
        button_done.gameObject.SetActive(value);
    }
    
    void ClickDone()
    {
        combat.ResolutionDone();
    }
}
