using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {
    public Deck deck;

    Mana mana;
    public Mana GetMana() { return (mana); }

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
