using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {

    public Card[] AGICards;
    public Card[] STRCards;
    public Card[] WITCards;

    public int mana;
    public int previsionMana;

    public IShard[] invokationShards;

	// Use this for initialization
	void Start () {
        invokationShards = GetComponents<IShard>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Invoke()
    {
        Debug.Log("Invokation : " + name);
        foreach (IShard invokationShard in invokationShards)
        {
            invokationShard.Execute();
        }
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
