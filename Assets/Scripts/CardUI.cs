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

        button_done.onClick.AddListener(() => { ClickDone(); });
    }

    public void SetAttackerMode(bool value)
    {
        
        showRoundA(value);
        showRoundB(value);

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
        owner.selectedCards[round] = owner.GetPersona().GetCard(round, attribute);
        owner.selectedAttribute[round] = attribute;

        text_round[round].text = owner.selectedCards[round].name;
    }

    public void ClickDone()
    {
        owner.SetDone(true);
    }
}
