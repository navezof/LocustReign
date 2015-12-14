using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dominion : MonoBehaviour {
    public int dominion;
    public Text text_dominion;

    void Update()
    {
        text_dominion.text = "Dominion : " + dominion.ToString();
    }

    public void addDominion(int value)
    {
        dominion += value;
    }

    public void removeDominion(int value)
    {
        dominion -= value;
        if (dominion < 0)
        {
            dominion = 0;
        }
    }
}
