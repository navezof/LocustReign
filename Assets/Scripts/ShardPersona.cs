using UnityEngine;
using System.Collections;

public class ShardPersona : IShard {
    
    public string personaName;

    public override void Execute(Pawn caster, Pawn target)
    {
        caster.persona.Conjure(personaName);
    }
}
