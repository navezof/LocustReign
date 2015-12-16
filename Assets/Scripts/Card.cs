﻿using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public Pawn owner;
    public CardUI ui;

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

    public bool isBroken;

    public IShard[] shards;

    public bool isDraggable;

    void Awake()
    {
        ui = GetComponent<CardUI>();
    }

    public void Execute(Pawn caster, Pawn target)
    {
        foreach (IShard shard in shards)
            shard.Execute(caster, target);
    }

    public void Remove()
    {
        DestroyImmediate(gameObject);
    }

    public void Break(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isBroken = true;
        }
    }
}
