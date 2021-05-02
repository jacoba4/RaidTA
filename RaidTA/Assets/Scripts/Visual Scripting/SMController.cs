using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMController : MonoBehaviour
{
    public int encounter_id;
    public SMNode Start_start;
    public SMNode Update_start;
    private bool running;
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
        if(Update_start != null && running)
        {
            Update_start.Execute();
        }
    }

    public void Execute()
    {
        if (Start_start != null && running)
        {
            Start_start.Execute();
        }
    }

    public void Pause()
    {
        running = false;
    }

    public void Play()
    {
        running = true;
    }
    
    public void GoToRaidCust()
    {
        GameObject.FindGameObjectWithTag("SMCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("SetupCanvas").GetComponent<Canvas>().enabled = true;

        GameObject parent = gameObject.transform.parent.gameObject;
        LineRenderer[] child_lr = parent.GetComponentsInChildren<LineRenderer>();
        for(int i = 0; i < child_lr.Length; i++)
        {
            child_lr[i].enabled = false;
        }
    }
}
