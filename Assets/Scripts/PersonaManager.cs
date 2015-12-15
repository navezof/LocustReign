using UnityEngine;
using System.Collections;

public class PersonaManager : MonoBehaviour {
    Pawn owner;

    public Persona[] personas;
    public int cPersona;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }

    public void ActivatePersona()
    {
        for (int i = 0; i < personas.Length; i++)
        {
            if (i != cPersona)
            {
                personas[i].gameObject.SetActive(false);
            }
            else
            {
                personas[i].gameObject.SetActive(true);
            }
        }
    }

    public void Conjure(int index)
    {
        cPersona = index;
        personas[cPersona].Conjure();
        owner.mana = personas[cPersona].GetMana();
    }

    public Persona GetPersona()
    {
        return (personas[cPersona]);
    }
}
