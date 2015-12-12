using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PawnUI : MonoBehaviour {

    Pawn owner;

    public Text text_name;
    public Text text_persona;

    public Text text_AGI;
    public Text text_STR;
    public Text text_WIT;

    public Text text_mana;

    void Awake()
    {
        owner = GetComponent<Pawn>();        
    }

	// Use this for initialization
	void Start () {
        SetText();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text_mana.text = "Mana : " + owner.GetPersona().mana.ToString() + "(" + owner.GetPersona().previsionMana.ToString() + ")";

        text_AGI.text = "AGI : " + owner.AGI.ToString();
        text_STR.text = "STR : " + owner.STR.ToString();
        text_WIT.text = "WIT : " + owner.WIT.ToString();
	}

    void SetText()
    {
        text_name.text = name;
        text_persona.text = owner.GetPersona().name;
    }
}
