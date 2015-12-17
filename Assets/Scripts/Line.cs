using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Line : MonoBehaviour {
    Pawn owner;
    public Pawn GetOwner() { return (owner); }

    public GameObject lineUI;

    public Card.EType type;

    public Card[] cards;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }

    void Start()
    {
        foreach (Transform slot in lineUI.transform)
            slot.GetComponent<Slot>().line = this;
    }

    public void Show(bool value)
    {
        lineUI.SetActive(value);
        foreach (Transform slot in lineUI.transform)
            slot.gameObject.SetActive(value);
    }

    public void ShowCards(bool value)
    {
        foreach (Card card in cards)
            card.ui.Show(value);
    }

    public void ShowFirstCard(bool value)
    {
        if (cards.Length <= 0)
            return;
        cards[0].ui.Show(value);
    }

    public void ShowFirstSlot()
    {
        lineUI.SetActive(true);
        foreach (Transform slot in lineUI.transform)
        {
            if (slot.GetComponent<Slot>().slotIndex != 0)
                slot.gameObject.SetActive(false);
            else
                slot.gameObject.SetActive(true);
        }
    }

    public void ValidateLine()
    {
        cards = lineUI.GetComponentsInChildren<Card>();
    }

    public void EnableInteraction(bool value)
    {
        foreach (Card card in lineUI.GetComponentsInChildren<Card>())
            card.isDraggable = value;
    }

    public void RemoveFirstCard()
    {
        if (cards == null || cards.Length <= 0)
            return ;
        cards[0].Remove();
        cards = lineUI.GetComponentsInChildren<Card>();
    }

    public Card GetFirstCard()
    {
        if (cards == null || cards.Length <= 0)
            return null;
        return (cards[0]);
    }
}
