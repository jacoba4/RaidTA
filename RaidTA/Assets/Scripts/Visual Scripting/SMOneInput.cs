using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMOneInput : SMNode
{
    public SMNode input_a;


    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        base.Execute();
    }

    protected virtual bool CheckInputs()
    {
        if(input_a == null) 
        { 
            ErrorInputA();
            return false;
        }
        return true;
    }
    protected void ErrorInputA()
    {
        Debug.LogError("Invalid Input A");
    }

    public void LinkA(SMNode input)
    {
        input_a = input;
    }

    public void UnlinkA()
    {
        input_a = null;
    }
}
