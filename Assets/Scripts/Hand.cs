using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    Pawn owner;

    public GameObject handUI;

    public int handMaxSize;
    public int handSize;
    public int drawSize;

    public bool isPersonaHand;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }

    public void DrawHand(Deck deck)
    {
        handSize = handUI.GetComponentsInChildren<Card>().Length;
        for (int i = 0; i < drawSize; i++)
        {
            if (handSize >= handMaxSize)
                return;
            if (isPersonaHand)
                PutPersonaCardInSlot();
            else
                PutCardInSlot(deck);
        }
    }

    void PutPersonaCardInSlot()
    {
        for (int slotIndex = 0; slotIndex < owner.persona.personaCardsTemplate.Length; slotIndex++)
        {
            if (handUI.transform.GetChild(slotIndex).childCount == 0)
            {
                GameObject newPersona = Instantiate(owner.persona.personaCardsTemplate[slotIndex].gameObject, transform.position, Quaternion.identity) as GameObject;
                newPersona.transform.SetParent(handUI.transform.GetChild(slotIndex));
            }
        }
    }

    void PutCardInSlot(Deck deck)
    {
        Card newCard = deck.DrawCard();
        if (newCard != null)
        {
            handSize++;
            for (int slotIndex = 0; slotIndex < handUI.transform.childCount; slotIndex++)
            {
                if (handUI.transform.GetChild(slotIndex).childCount == 0)
                    newCard.transform.SetParent(handUI.transform.GetChild(slotIndex));
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

    public int GetHandSize()
    {
        return (handUI.GetComponentsInChildren<Card>().Length);
    }
}
