using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_encounter : Encounter
{

    public override void Init(List<Unit> smUnits)
    {
        base.Init(smUnits);
        StartCoroutine("RaidDamage");
    }

    protected override void AddNewPlayers()
    {
        base.AddNewPlayers();
        Debug.Log("Unit Count: " + this.raid_manager.unit_list.Count);

        /*
        foreach(SetupManager.UnitEntry unit in this.unitEntries)
        {
            AddNewPlayer(unit.unitID, unit.unitPos);
        }

        AddNewPlayer(0, new Vector3(0, 2, 0));
        AddNewPlayer(1, new Vector3(0, 0, 0));
        AddNewPlayer(2, new Vector3(-2, 0, 0));
        AddNewPlayer(2, new Vector3(0, -2, 0));
        AddNewPlayer(2, new Vector3(2, 0, 0));
        */
    }

    protected override void AddNewNPCs(List<Unit> units)
    {
        AddNewNPC(0, new Vector3(0, 4, 0));
        Debug.Log("NPC Count: " + this.npc_list.Count);
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
