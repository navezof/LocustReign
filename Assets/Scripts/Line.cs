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

    public void EmptyRound(int value)
    {
        Card[] cards = GetComponentsInChildren<Card>();
        if (cards[value])
            cards[value].Remove();
    }

    public Card GetCard(int value)
    {
        Debug.Log(owner.name + ": Getcard:" + value);
        Card[] cards = GetComponentsInChildren<Card>();
        if (cards.Length > 0)
            return (cards[value]);
        return (null);
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
