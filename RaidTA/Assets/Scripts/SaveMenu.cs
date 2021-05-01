using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveParty
{
    public SaveUnit[] units;
}

[System.Serializable]
public class SaveUnit
{
    public List<float> stats;
    public Vector3 pos;

    public SaveUnit(List<float> s, Vector3 p)
    {
        stats = s;
        pos = p;
    }
}

public class SaveMenu : MonoBehaviour
{

    public UnitDB unitDB;
    public InputField party_string;
    public Button save;
    public Button load;

    void Start()
    {
        unitDB = (UnitDB) Resources.Load("UnitDatabase");
    }

    public SaveUnit[] EntriesToSaveUnits(List<SetupManager.UnitEntry> entries)
    {
        SaveUnit[] newUnits = new SaveUnit[entries.Count];
        for (int i = 0; i < entries.Count; i++)
        {
            SetupManager.UnitEntry entry = entries[i];
            List<float> stats = new List<float>{ entry.unitID, entry.unitScript.hp, entry.unitScript.damage,
                entry.unitScript.attack_speed, entry.unitScript.range, entry.unitScript.move_speed};
            newUnits[i] = new SaveUnit(stats, entry.unitPos);
        }

        return newUnits;
    }

    public List<SetupManager.UnitEntry> SaveUnitsToEntries(SaveUnit[] saveUnits)
    {
        List<SetupManager.UnitEntry> loadEntries = new List<SetupManager.UnitEntry>();
        for (int i = 0; i < saveUnits.Length; i++)
        {
            UnitSO unitDBSel = unitDB.units[(int) saveUnits[i].stats[0]];
            GameObject unitObj = (GameObject) Instantiate(unitDBSel.unit_prefab, transform.position, Quaternion.identity);
            unitObj.transform.position = saveUnits[i].pos;

            Unit newScript = unitObj.GetComponent<Unit>();
            newScript.hp = (int) saveUnits[i].stats[1];
            newScript.max_hp = (int) saveUnits[i].stats[1];
            newScript.damage = (int) saveUnits[i].stats[2];
            newScript.attack_speed = saveUnits[i].stats[3];
            newScript.range = saveUnits[i].stats[4];
            newScript.move_speed = saveUnits[i].stats[5];
            newScript.number.text = (i+1).ToString();

            SetupManager.UnitEntry newEntry = new SetupManager.UnitEntry() { unitID = (int) saveUnits[i].stats[0], unitScript = newScript, unitPos = saveUnits[i].pos };
            loadEntries.Add(newEntry);
        }

        return loadEntries;
    }

    public void Save(List<SetupManager.UnitEntry> entries)
    {
        SaveParty newParty = new SaveParty();
        SaveUnit[] newUnits = EntriesToSaveUnits(entries);
        newParty.units = newUnits;

        string jsonParty = JsonUtility.ToJson(newParty);
        string saveName = party_string.text;

        PlayerPrefs.SetString(saveName, jsonParty);
    }

    public List<SetupManager.UnitEntry> Load()
    {
        string loadName = party_string.text;
        if (!PlayerPrefs.HasKey(loadName)) { return new List<SetupManager.UnitEntry>(); }
        string jsonParty = PlayerPrefs.GetString(loadName);

        SaveParty loadParty = JsonUtility.FromJson<SaveParty>(jsonParty);

        return SaveUnitsToEntries(loadParty.units);
    }
}