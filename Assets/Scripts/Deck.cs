using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
    private Pawn owner;

    public List<Card> cards;
    public GameObject cemetary;

    void Start()
    {
        owner = GetComponentInParent<Pawn>();
        foreach (Card card in GetComponentsInChildren<Card>())
        {
            card.owner = owner;
            card.deck = this;
            cards.Add(card);
        }
    }

    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            Card cardToDraw = cards[0];
            cards.Remove(cardToDraw);
            return (cardToDraw);
        }
        return (null);
    }

    public void DiscardCard(Card cardToDiscard)
    {
        cardToDiscard.transform.SetParent(cemetary.transform);
        cardToDiscard.gameObject.SetActive(false);
    }
}
