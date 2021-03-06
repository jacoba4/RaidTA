using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Unit
{
    [Serializable]
    public struct ThreatEntry
    {
        public Unit unit;
        public float threat;
    }

    int CompareThreatEntry(ThreatEntry x, ThreatEntry y)
    {
        if(x.threat == y.threat)
        {
            return 0;
        }

        else if(x.threat < y.threat)
        {
            return 1;
        }

        else
        {
            return -1;
        }
    }

    public List<ThreatEntry> threat_table;


    protected override void Update()
    {
        base.Update();
        if(current_target != null)
        {
            CheckTarget();
        }
        else
        {
            CheckThreat();
        }
    }
    public void InitTable(List<Unit> units)
    {
        for (int i = 0; i < units.Count; i++)
        {
            ThreatEntry temp;
            temp.unit = units[i];

            if(i == 0)
            {
                temp.threat = 5;
            }
            else
            {
                temp.threat = 1;
            }
            
            threat_table.Add(temp);
        }


    }

    public void AddThreat(Unit unit, float threat)
    {
        ThreatEntry entry = FindEntry(unit);
        if(entry.unit == null) 
        {
            Debug.Log("No entry for unit");
            return; 
        }
        
        entry.threat += threat;
        ReplaceEntry(entry);


        CheckThreat();
    }

    ThreatEntry FindEntry(Unit unit)
    {
        for (int i = 0; i < threat_table.Count; i++)
        {
            if (threat_table[i].unit == unit)
            {
                return threat_table[i];
            }
        }

        ThreatEntry nul;
        nul.unit = null;
        nul.threat = float.NegativeInfinity;
        return nul;
    }

    void ReplaceEntry(ThreatEntry entry)
    {
        for (int i = 0; i < threat_table.Count; i++)
        {
            if (threat_table[i].unit == entry.unit)
            {
                threat_table[i] = entry;
            }
        }
    }

    void Taunt(Unit unit)
    {
        ThreatEntry entry = FindEntry(unit);
        if(entry.unit == null) { return; }

        ThreatEntry top = threat_table[0];
        entry.threat = top.threat * 1.3f;

        CheckThreat();
    }

    void CheckThreat()
    {
        if(threat_table.Count == 0) { return; }
        Sort();
        ThreatEntry current = FindEntry(current_target);
        ThreatEntry top = threat_table[0];
        if(top.threat == 0) { return; }
        float distance = Vector3.Distance(transform.position, top.unit.transform.position);
        if (current.unit != top.unit)
        {
            if (distance > MeleeRange && top.threat >= current.threat * 1.3)
            {
                current_target = top.unit;
            }
            else if (distance <= MeleeRange && top.threat >= current.threat * 1.1)
            {
                current_target = top.unit;
            }
        }
    }

    void Sort()
    {
        threat_table.Sort(CompareThreatEntry);
    }

    void PrintThreatTable()
    {
        Debug.Log("-----Threat Table (" + gameObject.name + ")------------------");
        for (int i = 0; i < threat_table.Count; i++) 
        {
            Debug.Log(threat_table[i].unit.name + "   -   " + threat_table[i].threat);
        }
        Debug.Log("------------------(" + new string('-', gameObject.name.Length) + ")------------------");
    }

    void CheckTarget()
    {
        if (current_target == null) { return; }
        if (current_target.hp == 0)
        {
            ThreatEntry temp = FindEntry(current_target);
            temp.threat = 0;
            ReplaceEntry(temp);
            CheckThreat();
        }
    }

}

