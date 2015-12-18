using UnityEngine;
using System.Collections;

public class PersonaManager : MonoBehaviour {
    Pawn owner;

    public GameObject[] personaCardsTemplate;
    public Persona[] personas;
    public int cPersona;

    public GameObject personaUI;

    bool handActive = false;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }

    public void ActivatePersona()
    {
        for (int i = 0; i < personas.Length; i++)
        {
            if (i != cPersona)
                personas[i].gameObject.SetActive(false);
            else
                personas[i].gameObject.SetActive(true);
        }
    }

    public void Conjure(int index)
    {
        cPersona = index;
        personas[cPersona].Conjure();
        owner.mana = personas[cPersona].GetMana();
    }

    public void Conjure(string personaName)
    {
        for (int i = 0; i < personas.Length; i++ )
        {
            if (personas[i].name == personaName)
                cPersona = i;
        }

        personas[cPersona].Conjure();
        if (personas[cPersona] == null)
            Debug.Log("A");
        if (personas[cPersona].GetMana() == null)
            Debug.Log("B");
        Debug.Log("make mana go : " + personas[cPersona].GetMana().mana);
        owner.mana.mana = personas[cPersona].GetMana().mana;
    }

    public void Show()
    {
        handActive = !handActive;
        personaUI.gameObject.SetActive(handActive);
    }

    public Persona GetPersona()
    {
        return (personas[cPersona]);
    }

    public void OnClickPersonaChange()
    {
        if (owner.hasHand)
            Show();
    }
}
