using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
    public List<Unit> unit_list;
    public Unit selected_unit;
    public Encounter encounter;

    // Start is called before the first frame update
    void Awake()
    {
        unit_list = new List<Unit>();
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
        selected_unit = unit_list[index];
        unit_list[index].GetComponent<Unit>().ControlUnit(true);

    }

    void ClearSelection()
    {
        selected_unit = null;
    }

    void Click()
    {
        if(selected_unit == null) { return; }
        RaycastHit hitData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitData))
        {
            if(hitData.transform.tag == "NPC" && !selected_unit.is_healer)
            {
                Debug.Log("Sending new target: " + hitData.transform.name);
                selected_unit.SetNewTarget(hitData.transform.GetComponent<NPC>());
            }
            else if(hitData.transform.tag == "Player" && selected_unit.is_healer)
            {
                Debug.Log("Sending new healing target: " + hitData.transform.name);
                selected_unit.SetNewTarget(hitData.transform.GetComponent<Unit>());
            }
            else
            {
                Debug.Log("Sending new location: " + hitData.point);
                selected_unit.MoveToLocation(hitData.point);
            }
        }
    }
}
