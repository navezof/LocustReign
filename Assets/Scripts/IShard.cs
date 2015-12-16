using UnityEngine;
using System.Collections;

public abstract class IShard : MonoBehaviour {

    abstract public void Execute(Pawn caster, Pawn target);
}
