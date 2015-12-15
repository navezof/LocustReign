using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
    CombatManager combat;

    public Pawn owner;

    public Card.EType type; 

    void Awake()
    {
        combat = GameObject.Find("Combat").GetComponent<CombatManager>();
    }

    public void EmptyLine()
    {
        foreach (Card card in GetComponentsInChildren<Card>())
        {
            if (card != null)
                card.Remove();
        }
    }

    public void EmptyRound()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        cards[0].Remove();
    }

    public Card GetCurrentCard()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        return (cards[0]);
    }

    public void ActivateAttackMode(bool value)
    {
        gameObject.SetActive(value);
        foreach (Transform slot in transform)
            slot.gameObject.SetActive(value);
    }

    public void ActivateDefenseMode(bool value)
    {
        gameObject.SetActive(value);
        foreach (Transform slot in transform)
        {
            if (slot.GetComponent<Slot>().slotIndex != 0)
                slot.gameObject.SetActive(value);
        }
    }
}
