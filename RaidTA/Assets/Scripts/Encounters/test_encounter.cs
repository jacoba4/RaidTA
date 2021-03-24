using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_encounter : Encounter
{

    private List<SetupManager.UnitEntry> unitEntries;

    public void Init(List<SetupManager.UnitEntry> smEntries)
    {
        unitEntries = smEntries;
        base.Start();
        StartCoroutine("RaidDamage");
    }

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        if(npc_list[0].hp == 0)
        {
            SceneManager.LoadScene("YouWin");
        }

        for(int i = 0; i < raid_manager.unit_list.Count; i++)
        {
            if(raid_manager.unit_list[i].hp > 0)
            {
                return;
            }
        }

        SceneManager.LoadScene("YouLose");
    }

    protected override void AddNewPlayers()
    {
        base.AddNewPlayers();

        foreach(SetupManager.UnitEntry unit in this.unitEntries)
        {
            AddNewPlayer(unit.unitID, unit.unitPos);
        }

        Debug.Log("Unit Count: " + this.raid_manager.unit_list.Count);

        /*
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

    public void SetUnitList(List<SetupManager.UnitEntry> units)
    {
        this.unitEntries = units;
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
