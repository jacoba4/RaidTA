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

    public void SetPlayers(List<Unit> inc_unit_list)
    {
        this.unit_list = inc_unit_list;
        for (int i = 0; i < this.unit_list.Count; i++)
        {
            this.unit_list[i].encounter = encounter;
            this.unit_list[i].enabled = true;
            this.unit_list[i].ControlUnit(false);
        }
    }

    public void AddNewPlayer(UnitSO unit, Vector3 location)
    {
        unit_list.Add(Instantiate(unit.unit_prefab, location, Quaternion.identity).GetComponent<Unit>());

        Unit new_unit = unit_list[unit_list.Count - 1];
        new_unit.encounter = encounter;
        new_unit.name = unit.unit_name + " (" + (unit_list.Count).ToString() + ")";
        new_unit.number.text = (unit_list.Count).ToString();
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
        if (selected_unit != null) { selected_unit.GetComponent<Unit>().ControlUnit(false); }
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
                selected_unit.SetNewTarget(hitData.transform.GetComponent<NPC>());
            }
            else if(hitData.transform.tag == "Player" && selected_unit.is_healer)
            {
                selected_unit.SetNewTarget(hitData.transform.GetComponent<Unit>());
            }
        }
        else
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 1;
            selected_unit.MoveToLocation(worldPos);
        }
    }

    public void DamageRaid(int damage)
    {
        for(int i = 0; i < unit_list.Count; i++)
        {
            unit_list[i].TakeDamage(damage);
        }
    }
}
