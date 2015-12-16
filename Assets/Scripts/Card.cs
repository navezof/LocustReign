using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public Pawn owner;

    public enum EType
    {
        ACTIVE,
        PASSIVE
    };

    public EType type;

    public int arcane;
    public int dice;
    public int dominion;
    public int cost;
    public int health;

    public IShard[] shards;

    public bool isDraggable;

    public void Remove()
    {
        DestroyImmediate(gameObject);
    }
}
