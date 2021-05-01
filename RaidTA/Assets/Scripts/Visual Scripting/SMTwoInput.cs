using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMTwoInput : SMOneInput
{
    public SMNode input_b;

    public override void Execute()
    {
        if (!CheckInputs()) { return; }
        base.Execute();
    }
    protected override bool CheckInputs()
    {
        base.CheckInputs();
        if(input_b == null) 
        { 
            ErrorInputB();
            return false;
        }
        return true;
    }
    protected void ErrorInputB()
    {
        Debug.LogError("Invalid Input B");
    }
    
    public void LinkB(SMNode input)
    {
        input_b = input;
    }

    public void UnlinkB()
    {
        input_b = null;
    }
}
