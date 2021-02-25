using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
    public List<Unit> unit_list;
    public List<bool> selected_units;
    public Encounter encounter;

    // Start is called before the first frame update
    void Awake()
    {
        unit_list = new List<Unit>();
        selected_units = new List<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Click();
        }

        if(Input.GetKeyDown("1"))
        {
            SelectUnit(0);
        }
        if (Input.GetKeyDown("2"))
        {
            SelectUnit(1);
        }
        if (Input.GetKeyDown("3"))
        {
            SelectUnit(2);
        }
        if (Input.GetKeyDown("4"))
        {
            SelectUnit(3);
        }
        if (Input.GetKeyDown("5"))
        {
            SelectUnit(4);
        }
        if (Input.GetKeyDown("6"))
        {
            SelectUnit(5);
        }
        if (Input.GetKeyDown("7"))
        {
            SelectUnit(6);
        }
        if (Input.GetKeyDown("8"))
        {
            SelectUnit(7);
        }



    }

    public void AddNewPlayer(UnitSO unit, Vector3 location)
    {
        unit_list.Add(Instantiate(unit.unit_prefab, location, Quaternion.identity).GetComponent<Unit>());
        selected_units.Add(false);

        unit_list[unit_list.Count - 1].encounter = encounter;
        unit_list[unit_list.Count - 1].name = unit.unit_name + " " + (unit_list.Count - 1).ToString();
    }

    public Vector3 RandomPlayerLocation()
    {
        if(unit_list.Count == 0) { return Vector3.negativeInfinity; }
        int index = Random.Range(0, unit_list.Count);
        return unit_list[index].transform.position;
    }

    void SelectUnit(int index)
    {
        if( index < 0 || index >= unit_list.Count)
        {
            Debug.LogError("invalid SelectUnit index");
            return;
        }
        ClearSelection();
        selected_units[index] = true;
        unit_list[index].GetComponent<Unit>().ControlUnit(true);

    }

    void ClearSelection()
    {
        for(int i = 0; i < selected_units.Count; i++)
        {
            selected_units[i] = false;
        }
    }

    void Click()
    {
        RaycastHit hitData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitData))
        {
            if(hitData.transform.tag == "NPC")
            {
                Debug.Log("Sending new target: " + hitData.transform.name);
                SendNewTarget(hitData.transform.GetComponent<NPC>());
            }
            else
            {
                Debug.Log("Sending new location: " + hitData.point);
                SendMouseCoordinate(hitData.point);
            }
        }
    }

    void SendNewTarget(NPC npc)
    {
        for(int i = 0; i < selected_units.Count; i++)
        {
            if(selected_units[i])
            {
                unit_list[i].GetComponent<Unit>().SetNewTarget(npc);
            }
        }
    }

    void SendMouseCoordinate(Vector3 pos)
    {
        for (int i = 0; i < selected_units.Count; i++)
        {
            if(selected_units[i])
            {
                unit_list[i].GetComponent<Unit>().MoveToLocation(pos);
            }
        }
    }
}
