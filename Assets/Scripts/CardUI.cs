using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardUI : MonoBehaviour
{
    Card card;

    public Text text_name;
    public Text text_arcane;

    void Awake()
    {
        card = GetComponent<Card>();
    }

    void Start()
    {
        text_name.text = name;
        text_arcane.text = card.arcane.ToString();


    }
}
