using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
    public List<GameObject> unit_list;

    // Start is called before the first frame update
    void Awake()
    {
        unit_list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewPlayer(UnitSO unit, Vector3 location)
    {
        unit_list.Add(Instantiate(unit.unit_prefab, location, Quaternion.identity));
    }

    public Vector3 RandomPlayerLocation()
    {
        if(unit_list.Count == 0) { return Vector3.negativeInfinity; }
        int index = Random.Range(0, unit_list.Count);
        return unit_list[index].transform.position;
    }
}
