using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Info : MonoBehaviour {
    Pawn owner;

    public Text text_name;
    public Text text_persona;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }

	void Start ()
    {
        text_name.text = name;
	}
	
	void Update ()
    {
        text_persona.text = owner.persona.GetPersona().name;
	}
}
