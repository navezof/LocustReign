using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    public enum EAttribute
    {
        AGI,
        STR,
        WIT
    };

    public EAttribute attribute;
    public int sync;
    public int cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
