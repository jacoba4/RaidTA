using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMSpawnNPC : SMTwoInput
{
    
    private void Start()
    {
        
    }
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        int unit_id = (int)input_a.Output();
        Vector3 location = (Vector3)input_b.Output();

        Encounter em = GameObject.FindGameObjectWithTag("Encounter").GetComponent<Encounter>();
        em.AddNewNPC(unit_id, location);
        base.Execute();
    }
}
