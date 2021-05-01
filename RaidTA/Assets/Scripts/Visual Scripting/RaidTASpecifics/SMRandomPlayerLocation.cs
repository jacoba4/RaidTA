using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMRandomPlayerLocation : SMNode
{ 
    public override object Output()
    {
        RaidManager rm = GameObject.Find("RaidManager").GetComponent<RaidManager>();
        if(rm)
        {
            return rm.RandomPlayerLocation();
        }
        else { return null; }
        
    }
}
