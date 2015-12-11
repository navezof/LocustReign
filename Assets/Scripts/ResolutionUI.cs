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
            text_redCard.text = combat.red.selectedCards[combat.round].name;
            text_blueCard.text = combat.blue.selectedCards[combat.round].name;
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
            text_redValue.text = "Card power : " + combat.red.GetCardValue(combat.round).ToString();
            text_blueValue.text = "Card power : " + combat.blue.GetCardValue(combat.round).ToString();
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
