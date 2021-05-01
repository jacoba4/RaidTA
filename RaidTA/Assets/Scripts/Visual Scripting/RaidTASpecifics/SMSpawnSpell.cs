using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMSpawnSpell : SMTwoInput
{
    public Encounter em;
    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("Encounter").GetComponent<Encounter>();
    }
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        int spell_id = (int)input_a.Output();
        Vector3 location = (Vector3)input_b.Output();

        em.CastSpell(spell_id, location);
        base.Execute();
    }
}
