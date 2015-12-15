using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionUI : MonoBehaviour {

    CombatManager combat;
    public GameObject ui;

    public Text text_playerName;
    public Text text_playerArcane;
    public Text text_playerAttribute;
    public Text text_playerDice;
    public Text text_playerPower;

    public Text text_locustName;
    public Text text_locustArcane;
    public Text text_locustAttribute;
    public Text text_locustDice;
    public Text text_locustPower;

    public Text text_result;

    void Start()
    {
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();
    }

    public void Show(bool value)
    {
        ui.SetActive(value);
    }

    public void SetText(Pawn player, Card playerCard, Pawn locust, Card locustCard)
    {
        text_playerName.text = playerCard.name;
        text_playerArcane.text = "Arc : " + playerCard.arcane.ToString();
        if (player.isAttacker)
            text_playerAttribute.text = "ATK : " + player.attribute.ATK.ToString();
        else
            text_playerAttribute.text = "DEF : " + player.attribute.DEF.ToString();
        text_playerDice.text = "Dice : " + player.dice.ToString();
        text_playerPower.text = "Power : " + player.power.ToString();

        text_locustName.text = locustCard.name;
        text_locustArcane.text = "Arc : " + locustCard.arcane.ToString();
        if (locust.isAttacker)
            text_locustAttribute.text = "ATK : " + locust.attribute.ATK.ToString();
        else
            text_locustAttribute.text = "DEF : " + locust.attribute.DEF.ToString();
        text_locustDice.text = "Dice : " + locust.dice.ToString();
        text_locustPower.text = "Power : " + locust.power.ToString();

        if (player.isWinner)
            text_result.text = player.name + " won!";
        else
            text_result.text = locust.name + " won!";
    }
}
