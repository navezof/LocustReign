using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
    public Pawn owner;

    public Card.EType type; 

    public Card GetCard(int value)
    {
        Card[] cards = GetComponentsInChildren<Card>();
        return cards[value];
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
