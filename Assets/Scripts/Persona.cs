using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {

    public Card[] AGICards;
    public Card[] STRCards;
    public Card[] WITCards;

    public int mana;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Card GetCard(int round, Card.EAttribute attribute)
    {
        switch (attribute)
        {
            case Card.EAttribute.AGI:
                return (AGICards[round]);
            case Card.EAttribute.STR:
                return (STRCards[round]);
            case Card.EAttribute.WIT:
                return (WITCards[round]);
            default:
                return (null);
        }
    }
}
