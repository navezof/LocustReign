using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    public Pawn owner;

    void Start()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        foreach (Card card in cards)
            card.owner = owner;
    }

    public void DrawCards()
    {
        Debug.Log("Draw cards");
    }

    public void Activate(bool value)
    {
        Card[] cards = GetComponentsInChildren<Card>();
        foreach (Card card in cards)
            card.isDraggable = value;
    }
}
