using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public SpellDB spell_db;
    public UnitDB unit_db;
    public NPCDB npc_db;

    public int npc_size;
    public List<Unit> npc_list;

    RaidManager raid_manager;


    // Start is called before the first frame update
    protected virtual void Start()
    {
       spell_db = (SpellDB) Resources.Load("SpellDatabase");
       unit_db = (UnitDB) Resources.Load("UnitDatabase");
       npc_db = (NPCDB) Resources.Load("NPCDatabase");
       SpawnRaid();
    }
 

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRaid()
    {
        Debug.Log("Spawning RaidManager");
        GameObject rm = new GameObject("RaidManager");
        raid_manager = rm.AddComponent(typeof(RaidManager)) as RaidManager;
        AddNewPlayers();
    }

    void CastSpell(int spell_id, Vector3 location)
    {
        if(spell_id < 0 || spell_id >= spell_db.spells.Length)  { return; }
        if(spell_db.spells[spell_id].spell_prefab == null) { return; }
        Instantiate(spell_db.spells[spell_id].spell_prefab, location, Quaternion.identity);
    }


    protected void AddNewPlayer(int unit_id, Vector3 location)
    {
        if (unit_id < 0 || unit_id >= unit_db.units.Length) { return; }
        
        UnitSO unit = unit_db.units[unit_id];
        Debug.Log(unit);
        raid_manager.AddNewPlayer(unit, location);  
    }

    public virtual void AddNewPlayers()
    {

    }

    public Vector3 RandomPlayerLocation()
    {
        return raid_manager.RandomPlayerLocation();
    }

}
