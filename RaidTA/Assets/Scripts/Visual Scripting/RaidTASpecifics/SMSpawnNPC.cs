using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMSpawnNPC : SMTwoInput
{
    public Encounter em;
    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("Encounter").GetComponent<Encounter>();
    }
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        int unit_id = (int)input_a.Output();
        Vector3 location = (Vector3)input_b.Output();

        em.AddNewNPC(unit_id, location);
        base.Execute();
    }
}
