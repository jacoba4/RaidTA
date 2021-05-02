using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMSpawnSpell : SMTwoInput
{
    Encounter em;
    private void Start()
    {
        
    }
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        int spell_id = (int)input_a.Output();
        Vector3 location = (Vector3)input_b.Output();
        if(!em)
        {
            em = GameObject.FindGameObjectWithTag("Encounter").GetComponent<Encounter>();
        }

        if(em)
        {
            em.CastSpell(spell_id, location);
            base.Execute();
        }        
    }
}
