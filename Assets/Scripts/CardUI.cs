using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardUI : MonoBehaviour
{
    Card card;

    public Text text_name;
    public Text text_arcane;
    public Text text_hidden;

    void Awake()
    {
        card = GetComponent<Card>();
    }

    void Start()
    {
        text_name.text = name;
        text_arcane.text = card.arcane.ToString();
    }

    public void Show(bool value)
    {
        text_name.gameObject.SetActive(value);
        text_arcane.gameObject.SetActive(value);
        text_hidden.gameObject.SetActive(!value);
    }
}
