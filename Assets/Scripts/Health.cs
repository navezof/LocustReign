using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    Pawn owner;

    public int health;
    public Text text_health;

    void Awake()
    {
        owner = GetComponent<Pawn>();
    }
	
	void Update () {
        text_health.text = "Health : " + health.ToString();	
	}

    public void TakeDamage(int damage)
    {
        health -= damage + owner.dominion.dominion;
        Debug.Log(name + ": took " + (damage + owner.dominion.dominion) + " damage (" + damage + " + " + owner.dominion.dominion + ")");
        if (health <= 0)
            owner.Die();
    }

    public void HealDamage(int heal)
    {
        health += heal;
    }
}
