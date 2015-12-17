using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    Pawn owner;

    public GameObject handUI;

    public int handSize;

    void Awake()
    {
        owner = GetComponent<Pawn>();
        //foreach (Card card in handUI.GetComponentsInChildren<Card>())
        //    card.owner = owner;
    }

    void Start()
    {
    }

    public void DrawHand()
    {
        for (int i = 0; i < handSize; i++)
        {
            Card newCard = owner.persona.GetPersona().deck.DrawCard();
            if (newCard != null)
            {
                newCard.transform.SetParent(handUI.transform.GetChild(i));
            }
        }
    }

    public void Show(bool value)
    {
        handUI.SetActive(value);
        foreach (Card card in handUI.GetComponentsInChildren<Card>())
            card.ui.Show(value);
    }

    public void EnableInteraction(bool value)
    {
        foreach (Card card in handUI.GetComponentsInChildren<Card>())
            card.isDraggable = value;
    }
}
