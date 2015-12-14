using UnityEngine;
using System.Collections;

public class PersonaManager : MonoBehaviour {

    public Persona[] personas;
    public int cPersona;

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

    public Persona GetPersona()
    {
        return (personas[cPersona]);
    }
}
