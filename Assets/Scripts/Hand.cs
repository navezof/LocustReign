using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    Pawn owner;

    public GameObject handUI;

    void Awake()
    {
        owner = GetComponent<Pawn>();
        foreach (Card card in handUI.GetComponentsInChildren<Card>())
            card.owner = owner;
    }

    void Start()
    {
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
