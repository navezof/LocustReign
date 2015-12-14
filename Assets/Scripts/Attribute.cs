using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Attribute : MonoBehaviour {

    public int ATK;
    public int DEF;

    public Text text_ATK;
    public Text text_DEF;

	void Update ()
    {
        text_ATK.text = "ATK : " + ATK.ToString();
        text_DEF.text = "DEF : " + DEF.ToString();
	}
}
