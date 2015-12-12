using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardUI : MonoBehaviour
{
    CombatManager combat;
    Pawn owner;

    public Text[] text_round;

    public Button button_ARoundAGI;
    public Button button_ARoundSTR;
    public Button button_ARoundWIT;

    public Button button_BRoundAGI;
    public Button button_BRoundSTR;
    public Button button_BRoundWIT;

    public Button button_CRoundAGI;
    public Button button_CRoundSTR;
    public Button button_CRoundWIT;

    public Button button_DRoundAGI;
    public Button button_DRoundSTR;
    public Button button_DRoundWIT;

    public Button button_done;

    void Awake()
    {
        owner = GetComponent<Pawn>();
        SetAttackerMode(false);
    }

    void Start()
    {
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();

        SetListeners();
    }

    void SetListeners()
    {
        button_ARoundAGI.onClick.AddListener(() => { ClickRound(0, Card.EAttribute.AGI); });
        button_ARoundSTR.onClick.AddListener(() => { ClickRound(0, Card.EAttribute.STR); });
        button_ARoundWIT.onClick.AddListener(() => { ClickRound(0, Card.EAttribute.WIT); });

        button_BRoundAGI.onClick.AddListener(() => { ClickRound(1, Card.EAttribute.AGI); });
        button_BRoundSTR.onClick.AddListener(() => { ClickRound(1, Card.EAttribute.STR); });
        button_BRoundWIT.onClick.AddListener(() => { ClickRound(1, Card.EAttribute.WIT); });

        button_CRoundAGI.onClick.AddListener(() => { ClickRound(2, Card.EAttribute.AGI); });
        button_CRoundSTR.onClick.AddListener(() => { ClickRound(2, Card.EAttribute.STR); });
        button_CRoundWIT.onClick.AddListener(() => { ClickRound(2, Card.EAttribute.WIT); });

        button_DRoundAGI.onClick.AddListener(() => { ClickRound(3, Card.EAttribute.AGI); });
        button_DRoundSTR.onClick.AddListener(() => { ClickRound(3, Card.EAttribute.STR); });
        button_DRoundWIT.onClick.AddListener(() => { ClickRound(3, Card.EAttribute.WIT); });

        button_done.onClick.AddListener(() => { ClickDone(); });
    }

    void SetCardsName()
    {
        button_ARoundAGI.GetComponentInChildren<Text>().text = owner.GetPersona().AGICards[0].GetText();
        button_BRoundAGI.GetComponentInChildren<Text>().text = owner.GetPersona().AGICards[1].GetText();
        button_CRoundAGI.GetComponentInChildren<Text>().text = owner.GetPersona().AGICards[2].GetText();
        button_DRoundAGI.GetComponentInChildren<Text>().text = owner.GetPersona().AGICards[3].GetText();

        button_ARoundSTR.GetComponentInChildren<Text>().text = owner.GetPersona().STRCards[0].GetText();
        button_BRoundSTR.GetComponentInChildren<Text>().text = owner.GetPersona().STRCards[1].GetText();
        button_CRoundSTR.GetComponentInChildren<Text>().text = owner.GetPersona().STRCards[2].GetText();
        button_DRoundSTR.GetComponentInChildren<Text>().text = owner.GetPersona().STRCards[3].GetText();

        button_ARoundWIT.GetComponentInChildren<Text>().text = owner.GetPersona().WITCards[0].GetText();
        button_BRoundWIT.GetComponentInChildren<Text>().text = owner.GetPersona().WITCards[1].GetText();
        button_CRoundWIT.GetComponentInChildren<Text>().text = owner.GetPersona().WITCards[2].GetText();
        button_DRoundWIT.GetComponentInChildren<Text>().text = owner.GetPersona().WITCards[3].GetText();
    }

    public void SetAttackerMode(bool value)
    {
        ShowAllRound(value);
        //SetCardsName();

        button_done.gameObject.SetActive(value);

        foreach (Text text in text_round)
        {
            text.gameObject.SetActive(value);
        }
    }

    public void SetDefenderMode(bool value, int round)
    {
        switch (round)
        {
            case 0 :
                showRoundA(value);
                break;
            case 1:
                showRoundB(value);
                break;
            default:
                break;
        }
        button_done.gameObject.SetActive(value);
        text_round[round].gameObject.SetActive(value);
    }

    void ShowAllRound(bool value)
    {
        showRoundA(value);
        showRoundB(value);
        showRoundC(value);
        showRoundD(value);
    }

    void showRoundA(bool value)
    {
        button_ARoundAGI.gameObject.SetActive(value);
        button_ARoundSTR.gameObject.SetActive(value);
        button_ARoundWIT.gameObject.SetActive(value);
    }

    void showRoundB(bool value)
    {
        button_BRoundAGI.gameObject.SetActive(value);
        button_BRoundSTR.gameObject.SetActive(value);
        button_BRoundWIT.gameObject.SetActive(value);
    }

    void showRoundC(bool value)
    {
        button_CRoundAGI.gameObject.SetActive(value);
        button_CRoundSTR.gameObject.SetActive(value);
        button_CRoundWIT.gameObject.SetActive(value);
    }

    void showRoundD(bool value)
    {
        button_DRoundAGI.gameObject.SetActive(value);
        button_DRoundSTR.gameObject.SetActive(value);
        button_DRoundWIT.gameObject.SetActive(value);
    }

    public void Reset()
    {
        foreach (Text text in text_round)
        {
            text.text = "";
        }
        ShowAllRound(false);
    }

    public void ClickRound(int round, Card.EAttribute attribute)
    {
        Card card = owner.GetPersona().GetCard(round, attribute);
        if (owner.CanUseCard(card))
        {
            owner.selectedCards[round] = owner.GetPersona().GetCard(round, attribute);
            owner.GetPersona().previsionMana += owner.selectedCards[round].cost;
            owner.selectedAttribute[round] = attribute;
            text_round[round].text = owner.selectedCards[round].name;
        }
        else
        {
            Debug.Log("Not enough mana");
        }
    }

    public void ClickDone()
    {
        owner.SetDone(true);
    }
}
