using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionUI : MonoBehaviour {

    CombatManager combat;

    public Text text_redName;
    public Text text_redArcane;
    public Text text_redAttribute;
    public Text text_redDice;
    public Text text_redPower;

    public Text text_blueName;
    public Text text_blueArcane;
    public Text text_blueAttribute;
    public Text text_blueDice;
    public Text text_bluePower;

    public Text text_result;

    public Button button_resolutionDone;

    void Start()
    {
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();
    }

    public void drawResolution(Pawn red, Card redCard, Pawn blue, Card blueCard)
    {
        text_redName.text = redCard.name;
        text_redArcane.text = "Arc : " + redCard.arcane.ToString();
        if (red.isAttacker)
            text_redAttribute.text = "ATK : " + red.attribute.ATK.ToString();
        else
            text_redAttribute.text = "DEF : " + red.attribute.DEF.ToString();
        text_redDice.text = "Dice : " + red.dice.ToString();
        text_redPower.text = "Power : " + red.power.ToString();

        text_blueName.text = blueCard.name;
        text_blueArcane.text = "Arc : " + blueCard.arcane.ToString();
        if (blue.isAttacker)
            text_blueAttribute.text = "ATK : " + blue.attribute.ATK.ToString();
        else
            text_blueAttribute.text = "DEF : " + blue.attribute.DEF.ToString();
        text_blueDice.text = "Dice : " + blue.dice.ToString();
        text_bluePower.text = "Power : " + blue.power.ToString();

        if (red.isWinner)
            text_result.text = red.name + " won!";
        else
            text_result.text = blue.name + " won!";
    }

    public void OnResolutionDoneClick()
    {
        combat.ResolutionReady();
    }
}
