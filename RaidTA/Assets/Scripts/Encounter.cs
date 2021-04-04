using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public SpellDB spell_db;
    public UnitDB unit_db;
    public NPCDB npc_db;

    public List<NPC> npc_list;

    protected RaidManager raid_manager;

    public float encountertime;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spell_db = (SpellDB) Resources.Load("SpellDatabase");
        unit_db = (UnitDB) Resources.Load("UnitDatabase");
        npc_db = (NPCDB) Resources.Load("NPCDatabase");
        npc_list = new List<NPC>();
        SpawnRaid();
        AddNewNPCs(raid_manager.unit_list);
        InitThreatTables();
        encountertime = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        encountertime += Time.deltaTime;
    }

    void SpawnRaid()
    {
        GameObject rm = new GameObject("RaidManager");
        raid_manager = rm.AddComponent(typeof(RaidManager)) as RaidManager;
        raid_manager.encounter = this;
        SetPlayers();
        AddNewPlayers();
    }

    protected void CastSpell(int spell_id, Vector3 location)
    {
        if(spell_id < 0 || spell_id >= spell_db.spells.Length)  { return; }
        if(spell_db.spells[spell_id].spell_prefab == null) { return; }
        Instantiate(spell_db.spells[spell_id].spell_prefab, location, Quaternion.identity);
    }

    protected virtual void SetPlayers()
    {

    }

    protected void AddNewPlayer(int unit_id, Vector3 location)
    {
        if (unit_id < 0 || unit_id >= unit_db.units.Length) { return; }
        
        UnitSO unit = unit_db.units[unit_id];
        raid_manager.AddNewPlayer(unit, location);  
    }

    protected virtual void AddNewPlayers()
    {

    }

    protected void AddNewNPC(int npc_id, Vector3 location)
    {
        if(npc_id < 0 || npc_id >= npc_db.npcs.Length) { return; }

        NPCSO npc = npc_db.npcs[npc_id];
        npc_list.Add(Instantiate(npc.npc_prefab, location, Quaternion.identity).GetComponent<NPC>());
        npc_list[npc_list.Count - 1].encounter = this;
        npc_list[npc_list.Count - 1].name = npc.name;
    }

    protected virtual void AddNewNPCs(List<Unit> units)
    {

    }

    protected void InitThreatTables()
    {
        for(int i = 0; i < npc_list.Count; i++)
        {
            npc_list[i].InitTable(raid_manager.unit_list);
        }
    }

    public void BroadcastThreat(Unit unit, float threat_amount)
    {
        for(int i = 0; i < npc_list.Count; i++)
        {
            npc_list[i].AddThreat(unit, threat_amount/npc_list.Count);
        }
    }


    public Vector3 RandomPlayerLocation()
    {
        return raid_manager.RandomPlayerLocation();
    }

}
