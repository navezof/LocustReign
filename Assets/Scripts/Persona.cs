using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {
    private Deck deck;
    public Deck GetDeck() 
    {
        if (deck == null)
            deck = GetComponent<Deck>();
        return (deck); 
    }

    Mana mana;
    public Mana GetMana()
    { 
        if (mana == null)
            mana = GetComponent<Mana>();
        return (mana);
    }

    void Awake()
    {
        mana = GetComponent<Mana>();
        deck = GetComponent<Deck>();
    }

    public void Conjure()
    {
        Debug.Log(name + " is conjured!");
    }
    
}
