using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {
    public Card[] deck;

    Mana mana;
    public Mana GetMana() { return (mana); }

    void Awake()
    {
        mana = GetComponent<Mana>();
    }

    public void Conjure()
    {
        Debug.Log(name + " is conjured!");
    }
    
}
