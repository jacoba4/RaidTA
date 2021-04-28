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

        /*
        SMPrintBool print = new SMPrintBool();
        SMAND and = new SMAND();
        SMFalse f = new SMFalse();
        SMTrue t = new SMTrue();
        and.input_a = t;
        and.input_b = f;
        print.input_a = and;
        Start_start = print;

        SMPrintBool print2 = new SMPrintBool();
        SMOR or = new SMOR();
        or.input_a = f;
        or.input_b = f;
        print2.input_a = or;

        print.SetNext(print2);*/
    }

    // Update is called once per frame
    void Update()
    {
        //run from Update_start
    }

    public void Execute()
    {
        if (Start_start != null)
        {
            Start_start.Execute();
        }
    }
}
