using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMDamageRaid : SMOneInput
{
    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        RaidManager rm = GameObject.Find("RaidManager").GetComponent<RaidManager>();
        if (rm)
        {
            rm.DamageRaid((int)input_a.Output());
        }
    }
}
