using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_encounter : Encounter
{

    protected override void Start()
    {
        base.Start();
        StartCoroutine("RaidDamage");
    }
    protected override void AddNewPlayers()
    {
        base.AddNewPlayers();
        AddNewPlayer(0, new Vector3(0, 2, 0));
        AddNewPlayer(1, new Vector3(0, 0, 0));
        AddNewPlayer(2, new Vector3(-2, 0, 0));
        AddNewPlayer(2, new Vector3(0, -2, 0));
        AddNewPlayer(2, new Vector3(2, 0, 0));
    }

    protected override void AddNewNPCs(List<Unit> units)
    {
        AddNewNPC(0, new Vector3(0, 4, 0));
    }

    IEnumerator RaidDamage()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);
            raid_manager.DamageRaid(2);
            yield return new WaitForSeconds(10f);
            CastSpell(0, raid_manager.RandomPlayerLocation());
        }
    }
}
