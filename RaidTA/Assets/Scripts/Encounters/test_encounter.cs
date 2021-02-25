using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_encounter : Encounter
{
    protected override void AddNewPlayers()
    {
        base.AddNewPlayers();
        AddNewPlayer(0, new Vector3(0, 0, 0));
        AddNewPlayer(0, new Vector3(0, 1, 0));
        AddNewPlayer(0, new Vector3(1, 0, 0));
    }

    protected override void AddNewNPCs(List<Unit> units)
    {
        AddNewNPC(0, new Vector3(2, 2, 0));
    }
}
