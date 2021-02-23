using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Unit
{
    [Serializable]
    public struct ThreatItem
    {
        Unit unit;
        float threat;
    }

    public ThreatItem[] public_table;
    public Dictionary<Unit, float> threat_table;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitTable(List<Unit> units)
    {
        for(int i = 0; i < units.Count; i++)
        {
            threat_table.Add(units[i], 0);
        }
    }

    void AddThreat(Unit unit, float threat)
    {
        threat_table[unit] += threat;
        CheckThreat();
    }

    void Taunt(Unit unit)
    {

    }

    void CheckThreat()
    {

    }


}
