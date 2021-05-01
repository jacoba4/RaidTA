using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMController : MonoBehaviour
{
    public int encounter_id;
    public SMNode Start_start;
    public SMNode Update_start;
    // Start is called before the first frame update
    void Start()
    {
        //run from Start_start
        Start_start = GameObject.FindGameObjectWithTag("SMStart").GetComponent<SMNode>();
        Update_start = GameObject.FindGameObjectWithTag("SMUpdate").GetComponent<SMNode>();
    }

    // Update is called once per frame
    void Update()
    {
        //run from Update_start
        if(Update_start != null)
        {
            Update_start.Execute();
        }
    }

    public void Execute()
    {
        if (Start_start != null)
        {
            Start_start.Execute();
        }
    }
}
