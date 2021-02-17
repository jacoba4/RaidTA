using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_encounter : Encounter
{
    public override void AddNewPlayers()
    {
        Debug.Log("Adding players");
        base.AddNewPlayers();
        AddNewPlayer(0, new Vector3(0, 0, 0));
        AddNewPlayer(0, new Vector3(0, 1, 0));
        AddNewPlayer(0, new Vector3(0, 0, 1));
    }
}
